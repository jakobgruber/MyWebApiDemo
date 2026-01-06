using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Utils;

namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

public class OpenWeatherMapMapper
{
    public static WeatherForecastResponse ToWeatherForecastResponse(OpenWeatherMapWeatherForecastResponse response)
    {
        ArgumentNullException.ThrowIfNull(response);
        var tempInCelsius = ParseUtils.ConvertFahrenheitToCelsius(response.Main.Temp);
        var feelsLikeInCelsius = ParseUtils.ConvertFahrenheitToCelsius(response.Main.FeelsLike);

        return new(
            response.Name, tempInCelsius, feelsLikeInCelsius
        );
    }
}
