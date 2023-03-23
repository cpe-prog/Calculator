using Calculator.Math;
namespace Calculator;

public static class Program
{
    static readonly Dictionary<string, IOperator> Operators = new()
    {
        { "add", new AddOperator() },
        { "subtract", new SubtractOperator() },
        { "multiply", new MultiplyOperator() },
        { "divide", new DivideOperator() }
    };
    

    static void Main(string[] args)
    {
        const string historyFilePath = @"C:\Desktop\History.txt";
        var history = new List<string>();
        

        if (args.Length < 2)
        {
            return;
        }
        
        var opString = args[0];
        
        
        if (!Operators.TryGetValue(opString, out var op))
        {
            Console.WriteLine($"Invalid operator: {opString}");
            return;
        }
        var numbers = new double[args.Length - 1];
        for (var i = 1; i < args.Length; i++)
        {
            if (double.TryParse(args[i], out var number))
            {
                numbers[i - 1] = number;
            }
            else
            {
                Console.WriteLine($"Invalid type of input: {args[i]}");
            }
        }
        var result = op.Calculate(numbers);
        Console.WriteLine($"Here is the result: {result}");

        var operation = string.Join(' ', args);
        history.Add(operation);
        
        File.AppendAllLines(historyFilePath, history);
    }
}


internal interface IOperator
{
    double Calculate(double[] numbers);
}