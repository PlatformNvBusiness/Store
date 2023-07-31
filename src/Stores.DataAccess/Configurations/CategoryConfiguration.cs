using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Configurations;

/// <summary>
/// Configuration for the entity category
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{

    /// <summary>
    /// Configuration for the entity category
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.Name)
            .IsUnique();
    }
}
