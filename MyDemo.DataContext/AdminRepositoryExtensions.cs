using Microsoft.Extensions.DependencyInjection;

namespace MyDemo.DataContext;

public static class AdminRepositoryExtensions
{
    public static IServiceCollection AddAdminRepository(this IServiceCollection services)
    {
        // current AdminRepository stores data in memory, so we have to use AddSingleton otherwise the update methods will not work
        // when using a real database, change scope!!!
        services.AddSingleton<IAdminRepository, AdminRepository>();
        return services;
    }
}
