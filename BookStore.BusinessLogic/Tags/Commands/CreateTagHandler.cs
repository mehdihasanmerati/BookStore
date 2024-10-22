using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.Entities;

namespace BookStore.BusinessLogic.Tags.Commands
{
    public class CreateTagHandler : BaseApplicationServiceHandler<CreateTag, Tag>
    {
        public CreateTagHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag
            {
                TagName = request.TagName
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            AddResult(tag);
        }
    }
}
