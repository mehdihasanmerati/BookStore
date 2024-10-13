using BookStore.Model.Books.Entities;
using BookStore.Model.Frameworks;

namespace BookStore.Model.Tags.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public ICollection<BookTag> Books { get; set; } = new List<BookTag>();
    }
}
