using Sedai.Interfaces;

namespace Sedai.MathMethods;

public class WeightChangeCounter
{
    public static void ChangeLayerWeights(ILayer? layer, ILayer prevLayer, double trainSpeed, double momentum,
        double result,
        double desiredResult)
    {
        double[,] gradients = GradientCounter.GetLayerGradients(layer, prevLayer, result, desiredResult);

        for (int i = 0; i < layer!.Neurons.Length; i++)
        {
            for (int j = 0; j < layer.Neurons[i].Weights!.Length; j++)
            {
                double weightChange = trainSpeed * gradients[i, j] + momentum * layer.Neurons[i].WeightsChange![j];
                
                layer.Neurons[i].Weights![j] += weightChange;
                layer.Neurons[i].WeightsChange![j] = weightChange;
            }
        }
    }
}