using MyDemo.Domain;

namespace MyDemo.DataContext;

public record AdminSettings(IEnumerable<string> stockSymbols, WeatherLocation locationForWeatherForecast);