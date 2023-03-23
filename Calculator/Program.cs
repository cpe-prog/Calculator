using Calculator.Math;
namespace Calculator;

public static class Program
{

    private static readonly Dictionary<string, IOperator> Operators = new()
    {
        { "add", new AddOperator() },
        { "subtract", new SubtractOperator() },
        { "multiply", new MultiplyOperator() },
        { "divide", new DivideOperator() }
    };
    
    private static void Main(string[] args)
    {

        const string historyFilePath = @"C:\Users\GRIAN\Desktop\History.txt";
        var history = new List<string>();
        if (File.Exists(historyFilePath))
        {
            history.AddRange(File.ReadAllLines(historyFilePath));
        }
        
        if (args.Length < 2)
        {
            ShowHistory(history);
            return;
        }

        // var exist = File.Exists(historyFilePath);
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
        var operation = string.Join(' ', args.ToArray());
        Console.WriteLine($"Here is the result: {result}");
        
        
        history.Add(operation);
        File.WriteAllLines(historyFilePath, history);
        

        switch (args.Length)
        {
            case 2 when args[1] == "show":
                ShowHistory(history);
                break;
            case 1 when args[0] == "remove":
                RemoveHistory(historyFilePath);
                break;
        }
    }
    
    
    //show history
    static void ShowHistory(List<string> history)
    {
        Console.WriteLine("History:");
        foreach (var operation in history)
        {
            Console.WriteLine(operation);
        }
    }
    //remove history
    static void RemoveHistory(string historyFilePath)
    {
        File.Delete(historyFilePath);
        Console.WriteLine("History Cleared!");
    }
    
}


internal interface IOperator
{
    double Calculate(double[] numbers);
}