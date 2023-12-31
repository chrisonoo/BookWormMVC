﻿using BookWorm.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opions)
        : base(opions) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<BookContributor> BookContributors { get; set; }
    public DbSet<ContributorRole> ContributorRoles { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>()
            .Property(p => p.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<ContributorRole>()
            .Property(r => r.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Contributor>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
}
