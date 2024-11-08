using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.DAL.Orders;
using BookStore.Model.Orders.DTO;
using BookStore.Model.Orders.Queries;

namespace BookStore.BusinessLogic.Orders.Queries
{
    public class GetOrderByIdHandler : BaseApplicationServiceHandler<GetOrderByIdQuery, GetOrderDto>
    {
        public GetOrderByIdHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.WhererId(request.Id, request.BookId).ToOrderSingleQueryAsync();
            
            if (order != null)
            {
                AddResult(order);
            }
            else
            {
                AddError("The order not found!");
            }
        }
    }
}
