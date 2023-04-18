using MongoDB.Bson;
using MongoDB.Driver;

namespace Calculators.MongoDb;

internal abstract class MongoDbHistory
{
    public static void ShowDataBase()
    {
        var client = new MongoClient("mongodb://127.0.0.1:27017");
        var database = client.GetDatabase("math_db");
        var collection = database.GetCollection<BsonDocument>("mathHistory");
        
        var data = new BsonDocument();
        var sort = new BsonDocument("_id", 1);
        var cursor = collection.Find(data).Sort(sort).ToCursor();
        foreach (var document in cursor.ToEnumerable())
        {
            var operation = document.GetValue("operation").AsString;
            var result = document.GetValue("result").AsDouble;
            Console.WriteLine($"{operation} = {result}");
        }
    } 
    public static void RemoveDataBase()
    {
        var client = new MongoClient("mongodb://127.0.0.1:27017");
        var database = client.GetDatabase("math_db");
        var collection = database.GetCollection<BsonDocument>("mathHistory");
        
        collection.DeleteMany(Builders<BsonDocument>.Filter.Empty);
        Console.WriteLine($"All data in Mongodb Database has been erase");
    }
}

