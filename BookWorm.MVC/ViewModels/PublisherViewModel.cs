namespace BookWorm.MVC.ViewModels;

public class PublisherViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int BookCount { get; set; }
    public bool IsActive { get; set; } = true;
}
