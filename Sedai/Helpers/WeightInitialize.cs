namespace Sedai.Helpers;

public class WeightInitialize
{
    public double[,] GetRandomWeights(int neuronsCount, int prevLayerNeuronsCount)
    {
        double[,] weights = new double[neuronsCount, prevLayerNeuronsCount];
        Random random = new Random();

        //задаем весам каждого нейрона рандомные значения
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            for (int j = 0; j < weights.GetLength(1); j++)
            {
                weights[i, j] = random.NextDouble();
            }
        }

        return weights;
    }
}