using Serilog;
using Serilog.Sinks.Elasticsearch;
using Stores.BusinessLogic.Services;
using Stores.DataAccess.Extensions;
using Stores.Presentation.Profiles;

namespace Stores.Presentation.Extensions
{
    public static partial class ApplicationDependenciesConfiguration
    {
        public static IServiceCollection ConfigureServices(this WebApplicationBuilder application)
        {
            application.Services
                .AddDatabase(application.Configuration)
                .AddRepositories()
                .AddAutoMapper(typeof(StoreProfile))
                .AddScoped<IStoreService, StoreService>()
                .AddScoped<IItemService, ItemService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<ICategoryTypeService, CategoryTypeService>();

            return application.Services;
        }

        /// </summary>
        /// <param name="builder">The builder</param>
        /// <returns>A <see cref="WebApplication"/></returns>
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                 .Enrich.WithMachineName()
                 .WriteTo.Console()
                 .ReadFrom.Configuration(config);

                configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config["ElasticConfiguration:Uri"]))
                {
                    IndexFormat = $"{context.Configuration["ApplicationName"]} -logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1
                })
                   .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);
            });

            return builder;
        }
    }
}
