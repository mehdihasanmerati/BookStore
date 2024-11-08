using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Orders.Commands;
using BookStore.Model.Orders.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Orders.Commands
{
    public class UpdateOrderHandler : BaseApplicationServiceHandler<UpdateOrder, Order>
    {
        public UpdateOrderHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateOrder request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (order == null)
            {
                AddError($"The order with ID {request.Id} not found!");
            }
            else
            {
                order.BookId = request.BookId;
                order.OrderDate = request.OrderDate;
                order.CustomerEmail = request.CustomerEmail;
                order.Price = request.Price;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                AddResult(order);
            }
        }
    }
}
