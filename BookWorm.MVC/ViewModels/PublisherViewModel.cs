using BookWorm.MVC.Models;

namespace BookWorm.MVC.ViewModels;

public class PublisherViewModel
{
    public Publisher Publisher { get; set; } = null!;
    public int BookCount { get; set; }
}
