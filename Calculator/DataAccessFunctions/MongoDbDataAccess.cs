using MongoDB.Bson;
using MongoDB.Driver;

namespace Calculator.DataAccessFunctions;

internal class MongoDbDataAccess : DataAccess
{
    
    private readonly MongoClient _client = new("mongodb://127.0.0.1:27017");
    private readonly IMongoCollection<BsonDocument> _collection;
    public MongoDbDataAccess()
    {  
        var database = _client.GetDatabase("math_db");
        _collection = database.GetCollection<BsonDocument>("mathHistory");
    }
    public override void SaveOperation(string operation, double result)
    {
        var document = new BsonDocument
        {
            {"operation", operation},
            {"result", result}
        };
        _collection.InsertOne(document);
    }
}