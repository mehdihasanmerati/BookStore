using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Comments.Commands;

namespace BookStore.BusinessLogic.Comments.Commands
{
    public class DeleteCommandHandler : BaseApplicationServiceHandler<DeleteComment, bool>
    {
        public DeleteCommandHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = await _context.BookComments.FindAsync(request.Id);

            if (comment == null)
            {
                AddError($"The comment with Id {request.Id} not found!");
                return;
            }

            _context.BookComments.Remove(comment);
            await _context.SaveChangesAsync();

            AddResult(true);
        }
    }
}
