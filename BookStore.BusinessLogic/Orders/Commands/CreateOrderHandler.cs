using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Orders.Commands;
using BookStore.Model.Orders.Entities;

namespace BookStore.BusinessLogic.Orders.Commands
{
    public class CreateOrderHandler : BaseApplicationServiceHandler<CreateOrder, Order>
    {
        public CreateOrderHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerEmail = request.CustomerEmail,
                OrderDate = request.OrderDate,
                Price = request.Price,
                BookId = request.BookId,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            AddResult(order);
        }
    }
}
