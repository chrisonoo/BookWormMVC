using System.ComponentModel.DataAnnotations;

namespace BookWorm.MVC.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public ICollection<Book>? Books { get; set; }
}
