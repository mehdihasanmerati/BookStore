using BookStore.Model.Frameworks;
using BookStore.Model.Orders.DTO;
using MediatR;

namespace BookStore.Model.Orders.Queries
{
    public class GetOrderByIdQuery: IRequest<ApplicationServiceResponse<GetOrderDto>>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
    }
}
