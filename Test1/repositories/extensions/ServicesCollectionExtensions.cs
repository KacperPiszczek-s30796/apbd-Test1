using Test1.repositories.abstractions;

namespace Test1.repositories.extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
        services.AddScoped<ItaskRepository, TaskRepository>();
        return services;
    }
}