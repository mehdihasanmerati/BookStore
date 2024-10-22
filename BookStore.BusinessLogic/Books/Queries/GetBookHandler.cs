using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.Books;
using BookStore.DAL.DbContexts;
using BookStore.Model.Books.DTO;
using BookStore.Model.Books.Queries;

namespace BookStore.BusinessLogic.Books.Queries
{
    public class GetBookHandler : BaseApplicationServiceHandler<GetBookQuery, List<GetBookDto>>
    {
        public GetBookHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Books.WhereOver(request.Name, request.Author).ToBookQueryAsync();
            AddResult(result);
        }
    }
}
