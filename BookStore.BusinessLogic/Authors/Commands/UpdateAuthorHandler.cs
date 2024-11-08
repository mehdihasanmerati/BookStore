using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Authors.Commands;
using BookStore.Model.Authors.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Authors.Commands
{
    public class UpdateAuthorHandler : BaseApplicationServiceHandler<UpdateAuthor, Author>
    {
        public UpdateAuthorHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateAuthor request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (author == null)
            {
                AddError($"The author with ID {request.Id} not found!");
            }
            else
            {
                author.FirstName = request.FirstName;
                author.LastName = request.LastName;

                _context.Authors.Update(author);
                await _context.SaveChangesAsync();

                AddResult(author);
            }
        }
    }
}
