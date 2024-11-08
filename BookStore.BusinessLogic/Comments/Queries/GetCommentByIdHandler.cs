using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.Comments;
using BookStore.DAL.DbContexts;
using BookStore.Model.Comments.DTO;
using BookStore.Model.Comments.Queries;

namespace BookStore.BusinessLogic.Comments.Queries
{
    public class GetCommentByIdHandler : BaseApplicationServiceHandler<GetCommentByIdQuery, GetCommentDto>
    {
        public GetCommentByIdHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.BookComments.WhereId(request.Id, request.BookId).ToCommentQuerySingleAsync();
            
            if (comment != null)
            {
                AddResult(comment);
            }
            else
            {
                AddError("The comment not found!");
            }
        }
    }
}
