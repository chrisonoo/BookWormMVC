using BookWorm.MVC.Data;
using BookWorm.MVC.Models;

namespace BookWorm.MVC.Services.Seeder;

public class BookWormMVCSeederBooks
{
    private static readonly List<Book> _booksSeedDataList = new()
    {
        new Book
        {
            Title = "Book 1",
            PublicationYear = 2001,
            PublisherId = 1,
        },
        new Book
        {
            Title = "Book 2",
            PublicationYear = 2002,
            PublisherId = 2,
        },
        new Book
        {
            Title = "Book 3",
            PublicationYear = 2003,
            PublisherId = 3,
        },
        new Book
        {
            Title = "Book 4",
            PublicationYear = 2004,
            PublisherId = 2,
        },
        new Book
        {
            Title = "Book 5",
            PublicationYear = 2005,
            PublisherId = 1,
        },
        new Book
        {
            Title = "Book 6",
            PublicationYear = 2004,
            PublisherId = 3,
        },
        new Book
        {
            Title = "Book 7",
            PublicationYear = 2001,
            PublisherId = 2,
        },
        new Book
        {
            Title = "Book 8",
            PublicationYear = 2008,
            PublisherId = 2,
        },
        new Book
        {
            Title = "Book 9",
            PublicationYear = 2001,
            PublisherId = 1,
        },
    };

    public static async Task Initialize(ApplicationDbContext dbContext)
    {
        foreach(var book in _booksSeedDataList)
        {
            await dbContext.Books.AddAsync(book);
        }
    }
}