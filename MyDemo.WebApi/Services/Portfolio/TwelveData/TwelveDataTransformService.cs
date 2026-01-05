using MyDemo.WebApi.Models;
using MyDemo.WebApi.Services.Portfolio.TwelveData;

namespace MyDemo.WebApi.Services.Portfolio;

public class TwelveDataTransformService
{
    public PortfolioDto ToPortfolioDto(IEnumerable<TwelveDataStockInfoResponse> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        var stockDtos = items.Select(item =>
        {
            return new StockDto(
                info: $"{item.symbol} - {item.name}",
                currency: item.currency,
                value: ParseString(item.open),
                date: item.datetime
            );
        });

        return new PortfolioDto(stockDtos);
    }

    private Decimal ParseString(String value)
    {
        return decimal.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : 0m;
    }
}
