using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.Entities;
using MediatR;

namespace BookStore.BusinessLogic.Tags.Comments
{
    public class UpdateTagHandler : IRequestHandler<UpdateTag, ApplicationServiceResponse<Tag>>
    {
        private readonly BookDbContext _context;

        public UpdateTagHandler(BookDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationServiceResponse<Tag>> Handle(UpdateTag request, CancellationToken cancellationToken)
        {
            ApplicationServiceResponse<Tag> response = new();

            Tag tag =  _context.Tags.SingleOrDefault(x => x.Id == request.Id);
            if (tag == null)
            {
                response.AddError($"The tag with ID {request.Id} was not recognized");
            }
            else
            {
                tag.TagName = request.TagName;
                await _context.SaveChangesAsync();
                response.Result = tag;
            }
            return response;
        }
    }
}
