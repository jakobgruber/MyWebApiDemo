using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Services.Portfolio.TwelveData;

namespace MyDemo.WebApi.Services.Portfolio;

public class TwelveDataMapper
{
    public static PortfolioResponse ToPortfolioDto(IEnumerable<TwelveDataStockInfoResponse> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        var stockDtos = items.Select(item =>
        {
            if (item is null || ParseString(item.close) == 0)
            {
                return null;
            }

            return new StockResponse(
                info: $"{item.symbol} - {item.name}",
                currency: item.currency,
                value: ParseString(item.close),
                date: item.datetime
            );
        })
        .Where(item => item is not null)
        .ToList();

        return new PortfolioResponse(stockDtos!);
    }

    private static decimal ParseString(string value)
    {
        return decimal.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : 0m;
    }
}
