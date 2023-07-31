using Microsoft.EntityFrameworkCore;

namespace Stores.DataAccess;

/// <summary>
/// The store context
/// </summary>
public class StoreContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="StoreContext"/>
    /// </summary>
    /// <param name="options">The options of the database</param>
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        Database.Migrate();
    }

    /// <summary>
    /// Override the OnModelCreating Function to apply the configurations to the database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
    }
}
