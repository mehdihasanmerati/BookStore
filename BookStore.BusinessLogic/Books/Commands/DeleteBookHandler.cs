using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Books.Commands;

namespace BookStore.BusinessLogic.Books.Commands
{
    public class DeleteBookHandler : BaseApplicationServiceHandler<DeleteBook, bool>
    {
        public DeleteBookHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null)
            {
                AddError($"The book with Id {request.Id} not found!");
                return;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            // اضافه کردن نتیجه به پاسخ در اینجا true یعنی حذف موفق
            AddResult(true);
        }
    }
}
