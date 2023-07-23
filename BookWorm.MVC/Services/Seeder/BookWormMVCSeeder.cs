using BookWorm.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Services.Seeder;

public static class BookWormMVCSeeder
{
    public static async Task SeedSampleDataAsync(IServiceProvider services)
    {
        using(var dbContext = new ApplicationDbContext(
            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if(!dbContext.Publishers.Any())
            {
                await BookWormMVCSeederPublishers.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }

        using(var dbContext = new ApplicationDbContext(
            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if(!dbContext.ContributorRoles.Any())
            {
                await BookWormMVCSeederContributorRoles.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }

        using(var dbContext = new ApplicationDbContext(
            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if(!dbContext.Contributors.Any())
            {
                await BookWormMVCSeederContributors.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }

        using(var dbContext = new ApplicationDbContext(
            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if(!dbContext.Books.Any())
            {
                await BookWormMVCSeederBooks.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }

        using(var dbContext = new ApplicationDbContext(
            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if(!dbContext.BookContributors.Any())
            {
                await BookWormMVCSeederBookConributors.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }
    }
}