using Sedai.Interfaces;
using Sedai.Layers;

namespace Sedai.MathMethods;

public class GradientCounter
{
    public static double[,] GetLayerGradients(ILayer? layer, ILayer prevLayer, double result, double desiredResult)
    {
        double[,] gradients = new double[layer!.Neurons.Length, prevLayer.Neurons.Length];
        double[] layerDeltas = DeltaCounter.GetLayerDeltas(layer, result, desiredResult);

        for (int i = 0; i < layer.Neurons.Length; i++)
        {
            for (int j = 0; j < layer.Neurons[i].Weights!.Length; j++)
            {
                if (prevLayer.GetType() == typeof(InputLayer))
                {
                    gradients[i, j] = layerDeltas[i] * prevLayer.Neurons[j].Inputs![0];
                }
                else
                {
                    gradients[i, j] = layerDeltas[i] * prevLayer.Neurons[j].Output;
                }
            }
        }

        return gradients;
    }
}