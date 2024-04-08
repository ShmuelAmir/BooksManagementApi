using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BooksManagementApi.Models;

namespace BooksManagementApi.EfDbContext
{
    public class ImaggaTagConfig : IEntityTypeConfiguration<ImaggaTag>
    {
        public void Configure(EntityTypeBuilder<ImaggaTag> builder)
        {
            builder.Property(t => t.Tag).IsRequired();
            builder.Property(t => t.Confidence).IsRequired();
        }
    }
}