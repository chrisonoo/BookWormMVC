using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Models;

[PrimaryKey(nameof(BookId), nameof(ContributorId), nameof(ContributorRoleId))]
public class BookContributor
{
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int ContributorId { get; set; }
    public Contributor? Contributor { get; set; }

    public int ContributorRoleId { get; set; }
    public ContributorRole? ContributorRole { get; set; }
}
