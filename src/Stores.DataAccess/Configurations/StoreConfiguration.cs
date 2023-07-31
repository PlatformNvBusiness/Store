using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Configurations;

/// <summary>
/// The configuration for the store entity
/// </summary>
public class StoreConfiguration : IEntityTypeConfiguration<Store>
{

    /// <summary>
    /// Configuring the store entity 
    /// </summary>
    /// <param name="builder">The entity type builder </param>
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.Description)
            .IsRequired(false);
        builder.Property(x => x.Country)
            .IsRequired();
        builder.Property(x => x.AddressLineFirst)
            .IsRequired();
        builder.Property(x => x.AddreesLineSecond)
            .IsRequired(false);
      
        builder.Property(x => x.CreationDate)
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        builder.Property(x => x.UpdateDate)
            .ValueGeneratedOnUpdate()
            .Metadata.SetAfterSaveBehavior (PropertySaveBehavior.Save);

        builder.HasMany(store => store.WorkingHours)
            .WithOne(workingHour => workingHour.Store);
        builder.HasMany(store => store.Followers)
            .WithMany(follower => follower.Stores);
        builder.HasOne(store => store.Category)
            .WithMany(category => category.Stores);
        builder.HasOne(store => store.Policy)
            .WithOne(policy => policy.Store);
        builder.HasMany(store => store.Faqs)
            .WithOne(faq => faq.Store);

        builder.ToTable("Stores");
    }
}
