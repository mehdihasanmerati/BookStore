using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Orders.Commands;

namespace BookStore.BusinessLogic.Orders.Commands
{
    public class DeleteOrderHandler : BaseApplicationServiceHandler<DeleteOrder, bool>
    {
        public DeleteOrderHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteOrder request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);

            if (order == null)
            {
                AddError($"The order with Id {request.Id} not found!");
                return;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            AddResult(true);
        }
    }
}
