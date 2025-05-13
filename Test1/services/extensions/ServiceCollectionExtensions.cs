using Test1.services.abstractions;

namespace Test1.services.extensions;

public static class ServiceCollectionExtensions
{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
}