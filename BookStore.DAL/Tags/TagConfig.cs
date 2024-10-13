using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookStore.Model.Tags.Entities;

namespace BookStore.DAL.Tags
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.TagName).IsRequired().HasMaxLength(50);
        }
    }
}
