using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Orders.Commands
{
    public class DeleteOrder: IRequest<ApplicationServiceResponse<bool>>
    {
        public int Id { get; set; }
    }
}
