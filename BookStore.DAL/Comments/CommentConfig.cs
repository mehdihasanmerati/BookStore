using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookStore.Model.Comments.Entities;

namespace BookStore.DAL.Comments
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.CommentBy).HasMaxLength(50);
            builder.Property(x => x.BookComment).HasMaxLength(200);
        }
    }
}
