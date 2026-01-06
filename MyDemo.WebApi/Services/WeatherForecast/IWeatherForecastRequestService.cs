using MyDemo.Domain;
using MyDemo.WebApi.Contracts;

namespace MyDemo.WebApi.Services.WeatherForecast;

public interface IWeatherForecastRequestService
{
    public Task<WeatherForecastResponse> GetWeatherForecastFor(WeatherLocation location);
}
