using BookStore.Model.Frameworks;
using BookStore.Model.Tags.Entities;

namespace BookStore.Model.Books.Entities
{
    public class BookTag : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
