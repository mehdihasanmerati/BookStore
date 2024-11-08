using BookStore.BusinessLogic.Frameworks;
using BookStore.DAL.DbContexts;
using BookStore.Model.Books.DTO;
using BookStore.Model.Books.Queries;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BusinessLogic.Books.Queries
{
    public class GetBookByIdHandler : BaseApplicationServiceHandler<GetBookByIdQuery, GetBookDto>
    {
        public GetBookByIdHandler(BookDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            // بارگذاری کتاب به همراه تگ‌ها
            var book = await _context.Books
                .Include(b => b.Tags)  // بارگذاری ارتباطات تگ‌ها
                .ThenInclude(bt => bt.Tag)  // بارگذاری خود تگ‌ها
                .FirstOrDefaultAsync(b => b.Id == request.Id);

            // بررسی اینکه کتاب پیدا شده باشد
            if (book == null)
            {
                AddError($"The tag with {request.Id} not found!");
                return;
            }

            // ساخت GetBookDto با استفاده از اطلاعات کتاب و شناسه‌های تگ‌ها
            var result = new GetBookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                PublishDate = book.PublishDate,
                SelectedTags = book.Tags.Select(bt => bt.TagId).ToList() // اختصاص دادن شناسه‌های تگ‌ها
            };

            AddResult(result);
        }
    }
}
