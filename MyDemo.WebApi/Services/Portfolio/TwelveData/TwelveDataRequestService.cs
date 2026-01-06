using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Services.Portfolio.TwelveData;

namespace MyDemo.WebApi.Services.Portfolio;

public class TwelveDataRequestService: IPortfolioRequestService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public TwelveDataRequestService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        var baseUrl = configuration["TwelveData:BaseUrl"] ?? throw new Exception("missing base url - Twelve Data");
        _httpClient.BaseAddress = new Uri(baseUrl);
        _apiKey = configuration["TwelveData:ApiKey"] ?? throw new Exception("missing api key - Twelve Data");
    }

    public async Task<PortfolioResponse> GetCurrentPortfolio(IEnumerable<string> symbols)
    {
        ArgumentNullException.ThrowIfNull(symbols);

        var tasks = symbols.Select(async symbol =>
        {
            // instead of multiple requests you can use the bulk quote endpoint,
            // but I wanted to try out parsing of multiple requests
            return await _httpClient.GetFromJsonAsync<TwelveDataStockInfoResponse>($"quote?symbol={symbol}&apikey={_apiKey}");
        });

        var items = (await Task.WhenAll(tasks))
            .Where(dto => dto is not null)
            .ToList();

        return TwelveDataTransformService.ToPortfolioDto(items!);
    }
}
