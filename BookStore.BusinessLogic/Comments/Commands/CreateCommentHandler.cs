using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Comments.Commands;
using BookStore.Model.Comments.Entities;

namespace BookStore.BusinessLogic.Comments.Commands
{
    public class CreateCommentHandler : BaseApplicationServiceHandler<CreateComment, Comment>
    {
        public CreateCommentHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateComment request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                BookComment = request.BookComment,
                CommentBy = request.CommentBy,
                IsValid = request.IsValid,
                CommentDate = request.CommentDate,
                BookId = request.BookId,
            };

            await _context.BookComments.AddAsync(comment);
            await _context.SaveChangesAsync();

            AddResult(comment);
        }
    }
}
