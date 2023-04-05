using Sedai.Interfaces;
using Sedai.Layers;

namespace Sedai.MathMethods;

public class DeltaCounter
{
    private static double[] GetOutputLayerDeltas(ILayer? layer, double result, double desiredResult)
    {
        double[] deltas = new double[layer!.Neurons.Length];

        for (int i = 0; i < deltas.Length; i++)
        {
            deltas[i] = (desiredResult - result) * ActivationFunction.GetDerivative(result);
        }

        return deltas;
    }

    public static double[] GetLayerDeltas(ILayer? layer, double result, double desiredResult)
    {
        if (layer!.GetType() == typeof(OutputLayer))
        {
            return GetOutputLayerDeltas(layer, result, desiredResult);
        }

        double[] deltas = new double[layer.Neurons.Length];
        double[] nextLayerDeltas = GetLayerDeltas(layer.NextLayer, result, desiredResult);

        for (int i = 0; i < layer.Neurons.Length; i++)
        {
            double sum = 0;

            for (int j = 0; j < layer.NextLayer!.Neurons.Length; j++)
            {
                sum += layer.NextLayer.Neurons[j].Weights![i] * nextLayerDeltas[j];
            }

            deltas[i] = ActivationFunction.GetDerivative(layer.Neurons[i].Output) * sum;
        }

        return deltas;
    }
}