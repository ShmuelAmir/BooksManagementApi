using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BooksManagementApi.Models;

namespace BooksManagementApi.EfDbContext
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.ISBN).IsRequired();
            builder.Property(b => b.Title).IsRequired();
        }
    }
}