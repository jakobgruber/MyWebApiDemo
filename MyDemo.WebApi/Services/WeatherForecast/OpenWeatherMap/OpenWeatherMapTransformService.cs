using MyDemo.WebApi.Contracts;

namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

public class OpenWeatherMapTransformService
{
    public static WeatherForecastResponse ToWeatherForecastResponse(OpenWeatherMapWeatherForecastResponse response)
    {
        ArgumentNullException.ThrowIfNull(response);

        return new(
            response.Name, FahrenheitToCelsius(response.Main.Temp), response.Main.FeelsLike
        );
    }

    private static decimal FahrenheitToCelsius(decimal fahrenheit)
    {
        return (fahrenheit - 32m) * 5m / 9m;
    }
}
