using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Utils;

namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

public class OpenWeatherMapMapper
{
    public static WeatherForecastResponse ToWeatherForecastResponse(OpenWeatherMapWeatherForecastResponse response)
    {
        ArgumentNullException.ThrowIfNull(response);
        var temp = ParseUtils.ConvertKelvinToCelsius(response.Main.Temp);
        var feelsLike = ParseUtils.ConvertKelvinToCelsius(response.Main.FeelsLike);

        return new(
            response.Name, temp, feelsLike, "Celsius"
        );
    }
}
