namespace Calculator.Math;

internal class AddOperation : IOperation
{
    public double Calculate(double[] numbers)
    {
        return numbers.Sum();
    }
}