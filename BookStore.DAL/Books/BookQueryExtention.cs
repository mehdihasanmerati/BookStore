using BookStore.Model.Books.DTO;
using BookStore.Model.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Books
{
    public static class BookQueryExtention
    {
        // این متد اکستنشن یک کوئری آبجکت هست برای اینکه هم در اپلیکیشن سرویس یعنی GetBookHandler کد کمتری بنویسیم
        // و هم ممکن است عملیات search یا OrderBy  و غیره را انجام دهیم و تغییراتی بوجود آوریم
        // بدون اینکه مجبور باشیم داخل اپلیکیشن سرویس این کار را انجام دهیم
        public static IQueryable<Book> WhereOver(this IQueryable<Book> books, string bookName, string authorName)
        {
            if (!string.IsNullOrEmpty(bookName))
            {
                books = books.Where(t => t.Name.Contains(bookName));
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                books = books.Where(t => t.Author.Contains(authorName));
            }
            
            return books;
        }
        public static List<GetBookDto> ToBookQuery(this IQueryable<Book> books)
        {
            return books.Select(t => new GetBookDto
            {
                Id = t.Id,
                Name = t.Name,
                Author = t.Author,
                Description = t.Description,
                Price = t.Price,
                ImageUrl = t.ImageUrl,
                PublishDate = t.PublishDate,
            }).ToList();
        }
        public static async Task <List<GetBookDto>> ToBookQueryAsync(this IQueryable<Book> books)
        {
            return await books.Select(t => new GetBookDto
            {
                Id = t.Id,
                Name = t.Name,
                Author = t.Author,
                Description = t.Description,
                Price = t.Price,
                ImageUrl = t.ImageUrl,
                PublishDate = t.PublishDate,
            }).ToListAsync();
        }
    }
}
