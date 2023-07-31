using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Configurations;

/// <summary>
/// The configuration for the category type 
/// </summary>
public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
{

    /// <summary>
    /// Configuring the category type entity
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<CategoryType> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.Name)
            .IsUnique();
    }
}
