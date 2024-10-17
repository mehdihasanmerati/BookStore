using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Entities;
using BookStore.Model.Tags.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Tags.Queries
{
    public class GetTagHandler : IRequestHandler<GetTagQuery, ApplicationServiceResponse<List<GetTagDto>>>
    {
        private readonly BookDbContext _context;

        public GetTagHandler(BookDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationServiceResponse<List<GetTagDto>>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tags = _context.Tags.AsQueryable();
            if (!string.IsNullOrEmpty(request.TagName))
            {
                tags = tags.Where(t => t.TagName.Contains(request.TagName));
            }

            var result = await tags.Select(c => new GetTagDto
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToListAsync(cancellationToken);

            return new ApplicationServiceResponse<List<GetTagDto>> { Result = result };
        }
    }
}
