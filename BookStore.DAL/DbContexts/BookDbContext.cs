using BookStore.Model.Authors.Entities;
using BookStore.Model.Books.Entities;
using BookStore.Model.Comments.Entities;
using BookStore.Model.Orders.Entities;
using BookStore.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.DbContexts
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Comment> BookComments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(c => c.Price).HasPrecision(20,2);  
            modelBuilder.Entity<Order>().Property(c => c.Price).HasPrecision(20, 2);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasColumnType("datetime2");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasColumnType("datetime2");
            }
        }
    }
}
