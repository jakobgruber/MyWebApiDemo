namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class OpenWeatherMapWeatherForecastResponse
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    [Required]
    public OpenWeatherMapMainInfo Main { get; set; } = new();
}

public class OpenWeatherMapMainInfo
{
    // Temperature in Kelvin
    [JsonPropertyName("temp")]
    [Required]
    public decimal Temp { get; set; }

    [JsonPropertyName("feels_like")]
    [Required]
    public decimal FeelsLike { get; set; }
}

