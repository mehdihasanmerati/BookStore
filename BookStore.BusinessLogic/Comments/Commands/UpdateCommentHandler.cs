using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Comments.Commands;
using BookStore.Model.Comments.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Comments.Commands
{
    public class UpdateCommentHandler : BaseApplicationServiceHandler<UpdateComment, Comment>
    {
        public UpdateCommentHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateComment request, CancellationToken cancellationToken)
        {
            var comments = await _context.BookComments.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (comments == null)
            {
                AddError($"The comment with ID {request.Id} not found!");
            }
            else
            {
                // Getting data directly from the database
                comments.BookComment = request.BookComment;
                comments.CommentBy = request.CommentBy;
                comments.CommentDate = request.CommentDate;
                comments.IsValid = request.IsValid;
                comments.BookId = request.BookId;

                _context.BookComments.Update(comments);
                await _context.SaveChangesAsync();

                AddResult(comments);
            }
            
        }
    }
}
