using Microsoft.Extensions.DependencyInjection;
using MyDemo.WebApi.Services.Portfolio;

namespace MyDemo.WebApi.Services;

public static class AddServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IPortfolioRequestService, TwelveDataRequestService>();
        return services;
    }
}
