namespace Calculators.Math;

public class AddOperation : Operation
{
    public override double Calculate(double[] numbers)
    {
        return numbers.Sum();
    }

    public object Symbol { get;}
}