using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.DataAccess.Extensions;

/// <summary>
/// The class to add all the dependencies to the application 
/// </summary>
public static class ApplicationDependenciesConfiguration
{

    /// <summary>
    /// Add The database dependencies to the services of the application
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="config">The configuration</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
    {
        return services
                .AddDbContextPool<StoreContext>(options)
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Store>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Category>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Commentary>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<CommentaryType>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Faq>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Follower>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Item>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<ItemVariation>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<CategoryType>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Like>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<Policy>())
                .AddScoped(serviceProvider => serviceProvider.GetRequiredService<StoreContext>().Set<WorkingHour>());
    }

    /// <summary>
    /// Add The repositories to the D.I container
    /// </summary>
    /// <param name="services">The services </param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
                .AddScoped<IStoreRepository, StoreRepository>()
                .AddScoped<IItemRepository, ItemRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ICategoryTypeRepository, CategoryTypeRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
