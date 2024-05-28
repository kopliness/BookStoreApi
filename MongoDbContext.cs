using BookStoreApi.Models;
using MongoDB.Driver;
namespace BookStoreApi;

public class MongoDbContext
{
    private readonly IMongoDatabase _database = null;

    public MongoDbContext()
    {
        var client = new MongoClient("mongodb://mongodb:27017");
        if (client != null)
            _database = client.GetDatabase("BookStoreDb");
    }

    public IMongoCollection<Book> Books
    {
        get
        {
            return _database.GetCollection<Book>("Book");
        }
    }
}