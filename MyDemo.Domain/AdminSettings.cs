using MyDemo.Domain;

namespace MyDemo.DataContext;

public record AdminSettings(IEnumerable<string> StockSymbols, WeatherLocation LocationForWeatherForecast);