using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BooksManagementApi.Models;

namespace BooksManagementApi.EfDbContext
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.DateCreated).HasDefaultValueSql("GETDATE()");
        }
    }
}