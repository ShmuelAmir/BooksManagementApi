using Microsoft.EntityFrameworkCore;
using BooksManagementApi.EfDbContext;

namespace BooksManagementApi.Models
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; } // remove if not used
        public DbSet<ImaggaTag> ImaggaTags { get; set; } // remove if not used

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new ImaggaTagConfig());
        }
    }
}
