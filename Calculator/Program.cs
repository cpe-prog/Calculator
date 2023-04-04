using Calculator.DataAccessFunctions;
using Calculator.Math;
using Calculator.MongoDb;
using Calculator.TextFile;

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
            case "showDB.data":
                MongoDbHistory.ShowDataBase();
                return;
            case "removeDB.data":
                MongoDbHistory.RemoveDataBase();
                return; 
            case "show.text.file.data":
                TextFileHistory.ShowHistory(db);
                return;
            case "remove.text.file.data":
                TextFileHistory.RemoveHistory(db);
                return;
        }

        DataAccess dataAccess;
        Console.WriteLine("Where you like to save?");
        Console.WriteLine("For Database type: DB");
        Console.WriteLine("For TextFile type: TF");
        var choices = Console.ReadLine();
        switch (choices)
        {
            case "DB":
                dataAccess = new MongoDbDataAccess();
                break;
            case "TF":
                dataAccess = new TextFileDataAccess();
                break;
            default:
                Console.WriteLine("Invalid choices");
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
        Console.WriteLine($"Here is the result: {result}");
        dataAccess.SaveOperation(file, result);
    }
}
