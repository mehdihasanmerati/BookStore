using BookStore.Model.Authors.Entities;
using BookStore.Model.Frameworks;

namespace BookStore.Model.Books.Entities
{
    public class BookAuthor : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int SortOrder { get; set; }
    }
}
