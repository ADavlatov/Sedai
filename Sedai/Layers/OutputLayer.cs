using Sedai.Helpers;
using Sedai.Interfaces;

namespace Sedai.Layers;

public class OutputLayer : ILayer
{
    public OutputLayer(int neuronsCount, int prevLayerNeuronsCount, ILayer? nextLayer)
    {
        NextLayer = nextLayer;
        Neurons = new Neuron[neuronsCount];
        WeightInitialize weightInitialize = new WeightInitialize();
        double[,] layerWeights = weightInitialize.GetRandomWeights(neuronsCount, prevLayerNeuronsCount);

        //инициализируем нейроны слоя
        for (int i = 0; i < neuronsCount; i++)
        {
            double[] neuronWeights = new double[prevLayerNeuronsCount];
            double[] weightsChange = new double[prevLayerNeuronsCount];

            for (int j = 0; j < prevLayerNeuronsCount; j++)
            {
                neuronWeights[j] = layerWeights[i, j];
                weightsChange[j] = 0;
            }

            Neurons[i] = new Neuron(neuronWeights, null, weightsChange);
        }
    }

    public double[] Pass()
    {
        double[] output = new double[Neurons.Length];

        for (int i = 0; i < Neurons.Length; i++)
        {
            Neurons[i].Inputs = OperationData;
            output[i] = Neurons[i].Output;
        }

        return output;
    }

    public Neuron[] Neurons { get; }
    public double[]? OperationData { get; set; }
    public ILayer? NextLayer { get; }
}