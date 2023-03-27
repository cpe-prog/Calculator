
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
        switch (cmd)
        {
            case "show":
                ShowHistory();
                return;
            case "remove":
                RemoveHistory();
                return;
        }

        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        var history = new List<string>();
        if (File.Exists(db))
        {
            history.AddRange(File.ReadAllLines(db));
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
                numbers[i -1] = number;
            }
            else
            {
                Console.WriteLine($"Invalid type of input: {args[i]}");
            }
        }
        
        if (numbers.Length < 2)
        {
            return;
        }
        
        var result = op.Operation.Calculate(numbers.ToArray());
        Console.WriteLine($"Here is the result: {result}");
        // 1 + 1 = 2
        var file = "";
        foreach (var valNumber in numbers)
        {
            file += $"{string.Join(" " + op.Symbol + " ", valNumber)}";
        }
        file = file.Substring(0, file.Length - 1);
        file += $" = {result}";
        SaveHistory(file);


    }
    //save history
    private static void SaveHistory(string operation)
    {
        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        using var filePath = File.AppendText(db);
        filePath.WriteLine(operation);
    }
    //show history
    private static void ShowHistory()
    {
        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        if (!File.Exists(db)) Console.WriteLine("History not found!");
        Console.WriteLine("History:");
        var history = File.ReadAllLines(db);
        foreach (var operation in history)
        {
            Console.WriteLine(operation);
        }
    }
    
    //remove history
    private static void RemoveHistory()
    {
        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        //invert if statement
        if (!File.Exists(db)) Console.WriteLine("History already removed!");
        File.Delete(db);
        Console.WriteLine("History Cleared.");
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