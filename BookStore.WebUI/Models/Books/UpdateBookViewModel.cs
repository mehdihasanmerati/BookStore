using BookStore.Model.Tags.Entities;

namespace BookStore.WebUI.Models.Books
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImageFile { get; set; } // // برای بارگذاری تصویر جدید
        public string? CurrentImageUrl { get; set; } // برای نگه‌داشتن URL فعلی
        public List<int> SelectedTags { get; set; } = new List<int>();
        public List<Tag> TagsForDisplay { get; set; } = new List<Tag>();
    }
}
