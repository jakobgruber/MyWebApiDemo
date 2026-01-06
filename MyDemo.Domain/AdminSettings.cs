using MyDemo.Domain;

namespace MyDemo.DataContext;

public record AdminSettings(IEnumerable<String> stockSymbols, WeatherLocation locationForWeatherForecast);