using BookWorm.MVC.Data;
using BookWorm.MVC.Models;

namespace BookWorm.MVC.Services.Seeder;

public class BookWormMVCSeederContributorRoles
{
    private static readonly List<ContributorRole> _contributorRolesSeedDataList = new()
    {
        new ContributorRole
        {
            Name = "Autor",
            IsActive = true,
        },new ContributorRole
        {
            Name = "Expert",
            IsActive = false,
        },
        new ContributorRole
        {
            Name = "Translator",
            IsActive = true,
        },
        new ContributorRole
        {
            Name = "Consultant",
            IsActive = true,
        },
        new ContributorRole
        {
            Name = "Reviewer",
            IsActive = true,
        },
    };

    public static async Task Initialize(ApplicationDbContext dbContext)
    {
        foreach(var contributorRole in _contributorRolesSeedDataList)
        {
            await dbContext.ContributorRoles.AddAsync(contributorRole);
        }
    }
}
