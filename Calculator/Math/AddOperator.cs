namespace Calculator.Math;

internal class AddOperator : IOperator
{
    public double Calculate(double[] numbers)
    {
        return numbers.Sum();
    }
}