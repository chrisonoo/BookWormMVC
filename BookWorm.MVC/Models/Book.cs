using System.ComponentModel.DataAnnotations;

namespace BookWorm.MVC.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;

    public int PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public ICollection<BookContributor>? BookContributors { get; set; }
}
