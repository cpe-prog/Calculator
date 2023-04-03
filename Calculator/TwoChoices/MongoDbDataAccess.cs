using MongoDB.Bson;
using MongoDB.Driver;

namespace Calculator.TwoChoices;

internal class MongoDbDataAccess : ITwoChoices
{
    
    private readonly MongoClient _client = new("mongodb://127.0.0.1:27017");
    private readonly IMongoCollection<BsonDocument> _collection;
    public MongoDbDataAccess()
    { 
        var database = _client.GetDatabase("math_db");
        _collection = database.GetCollection<BsonDocument>("mathHistory");
    }
    public void SaveOperation(string operation, double result)
    {
        var document = new BsonDocument
        {
            {"operation", operation},
            {"result", result}
        };
        _collection.InsertOne(document);
    }
}