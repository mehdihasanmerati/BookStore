using BookStore.Model.Frameworks;
using BookStore.Model.Orders.DTO;
using MediatR;

namespace BookStore.Model.Orders.Queries
{
    public class GetOrderQuery: IRequest<ApplicationServiceResponse<List<GetOrderDto>>>
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
    }
}
