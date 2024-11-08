using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.DAL.Orders;
using BookStore.Model.Orders.DTO;
using BookStore.Model.Orders.Queries;

namespace BookStore.BusinessLogic.Orders.Queries
{
    public class GetOrderHandle : BaseApplicationServiceHandler<GetOrderQuery, List<GetOrderDto>>
    {
        public GetOrderHandle(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.WhereOver(request.CustomerEmail, request.BookId).ToOrderQueryAsync();
            AddResult(order);
        }
    }
}
