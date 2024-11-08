using BookStore.Model.Authors.DTO;
using BookStore.Model.Authors.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Authors
{
    public static class AuthorQueryExtention
    {
        public static IQueryable<Author> WhereId(this IQueryable<Author> authors, int id)
        {
            return authors.Where(a => a.Id == id);
        }
        public static IQueryable<Author> WhereOver(this IQueryable<Author> authors, string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                authors = authors.Where(t => t.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                authors = authors.Where(t => t.LastName.Contains(lastName));
            }
            return authors;
        }

        public static async Task<List<GetAuthorDto>> ToAuthorQueryAsync(this IQueryable<Author> authors)
        {
            return await authors.Select(c => new GetAuthorDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToListAsync();
        }

        public static async Task<GetAuthorDto?> ToAuthorQuerySingleAsync(this IQueryable<Author> authors)
        {
            return await authors.Select(t => new GetAuthorDto
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
            }).FirstOrDefaultAsync();
        }
    }
}
