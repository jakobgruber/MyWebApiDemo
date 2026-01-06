using MyDemo.Domain;
using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Controllers;

namespace MyDemo.WebApi.Services.WeatherForecast.OpenWeatherMap;

public class OpenWeatherMapRequestService : IWeatherForecastRequestService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly ILogger<OpenWeatherMapRequestService> _logger;
    public OpenWeatherMapRequestService(
        IHttpClientFactory httpClientFactory, 
        IConfiguration configuration,
        ILogger<OpenWeatherMapRequestService> logger
    )
    {
        _httpClient = httpClientFactory.CreateClient();
        var baseUrl = configuration["OpenWeatherMap:BaseUrl"] ?? throw new Exception("missing base url - OpenWeatherMap");
        _httpClient.BaseAddress = new Uri(baseUrl);
        _apiKey = configuration["OpenWeatherMap:ApiKey"] ?? throw new Exception("missing api key - OpenWeatherMap");

        _logger = logger;
    }

    public async Task<WeatherForecastResponse> GetWeatherForecastFor(WeatherLocation location)
    {
        var url = $"2.5/weather?lat={location.Latitude}&lon={location.Longitude}&appid={_apiKey}";
        var response = await _httpClient.GetFromJsonAsync<OpenWeatherMapWeatherForecastResponse>(url);

        _logger.LogInformation($"Requesting: {_httpClient.BaseAddress}{url}");
        return OpenWeatherMapTransformService.ToWeatherForecastResponse(response!);
    }
}
