namespace Calculator.Math;

class AddOperator : IOperator
{
    public double Calculate(double[] numbers)
    {
        return numbers.Sum();
    }
}