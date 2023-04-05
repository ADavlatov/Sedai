namespace Sedai.MathMethods;

public class ErrorCalculation
{
    public static double GetMeanSquaredError(double[] results, double[] desiredResult, int iterationsCount)
    {
        double sum = 0;

        for (int i = 0; i < results.Length; i++)
        {
            sum += Math.Pow(desiredResult[i] - results[i], 2);
        }

        return sum / iterationsCount;
    }
}