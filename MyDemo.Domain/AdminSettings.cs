namespace MyDemo.Domain;

public record AdminSettings(IEnumerable<string> StockSymbols, WeatherLocation LocationForWeatherForecast);