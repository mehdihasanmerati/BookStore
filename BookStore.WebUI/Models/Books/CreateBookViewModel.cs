using BookStore.Model.Tags.Entities;

namespace BookStore.WebUI.Models.Books
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public List<int> SelectedTags { get; set; } = new List<int>();
        public List<Tag> TagsForDisplay { get; set; } = new List<Tag>();
    }
}
