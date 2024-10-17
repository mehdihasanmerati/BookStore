using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Tags.Queries
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, GetTagDto>
    {
        private readonly BookDbContext _context;

        public GetTagByIdHandler(BookDbContext context)
        {
            _context = context;
        }

        public async Task<GetTagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags
           .Where(t => t.Id == request.Id)
           .Select(t => new GetTagDto
           {
               Id = t.Id,
               TagName = t.TagName
           }).FirstOrDefaultAsync(cancellationToken);

            return tag;
        }
    }
}
