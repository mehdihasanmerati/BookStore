using BookStore.Model.Orders.DTO;
using BookStore.Model.Orders.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Orders
{
    public static class OrderQueryExtention
    {
        public static IQueryable<Order> WhererId(this IQueryable<Order> query, int id, int bookId)
        {
            return query.Where(t => t.Id == id && t.BookId == bookId);
        }

        public static IQueryable<Order> WhereOver(this IQueryable<Order> query, string customerEmail, int bookId)
        {
           
            if (!string.IsNullOrEmpty(customerEmail))
            {
                query = query.Where(x => x.CustomerEmail == customerEmail);
                query = query.Where(x => x.BookId == bookId);
            }

            return query;
        }

        public static async Task<List<GetOrderDto>> ToOrderQueryAsync(this IQueryable<Order> query)
        {
            return await query.Select(t => new GetOrderDto
            {
                Id = t.Id,
                BookId = t.BookId,
                CustomerEmail = t.CustomerEmail,
                OrderDate = t.OrderDate,
                Price = t.Price,
            }).ToListAsync();
        }

        public static async Task<GetOrderDto?> ToOrderSingleQueryAsync(this IQueryable<Order> query)
        {
            return await query.Select(t => new GetOrderDto
            {
                Id = t.Id,
                BookId = t.BookId,
                CustomerEmail = t.CustomerEmail,
                OrderDate = t.OrderDate,
                Price = t.Price,
            }).FirstOrDefaultAsync();
        }
    }
}
