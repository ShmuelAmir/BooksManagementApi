using Microsoft.EntityFrameworkCore;

namespace BooksManagementApi.Models
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define primary keys
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ImaggaTag>()
                .HasKey(t => t.Id);

            // define relationships
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Comments)
                .WithOne()
                .HasForeignKey("BookISBN");

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Tags)
                .WithMany();
        }
    }
}
