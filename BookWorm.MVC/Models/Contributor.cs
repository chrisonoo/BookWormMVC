using System.ComponentModel.DataAnnotations;

namespace BookWorm.MVC.Models;

public class Contributor
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public ICollection<BookContributor>? BookContributors { get; set; }
}
