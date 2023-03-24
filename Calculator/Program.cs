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
        // var OperatorSymbol = new List<char>();
        // var Symbol = OperatorSymbol;

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
       
        
        var operation1 = $"{numbers[0]} {opString.Length} {numbers[1]} = {result}";
        using (var writer = File.AppendText(historyFilePath))
        {
            writer.WriteLine(operation1);
        }
        history.Add(operation1);
        File.WriteAllLines(historyFilePath , history);
        

        switch (args.Length)
        {
            case 1 when args[0] == "show":
                ShowHistory(history);
                break;
            case 2 when args[1] == "remove":
                RemoveHistory(historyFilePath);
                break;
        }
    }
    
    
    //show history
    private static void ShowHistory(List<string> history)
    {
        Console.WriteLine("History:");
        foreach (var operation1 in history)
        {
            Console.WriteLine(operation1);
        }
    }
    //remove history
    private static void RemoveHistory(string historyFilePath)
    {
       File.Delete(historyFilePath);
       Console.WriteLine("History Cleared.");
    }
    
}


internal interface IOperator 
{
    double Calculate(double[] numbers);
}