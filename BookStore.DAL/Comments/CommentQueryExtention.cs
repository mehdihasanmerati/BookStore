using BookStore.Model.Comments.DTO;
using BookStore.Model.Comments.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Comments
{
    public static class CommentQueryExtention
    {

        public static IQueryable<Comment> WhereId(this IQueryable<Comment> query, int id, int bookId)
        {
            return query.Where(t => t.Id == id && t.BookId == bookId);
        }

        public static IQueryable<Comment> WhereOver(this IQueryable<Comment> query, string bookComment, int bookId)
        {
            

            if (!string.IsNullOrEmpty(bookComment))
            {
                query = query.Where(t => t.BookComment.Contains(bookComment));
                query = query.Where(t => t.BookId == bookId);
            }
            return query;
        }

        public static List<GetCommentDto> ToCommentQuery(this IQueryable<Comment> query)
        {
            return query.Select(t => new GetCommentDto
            {
                Id = t.Id,
                BookComment = t.BookComment,
                CommentBy = t.CommentBy,
                IsValid = t.IsValid,
                CommentDate = t.CommentDate,
            }).ToList();
        }

        public static async Task<List<GetCommentDto>> ToCommentQueryAsync(this IQueryable<Comment> query)
        {
            return await query.Select(t => new GetCommentDto
            {
                Id = t.Id,
                BookComment = t.BookComment,
                CommentBy = t.CommentBy,
                IsValid = t.IsValid,
                CommentDate = t.CommentDate,
                BookId = t.BookId,
            }).ToListAsync();
        }

        public static async Task<GetCommentDto?> ToCommentQuerySingleAsync(this IQueryable<Comment> query)
        {
            return await query.Select(t => new GetCommentDto
            {
                Id = t.Id,
                BookComment = t.BookComment,
                CommentBy = t.CommentBy,
                IsValid = t.IsValid,
                CommentDate = t.CommentDate,
                BookId = t.BookId,
            }).FirstOrDefaultAsync();
        }
    }
}
