using Microsoft.Extensions.DependencyInjection;

namespace MyDemo.DataContext;

public static class AddAdminRepositoryExtension
{
    public static IServiceCollection AddMyDemoDataContext(this IServiceCollection services)
    {
        services.AddScoped<IAdminRepository, AdminRepository>();
        return services;
    }
}
