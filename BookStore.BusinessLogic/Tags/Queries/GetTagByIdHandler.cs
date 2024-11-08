using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Queries;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Tags.Queries
{
    public class GetTagByIdHandler : BaseApplicationServiceHandler<GetTagByIdQuery, GetTagDto>
    {
        public GetTagByIdHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags
           .Where(t => t.Id == request.Id)
           .Select(t => new GetTagDto
           {
               Id = t.Id,
               TagName = t.TagName
           }).FirstOrDefaultAsync();

            AddResult(tag);
        }
    }
}
