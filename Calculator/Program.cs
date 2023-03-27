using Calculator.Math;

namespace Calculator;

public static class Program
{
    private static readonly Dictionary<string, Operator> Operators = new()
    {
        { "add", new Operator('+', new AddOperation())},
        { "subtract", new Operator('-', new SubtractOperation())},
        { "multiply", new Operator('×', new MultiplyOperation())},
        { "divide", new Operator('÷', new DivideOperation())}
    };
    
    private static void Main(string[] args)
    {
        var cmd = args[0];
        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        switch (cmd)
        {
            case "show":
                ShowHistory(db);
                return;
            case "remove":
                RemoveHistory(db);
                return;
        }
        
        if (!Operators.TryGetValue(cmd, out var op))
        {
            Console.WriteLine($"Invalid operator: {cmd}");
            return;
        }

        var numbers = new double[args.Length - 1];
        for (var i = 1; i < args.Length; i++)
        {
            if (double.TryParse(args[i], out var number))
            {
                numbers[i -1] =number;
            }
            else
            {
                Console.WriteLine($"Invalid type of input: {args[i]}");
            }
        }
        var result = op.Operation.Calculate(numbers.ToArray());
        // 1 + 1 = 2
        var file = $"{string.Join(" "+op.Symbol + " ", numbers)}";
        file += $" = {result}";
        Console.WriteLine($"Here is the result: {result}");
        File.AppendAllText(db, $"{file}\n");
    }
    
    
    //show history
    private static void ShowHistory(string filePath)
    {
        if (!File.Exists(filePath)) return;
        Console.WriteLine("History:");
        var history = File.ReadAllText(filePath);
        Console.WriteLine(history);
    }
    //remove history
    private static void RemoveHistory(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("History already removed");
        }
        File.Delete(filePath);
        Console.WriteLine("History Cleared");
    }
}
internal class Operator
{
    public char Symbol { get;}
    internal IOperation Operation { get;}

    public Operator(char symbol, IOperation operation)
    {
        Symbol = symbol;
        Operation = operation;
    }
}

internal interface IOperation
{
    public double Calculate(double[] numbers);
}