using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Authors.Commands;

namespace BookStore.BusinessLogic.Authors.Commands
{
    public class DeleteAuthorHandler : BaseApplicationServiceHandler<DeleteAuthor, bool>
    {
        public DeleteAuthorHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteAuthor request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FindAsync(request.Id);

            if (author == null)
            {
                AddError($"The author with Id {request.Id} not found!");
                return;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            AddResult(true);
        }
    }
}
