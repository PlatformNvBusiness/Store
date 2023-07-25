using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}
