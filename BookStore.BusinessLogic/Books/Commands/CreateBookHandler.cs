using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Books.Commands;
using BookStore.Model.Books.Entities;
namespace BookStore.BusinessLogic.Books.Commands
{
    public class CreateBookHandler : BaseApplicationServiceHandler<CreateBook, Book>
    {
        public CreateBookHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateBook request, CancellationToken cancellationToken)
        {
            Book book = new Book
            {
                Name = request.Name,
                Author = request.Author,
                Description = request.Description,
                Price = request.Price,
                PublishDate = request.PublishDate,
                ImageUrl = request.ImageUrl,
                Tags = request.BookTags,
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            AddResult(book);
        }
    }
}
