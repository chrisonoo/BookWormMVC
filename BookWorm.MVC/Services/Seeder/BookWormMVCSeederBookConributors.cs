using BookWorm.MVC.Data;
using BookWorm.MVC.Models;

namespace BookWorm.MVC.Services.Seeder;

public static class BookWormMVCSeederBookConributors
{
    private static readonly List<BookContributor> _bookContributorsSeedDataList = new()
    {
        new BookContributor
        {
            BookId = 1,
            ContributorId = 1,
            ContributorRoleId = 1,
        },
        new BookContributor
        {
           BookId = 2,
            ContributorId = 2,
            ContributorRoleId = 1,
        },
        new BookContributor
        {
            BookId = 1,
            ContributorId = 2,
            ContributorRoleId = 3,
        },
        new BookContributor
        {
            BookId = 1,
            ContributorId = 3,
            ContributorRoleId = 4,
        },
        new BookContributor
        {
            BookId = 1,
            ContributorId = 5,
            ContributorRoleId = 5,
        },
    };

    public static async Task Initialize(ApplicationDbContext dbContext)
    {
        foreach(var bookContributor in _bookContributorsSeedDataList)
        {
            await dbContext.BookContributors.AddAsync(bookContributor);
        }
    }
}
