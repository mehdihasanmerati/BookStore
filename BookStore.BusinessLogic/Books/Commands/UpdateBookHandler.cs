using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Books.Commands;
using BookStore.Model.Books.Entities;

namespace BookStore.BusinessLogic.Books.Commands
{
    public class UpdateBookHandler : BaseApplicationServiceHandler<UpdateBook, Book>
    {
        private readonly IFileService _fileService;

        public UpdateBookHandler(BookDbContext context, IFileService fileService) : base(context)
        {
            _fileService = fileService;
        }

        protected override async Task HandleRequest(UpdateBook request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(t => t.Id == request.Id);

            if (book == null)
            {
                AddError($"The Book with Id {request.Id} not found!");
            }
            else
            {
                book.Name = request.Name;
                book.Description = request.Description ?? "";
                book.Author = request.Author;
                book.PublishDate = request.PublishDate;
                book.Price = request.Price;

                // اگر فایل تصویر جدیدی وجود دارد، آن را ذخیره کنید و مسیر را تنظیم کنید
                if (request.ImageFile != null)
                {
                    var imageUrl = await _fileService.SaveImageAsync(request.ImageFile);
                    book.ImageUrl = imageUrl;
                }
                else if (!string.IsNullOrEmpty(request.ImageUrl))
                {
                    // اگر فایلی برای آپلود جدید نبود، مسیر قبلی را حفظ کنید
                    book.ImageUrl = request.ImageUrl;
                }

                book.Tags = request.SelectedTags.Select(tagId => new BookTag { TagId = tagId }).ToList();

                _context.Books.Update(book);
                await _context.SaveChangesAsync();

                AddResult(book);
            }
        }
    }
}
