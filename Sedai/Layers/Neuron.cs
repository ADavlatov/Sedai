using Sedai.MathMethods;

namespace Sedai.Layers;

public class Neuron
{
    public Neuron(double[]? weights, double[]? inputs, double[]? weightsChange)
    {
        Weights = weights;
        Inputs = inputs;
        WeightsChange = weightsChange;
    }

    //веса
    public double[]? Weights { get; }

    //изменения весов при предыдущей корректировке
    public double[]? WeightsChange { get; }

    //входы
    public double[]? Inputs { get; set; }

    //выход
    public double Output
    {
        get => ActivationFunction.GetValue(Inputs!, Weights);
    }
}