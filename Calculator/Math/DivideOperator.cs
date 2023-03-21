namespace Calculator.Math;

 class DivideOperator : IOperator
{
    public double Calculate(double[] numbers)
    {
        var result = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == 0)
            {
                throw new DivideByZeroException("Error to divide by zero");
            }
            result /= numbers[i];
        }
        return result;
    }
}