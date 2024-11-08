using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.Authors;
using BookStore.DAL.DbContexts;
using BookStore.Model.Authors.DTO;
using BookStore.Model.Authors.Queries;

namespace BookStore.BusinessLogic.Authors.Queries
{
    public class GetAuthorHandler : BaseApplicationServiceHandler<GetAuthorQuery, List<GetAuthorDto>>
    {
        public GetAuthorHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.WhereOver(request.FirstName, request.LastName).ToAuthorQueryAsync();
            AddResult(author);
        }
    }
}
