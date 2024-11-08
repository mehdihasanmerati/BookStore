using Microsoft.AspNetCore.Http;

namespace BookStore.Model.Books.DTO
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<int> SelectedTags {  get; set; } = new List<int>();
    }
}
