namespace Calculators.Math;

public class DivideOperation : Operation
{
    public override double Calculate(double[] numbers)
    {
        var result = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == 0)
            {
                Console.WriteLine("Error to divide by zero");
            }
            result /= numbers[i];
        }
        return result;
    }
}