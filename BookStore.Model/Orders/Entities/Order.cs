using BookStore.Model.Books.Entities;
using BookStore.Model.Frameworks;

namespace BookStore.Model.Orders.Entities
{
    public class Order : BaseEntity
    {
        public int BookId { get; set; }
        public Book book { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
    }
}
