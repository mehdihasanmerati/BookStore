using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.Entities;
using MediatR;

namespace BookStore.BusinessLogic.Tags.Comments
{
    public class DeleteTagHandler : IRequestHandler<DeleteTag, ApplicationServiceResponse>
    {
        private readonly BookDbContext _context;

        public DeleteTagHandler(BookDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationServiceResponse> Handle(DeleteTag request, CancellationToken cancellationToken)
        {
            ApplicationServiceResponse responce = new();

            var tag = await _context.Tags.FindAsync(request.TagId);
            if (tag == null)
            {
                responce.AddError($"The tag with {request.TagId} not found!");
                return responce;
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync(cancellationToken);

            return responce;
        }
    }
}
