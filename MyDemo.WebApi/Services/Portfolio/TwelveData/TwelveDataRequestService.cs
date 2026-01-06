using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Services.Portfolio.TwelveData;

namespace MyDemo.WebApi.Services.Portfolio;

public class TwelveDataRequestService: IPortfolioRequestService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly ILogger<TwelveDataRequestService> _logger;

    public TwelveDataRequestService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        ILogger<TwelveDataRequestService> logger
    )
    {
        _httpClient = httpClientFactory.CreateClient();
        var baseUrl = configuration["TwelveData:BaseUrl"] ?? throw new Exception("missing base url - TwelveData");
        _httpClient.BaseAddress = new Uri(baseUrl);
        _apiKey = configuration["TwelveData:ApiKey"] ?? throw new Exception("missing api key - TwelveData");

        _logger = logger;
    }

    public async Task<PortfolioResponse> GetCurrentPortfolio(IEnumerable<string> symbols)
    {
        ArgumentNullException.ThrowIfNull(symbols);

        var tasks = symbols.Select(async symbol =>
        {
            // instead of multiple requests you can use the bulk quote endpoint,
            // but I wanted to try out parsing of multiple requests

            var url = $"quote?symbol={symbol}&apikey={_apiKey}";
            _logger.LogInformation($"Requesting: {_httpClient.BaseAddress}{url}");

            return await _httpClient.GetFromJsonAsync<TwelveDataStockInfoResponse>(url);
        });

        var items = (await Task.WhenAll(tasks))
            .Where(dto => dto is not null)
            .ToList();

        return TwelveDataMapper.ToPortfolioDto(items!);
    }
}
