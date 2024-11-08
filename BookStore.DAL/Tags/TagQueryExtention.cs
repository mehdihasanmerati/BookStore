using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Tags
{
   
    public static class TagQueryExtention
    {
        public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags, string tagName)
        {
            if(!string.IsNullOrEmpty(tagName))
            {
                tags = tags.Where(t => t.TagName.Contains(tagName));
            }
            return tags;
        }

        public static List<GetTagDto> ToTagQuery(this IQueryable<Tag> tags)
        {
            return tags.Select( c => new GetTagDto
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToList();
        }

        public static async Task<List<GetTagDto>> ToTagQueryAsync(this IQueryable<Tag> tags)
        {
            return await tags.Select(c => new GetTagDto
            {
                Id= c.Id,
                TagName = c.TagName,
            }).ToListAsync();
        }
    }
}
