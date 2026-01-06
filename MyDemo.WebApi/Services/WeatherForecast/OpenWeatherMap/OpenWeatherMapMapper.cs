using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Utils;

namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

public class OpenWeatherMapMapper
{
    public static WeatherForecastResponse ToWeatherForecastResponse(OpenWeatherMapWeatherForecastResponse response)
    {
        ArgumentNullException.ThrowIfNull(response);
        var tempInCelsius = ParseUtils.ConvertKelvinToCelsius(response.Main.Temp);
        var feelsLikeInCelsius = ParseUtils.ConvertKelvinToCelsius(response.Main.FeelsLike);

        return new(
            response.Name, tempInCelsius, feelsLikeInCelsius
        );
    }
}
