using Sedai.Layers;

namespace Sedai.Interfaces;

public interface ILayer
{
    public double[]? OperationData { set; }
    public Neuron[] Neurons { get; }
    public ILayer? NextLayer { get; }
}