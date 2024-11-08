using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.Authors;
using BookStore.DAL.DbContexts;
using BookStore.Model.Authors.DTO;
using BookStore.Model.Authors.Queries;

namespace BookStore.BusinessLogic.Authors.Queries
{
    public class GetAuthorByIdHandler : BaseApplicationServiceHandler<GetAuthorByIdQuery, GetAuthorDto>
    {
        public GetAuthorByIdHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.WhereId(request.Id).ToAuthorQuerySingleAsync();

            if (author != null)
            {
                AddResult(author);
            }
            else
            {
                AddError("The author not found!");
            }
        }
    }
}
