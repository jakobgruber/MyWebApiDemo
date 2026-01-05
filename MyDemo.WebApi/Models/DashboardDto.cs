namespace MyDemo.WebApi.Models;

public record DashboardDto
(
    PortfolioDto portfolio
);

public record PortfolioDto
(
    IEnumerable<StockDto> stocks
);

public record StockDto(
    String info, String currency, Decimal value, String date
);