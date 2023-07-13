using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookWorm.MVC.Models;

[PrimaryKey(nameof(BookId), nameof(ContributorId), nameof(ContributorRoleId))]
public class BookContributor
{
    public int BookId { get; set; }
    [Required]
    public Book Book { get; set; } = null!;

    public int ContributorId { get; set; }
    [Required]
    public Contributor Contributor { get; set; } = null!;

    public int ContributorRoleId { get; set; }
    [Required]
    public ContributorRole ContributorRole { get; set; } = null!;
}
