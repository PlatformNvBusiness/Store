using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Stores.BusinessLogic.Services;
using Stores.DataAccess.Extensions;
using Stores.Presentation.Profiles;

namespace Stores.Presentation.Extensions;

/// <summary>
/// The configuration of the services of the application
/// </summary>
public static partial class ApplicationDependenciesConfiguration
{

    /// <summary>
    /// Configure the services of the application
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddDatabase(options =>
            {
                options.UseExceptionProcessor();
                options.UseNpgsql(builder.Configuration.GetConnectionString("StoreService"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            })
            .AddRepositories()
            .AddAutoMapper(typeof(StoreProfile))
            .AddScoped<IStoreService, StoreService>()
            .AddScoped<IItemService, ItemService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<ICategoryTypeService, CategoryTypeService>()
            .AddAzureBlobService(builder.Configuration);

        return builder.Services;
    }

    /// <summary>
    /// Configuring the azure blob service
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAzureBlobService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddBlobServiceClient(configuration["StorageConnectionString:blob"], preferMsi: true);
            clientBuilder.AddQueueServiceClient(configuration["StorageConnectionString:queue"], preferMsi: true);
        });

        return services;
    }
}
