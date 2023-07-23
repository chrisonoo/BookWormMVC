using BookWorm.MVC.Data;
using BookWorm.MVC.Models;

namespace BookWorm.MVC.Services.Seeder;

public static class BookWormMVCSeederPublishers
{
    private static readonly List<Publisher> _publishersSeedDataList = new()
    {
        new Publisher
        {
            Name = "Publisher 1",
            IsActive = true,
        },
        new Publisher
        {
            Name = "Publisher 2",
            IsActive = true,
        },
        new Publisher
        {
            Name = "Publisher 3",
            IsActive = true,
        },
        new Publisher
        {
            Name = "Publisher 4",
            IsActive = false,
        },
        new Publisher
        {
            Name = "Publisher 5",
            IsActive = true,
        },
    };

    public static async Task Initialize(ApplicationDbContext dbContext)
    {
        foreach(var publisher in _publishersSeedDataList)
        {
            await dbContext.Publishers.AddAsync(publisher);
        }
    }
}
