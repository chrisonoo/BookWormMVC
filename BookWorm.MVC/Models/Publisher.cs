using System.ComponentModel.DataAnnotations;

namespace BookWorm.MVC.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    // Default will only be used for inserts when the property value is 'null'
    // This is configured in ApplicationDbContext.cs
    public bool IsActive { get; set; }

    public ICollection<Book>? Books { get; set; }
}
