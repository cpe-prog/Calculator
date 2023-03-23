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
    
    
    static readonly List<string> History = new();
    static void ShowHistory()
    {
        Console.WriteLine("History:");
        foreach (var item in History)
        {
            Console.WriteLine(item);
        }
    }
    static void RemoveHistory()
    {
        History.Clear();
    }

    
    
    static void Main(string[] args)
    {
        
        // var historyItem = @"C:\Desktop\History.txt";
        
        
        if (args.Length < 2)
        {
            return;
        }
        
        var opString = args[0];
        
        // the main function will check the command show and remove history
        if (args[0] == "show" && args[1] == "history")
        {
            ShowHistory();
            return;
        }
        if (args[0] == "remove" && args[1] == "history")
        {
            RemoveHistory();
            Console.WriteLine("History cleared");
            return;
        }
        
        
        
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
        
        
        var historyItem = $"{opString} ";
        for (var i = 0; i < numbers.Length; i++)
        {
            historyItem += $"{numbers[i]} ";
            if (i < numbers.Length - 1)
            {
                historyItem += $"{opString} ";
            }
        }
        History.Add(historyItem.TrimEnd());


    }
}


internal interface IOperator
{
    double Calculate(double[] numbers);
}