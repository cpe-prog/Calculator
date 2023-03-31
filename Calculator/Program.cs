using Calculator.Math;
using Calculator.SaveMongoDb;
using Calculator.SaveTextFile;
using MongoDB.Bson;
using MongoDB.Driver;

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
        const string connectionString = "mongodb://127.0.0.1:27017";
        const string databaseName = "math_db";
        const string collectionName = "mathHistory";
        
        var cmd = args[0];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<BsonDocument>(collectionName);
        
        var db = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
        switch (cmd)
        {
            case "showDB":
                MongoDbHistory.ShowDataBase();
                return;
            case "removeDB":
                MongoDbHistory.RemoveDataBase();
                return;
            case "show":
                TextFileHistory.ShowHistory(db);
                return;
            case "remove":
                TextFileHistory.RemoveHistory(db);
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
        var files = $" = {result}";
        Console.WriteLine($"Here is the result: {result}");
        File.AppendAllText(db, $"{file}{files}\n");
        
        var document = new BsonDocument
        {
            {"operation", file},
            {"result", result}
        };
        collection.InsertOne(document);
    }

}

public interface IOperation
{
    public double Calculate(double[] numbers);
}