using BookStore.Model.Comments.Entities;
using BookStore.Model.Frameworks;
using BookStore.Model.Orders.Entities;

namespace BookStore.Model.Books.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<BookTag> Tags { get; set; } = new List<BookTag>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

}
