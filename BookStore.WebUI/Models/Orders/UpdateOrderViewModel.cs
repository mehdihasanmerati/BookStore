namespace BookStore.WebUI.Models.Orders
{
    public class UpdateOrderViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public int BookId { get; set; }
    }
}
