using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspDotNetCoreEmpty.Models.Configuration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(x => x.CategoryName)
            .IsRequired();
    }
}
