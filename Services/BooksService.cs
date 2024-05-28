using BookStoreApi.Models;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class BooksService
{
    private readonly MongoDbContext _context;

    public BooksService(MongoDbContext context)=> _context = context;

    public async Task<List<Book>> GetAsync() =>
        await _context.Books.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await _context.Books.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Book newBook) =>
        await _context.Books.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Book updatedBook) =>
        await _context.Books.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _context.Books.DeleteOneAsync(x => x.Id == id);
}