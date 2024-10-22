using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.Entities;

namespace BookStore.BusinessLogic.Tags.Comments
{
    public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag, Tag>
    {
        public UpdateTagHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
        {
            Tag tag =  _context.Tags.SingleOrDefault(x => x.Id == request.Id);
            if (tag == null)
            {
                AddError($"The tag with ID {request.Id} was not recognized");
            }
            else
            {
                tag.TagName = request.TagName;
                await _context.SaveChangesAsync();
                AddResult(tag);
            }
        }
    }
}
