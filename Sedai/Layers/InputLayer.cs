using Sedai.Interfaces;

namespace Sedai.Layers;

public class InputLayer : ILayer
{
    public InputLayer(ILayer? nextLayer, int neuronsCount)
    {
        NextLayer = nextLayer;
        Neurons = new Neuron[neuronsCount];

        //у входных нейроной отсутствуют синапсы
        for (int i = 0; i < neuronsCount; i++)
        {
            Neurons[i] = new Neuron(null, new double[1], null);
        }
    }

    //Выход у входных нейроной равен их входу, тк нет весов
    public void Pass(double[] inputs)
    {
        NextLayer!.OperationData = inputs;

        for (int i = 0; i < Neurons.Length; i++)
        {
            Neurons[i].Inputs![0] = inputs[i];
        }
    }

    public double[]? OperationData { get; set; }
    public Neuron[] Neurons { get; set; }
    public ILayer? NextLayer { get; set; }
}