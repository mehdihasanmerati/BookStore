using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.Entities;
using MediatR;

namespace BookStore.BusinessLogic.Tags.Comments
{
    public class CreateTagHandler : IRequestHandler<CreateTag, ApplicationServiceResponse<Tag>>
    {
        private readonly BookDbContext _context;

        public CreateTagHandler(BookDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationServiceResponse<Tag>> Handle(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new()
            {
                TagName = request.TagName
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return new ApplicationServiceResponse<Tag>
            {
                Result = tag
            };
        }
    }
}
