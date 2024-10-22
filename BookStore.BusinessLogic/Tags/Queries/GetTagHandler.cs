using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.DAL.Tags;
using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Queries;

namespace BookStore.BusinessLogic.Tags.Queries
{
    public class GetTagHandler : BaseApplicationServiceHandler<GetTagQuery, List<GetTagDto>>
    {
        public GetTagHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Tags.WhereOver(request.TagName).ToTagQueryAsync();
            AddResult(result);
        }
    }
}
