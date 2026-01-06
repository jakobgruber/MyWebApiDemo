using MyDemo.WebApi.Services.Portfolio;
using MyDemo.WebApi.Services.WeatherForecast;
using MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

namespace MyDemo.WebApi.Services;

public static class AddServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IPortfolioRequestService, TwelveDataRequestService>();
        services.AddScoped<IWeatherForecastRequestService, OpenWeatherMapRequestService>();
        return services;
    }
}
