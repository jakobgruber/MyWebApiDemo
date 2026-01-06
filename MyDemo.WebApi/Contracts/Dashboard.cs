namespace MyDemo.WebApi.Contracts;

public record DashboardResponse
(
    PortfolioResponse portfolio
);

public record PortfolioResponse
(
    IEnumerable<StockResponse> stocks
);

public record StockResponse
(
    string info, string currency, decimal value, string date
);

public record WeatherForecastResponse
(
    string nameOfLocation, decimal temperatureInCelsius, decimal feelsLikeInCelsius
);