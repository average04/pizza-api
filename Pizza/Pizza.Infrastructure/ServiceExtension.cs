namespace Pizza.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}