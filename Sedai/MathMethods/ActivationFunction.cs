namespace Sedai.MathMethods;

public static class ActivationFunction
{
    public static double GetValue(double[] inputs, double[]? weights)
    {
        double sum = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            sum += inputs[i] * weights![i];
        }

        return Math.Pow(1 + Math.Exp(-sum), -1);
    }

    public static double GetDerivative(double output)
    {
        return (1 - output) * output;
    }
}