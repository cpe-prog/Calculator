namespace Calculator.Math;

internal class AddOperation : Operation
{
    public override double Calculate(double[] numbers)
    {
        return numbers.Sum();
    }
}