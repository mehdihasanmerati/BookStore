using BookStore.Model.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Books
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Author).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ImageUrl).IsRequired();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(200);
        }
    }
}
