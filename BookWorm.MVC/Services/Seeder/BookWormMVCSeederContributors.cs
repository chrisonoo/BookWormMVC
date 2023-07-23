using BookWorm.MVC.Data;
using BookWorm.MVC.Models;

namespace BookWorm.MVC.Services.Seeder;

public class BookWormMVCSeederContributors
{
    private static readonly List<Contributor> _contributorsSeedDataList = new()
    {
        new Contributor
        {
            Name = "Contributor 1",
            IsActive = true,
        },
        new Contributor
        {
            Name = "Contributor 2",
            IsActive = true,
        },
        new Contributor
        {
            Name = "Contributor 3",
            IsActive = true,
        },
        new Contributor
        {
            Name = "Contributor 4",
            IsActive = false,
        },
        new Contributor
        {
            Name = "Contributor 5",
            IsActive = true,
        },
        new Contributor
        {
            Name = "Contributor 6",
            IsActive = true,
        },
    };

    public static async Task Initialize(ApplicationDbContext dbContext)
    {
        foreach(var contributor in _contributorsSeedDataList)
        {
            await dbContext.Contributors.AddAsync(contributor);
        }
    }
}
