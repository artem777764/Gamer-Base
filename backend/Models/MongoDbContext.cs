using MongoDB.Driver;
using MongoDB.Driver.GridFS;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient client)
    {
        _database = client.GetDatabase("GamerBase");
    }

    public GridFSBucket GridFsBucket => new GridFSBucket(_database);
}