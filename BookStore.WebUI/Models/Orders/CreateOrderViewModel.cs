using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.WebUI.Models.Orders
{
    public class CreateOrderViewModel
    {
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public int BookId { get; set; }

        public List<SelectListItem> BookList { get; set; } = new();
    }
}
