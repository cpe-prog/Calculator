using Calculator.Math;
namespace Calculator;
public static class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            return;
        }
    
        var opString = args[0];

        var operators = new Dictionary<string, IOperator>
        {
            { "add", new AddOperator() },
            { "subtract", new SubtractOperator() },
            { "multiply", new MultiplyOperator() },
            { "divide", new DivideOperator() }
        };
        
        
        if (!operators.TryGetValue(opString, out var op))
        {
            Console.WriteLine($"Invalid operator: {opString}");
            return;
        }
        
        
        
        var numbers = new double[args.Length - 1];
        for (var i = 1; i < args.Length; i++)
        {
            if (!double.TryParse(args[i], out double number))
            {
                Console.WriteLine($"Invalid type of input: {args[i]}");
                return;
            }

            numbers[i - 1] = number;
        }
        
        var result = op.Calculate(numbers);
        Console.WriteLine($"Here is the result: {result}");
    }
}




interface IOperator
{
    double Calculate(double[] numbers);
}