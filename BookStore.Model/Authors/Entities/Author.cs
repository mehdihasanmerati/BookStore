using BookStore.Model.Books.Entities;
using BookStore.Model.Frameworks;

namespace BookStore.Model.Authors.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
