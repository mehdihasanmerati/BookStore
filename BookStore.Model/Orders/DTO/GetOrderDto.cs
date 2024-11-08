namespace BookStore.Model.Orders.DTO
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
    }
}
