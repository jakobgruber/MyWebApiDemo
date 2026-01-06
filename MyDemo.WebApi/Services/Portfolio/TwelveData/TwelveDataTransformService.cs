using MyDemo.WebApi.Models;
using MyDemo.WebApi.Services.Portfolio.TwelveData;

namespace MyDemo.WebApi.Services.Portfolio;

public class TwelveDataTransformService
{
    public static PortfolioDto ToPortfolioDto(IEnumerable<TwelveDataStockInfoResponse> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        var stockDtos = items.Select(item =>
        {
            if (item is null || ParseString(item.close) == 0)
            {
                return null;
            }

            return new StockDto(
                info: $"{item.symbol} - {item.name}",
                currency: item.currency,
                value: ParseString(item.close),
                date: item.datetime
            );
        })
        .Where(item => item is not null)
        .ToList();

        return new PortfolioDto(stockDtos);
    }

    private static Decimal ParseString(String value)
    {
        return decimal.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : 0m;
    }
}
