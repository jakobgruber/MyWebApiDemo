namespace MyDemo.WebApi.Services.Portfolio.TwelveData;

public record TwelveDataStockInfoResponse
(
    string symbol, string name, string currency, string close, string datetime
);
