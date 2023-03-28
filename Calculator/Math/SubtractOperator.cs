namespace Calculator.Math;

internal class SubtractOperation : IOperation
{
    public double Calculate(double[] numbers)
    {
        var result = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            result -= numbers[i];
        }
        return result;
    }
}