using MyDemo.WebApi.Services.Portfolio;
using MyDemo.WebApi.Services.WeatherForecast;
using MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

namespace MyDemo.WebApi.Services;

public static class RequestServicesExtensions
{
    public static IServiceCollection AddRequestServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IPortfolioRequestService, TwelveDataRequestService>();
        services.AddScoped<IWeatherForecastRequestService, OpenWeatherMapRequestService>();
        return services;
    }
}
