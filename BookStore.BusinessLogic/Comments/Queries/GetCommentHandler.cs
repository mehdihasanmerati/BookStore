using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.Comments;
using BookStore.DAL.DbContexts;
using BookStore.Model.Comments.DTO;
using BookStore.Model.Comments.Queries;

namespace BookStore.BusinessLogic.Comments.Queries
{
    public class GetCommentHandler : BaseApplicationServiceHandler<GetCommentQuery, List<GetCommentDto>>
    {
        public GetCommentHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.BookComments.WhereOver(request.BookComment , request.BookId).ToCommentQueryAsync();
            AddResult(comment);
        }
    }
}
