namespace MyDemo.WebApi.Contracts;

public record DashboardResponse
(
    PortfolioResponse portfolio
);

public record PortfolioResponse
(
    IEnumerable<StockResponse> stocks
);

public record StockResponse(
    String info, String currency, Decimal value, String date
);