using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Authors.Commands;
using BookStore.Model.Authors.Entities;

namespace BookStore.BusinessLogic.Authors.Commands
{
    public class CreateAuthorHandler : BaseApplicationServiceHandler<CreateAuthor, Author>
    {
        public CreateAuthorHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateAuthor request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            AddResult(author);
        }
    }
}
