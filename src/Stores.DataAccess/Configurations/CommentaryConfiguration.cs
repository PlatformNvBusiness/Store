using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Configurations;

/// <summary>
/// The configuration for the Commentary entity
/// </summary>
public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
{

    /// <summary>
    /// Configuring the entity commentary
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Commentary> builder)
    {
        builder.HasKey(x => x.Id);
     
        builder.ToTable("Commentaries");
    }
}
