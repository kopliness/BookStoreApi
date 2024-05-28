using MongoDB.Driver;
using BookStoreApi.Models;

namespace BookStoreApi;

public class MongoDbContext
{
    private readonly IMongoDatabase _database = null;

    public MongoDbContext()
    {
        var client = new MongoClient("mongodb://mongodb:27017");
        if (client != null)
            _database = client.GetDatabase("BookStoreDb");

        CreateInitialRecords();
    }

    public IMongoCollection<Book> Books
    {
        get
        {
            return _database.GetCollection<Book>("Book");
        }
    }

    private void CreateInitialRecords()
    {
        var books = Books.Find(_ => true).ToList();

        if (!books.Any())
        {
            Books.InsertOne(new Book
            {
                Id = "61a6058e6c43f32854e51f51",
                BookName = "Design Patterns",
                Price = (decimal)54.93,
                Category = "Computers",
                Author = "Ralph Johnson"
            });

            Books.InsertOne(new Book
            {
                Id = "61a6058e6c43f32854e51f52",
                BookName = "Clean Code",
                Price = (decimal)43.15,
                Category = "Computers",
                Author = "Robert C. Martin"
            });
        }
    }
}