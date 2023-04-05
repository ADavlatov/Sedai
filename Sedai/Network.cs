using Sedai.Layers;
using Sedai.MathMethods;

namespace Sedai;

public class Network
{
    private InputLayer? _inputLayer;
    private HiddenLayer[]? _hiddenLayer;
    private OutputLayer? _outputLayer;

    //инициализация нейронной сети с заданными параметрами
    public void Initialize(int inputNeuronsCount, int hiddenLayersCount, int[] neuronsInHiddenLayersCount,
        int outputNeuronsCount)
    {
        if (neuronsInHiddenLayersCount.Length != hiddenLayersCount)
        {
            throw new Exception(
                "Количество скрытых слоев не соответствует переданному массиву нейронов для скрытых слоев");
        }
        
        //в нейронной сети может быть несколько скрытых слоев
        _hiddenLayer = new HiddenLayer[hiddenLayersCount];

        var prevLayerNeuronsCount = inputNeuronsCount;

        _outputLayer = new OutputLayer(outputNeuronsCount, neuronsInHiddenLayersCount[^1], null);

        for (int i = 0; i < hiddenLayersCount; i++)
        {
            if (i + 1 == hiddenLayersCount)
            {
                _hiddenLayer[i] = new HiddenLayer(neuronsInHiddenLayersCount[i], prevLayerNeuronsCount, _outputLayer);
                break;
            }

            _hiddenLayer[i] =
                new HiddenLayer(neuronsInHiddenLayersCount[i], prevLayerNeuronsCount, _hiddenLayer[i + 1]);
            prevLayerNeuronsCount = neuronsInHiddenLayersCount[i];
        }

        _inputLayer = new InputLayer(_hiddenLayer[0], inputNeuronsCount);
    }

    //прямой проход по нейронной сети с заданными входными значениями
    public double[] Start(double[]? inputs)
    {
        _inputLayer!.Pass(inputs!);

        for (int i = 0; i < _hiddenLayer!.Length; i++)
        {
            if (i + 1 >= _hiddenLayer.Length)
            {
                _hiddenLayer[i].Pass(_outputLayer!);
                break;
            }

            _hiddenLayer[i].Pass(_hiddenLayer[i + 1]);
        }

        return _outputLayer!.Pass();
    }

    //прямой проход с тренировочным сетом
    public static double[] PassWithTrainingSet(double[] trainingSet, Network network)
    {
        return network.Start(trainingSet);
    }

    //изменение весов
    public void Teach(Network network, double result, double desiredResult, double trainSpeed, double momentum)
    {
        WeightChangeCounter.ChangeLayerWeights(network._outputLayer!, network._hiddenLayer![0], trainSpeed, momentum,
            result,
            desiredResult);

        WeightChangeCounter.ChangeLayerWeights(network._hiddenLayer[0], network._inputLayer!, trainSpeed, momentum,
            result,
            desiredResult);
    }
}