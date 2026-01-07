namespace MyDemo.WebApi.Contracts;

public record DashboardResponse
(
    PortfolioResponse Portfolio, WeatherForecastResponse WeatherForecast
);

public record PortfolioResponse
(
    IEnumerable<StockResponse> Stocks
);

public record StockResponse
(
    string Info, string Currency, decimal Value, string Date
);

public record WeatherForecastResponse
(
    string NameOfLocation, decimal Temperature, decimal FeelsLike, string TemperatureUnit
);