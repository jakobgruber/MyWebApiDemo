namespace MyDemo.WebApi.Services.Portfolio.TwelveData;

public record TwelveDataStockInfoResponse
(
    String symbol, String name, String currency, String close, String datetime
);
