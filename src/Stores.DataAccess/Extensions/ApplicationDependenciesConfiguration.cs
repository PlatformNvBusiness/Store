using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.DataAccess.Extensions
{
    public static class ApplicationDependenciesConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            return services
                    .AddDbContextPool<StoreContext>(options =>
                    {
                        options.UseExceptionProcessor();
                        options.UseNpgsql(config.GetConnectionString("Default"));
                        options.EnableSensitiveDataLogging();
                        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    })
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
}
