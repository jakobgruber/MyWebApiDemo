using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDemo.DataContext;
using MyDemo.WebApi.Contracts;
using MyDemo.WebApi.Services.Portfolio;
using MyDemo.WebApi.Services.WeatherForecast;

namespace MyDemo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IPortfolioRequestService _portfolioRequestService;
    private readonly IWeatherForecastRequestService _weatherForeccastRequestService;
    private readonly IAdminRepository _adminRepository;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(
        IPortfolioRequestService portfolioRequestService,
        IWeatherForecastRequestService weatherForeccastRequestService,
        IAdminRepository adminRepository, 
        ILogger<DashboardController> logger
    )
    {
        _portfolioRequestService = portfolioRequestService;
        _weatherForeccastRequestService = weatherForeccastRequestService;
        _adminRepository = adminRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(DashboardResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDashboardData()
    {
        var settings = _adminRepository.GetSettings();
        if (settings is null)
        {
            _logger.LogError("Loading data for dashboard failed - no admin settings");
            return StatusCode(500, new { Message = "Can not load data for dashboard, admin settings are not configured."});
        }
        
        var portfolioTask = _portfolioRequestService.GetCurrentPortfolio(settings.StockSymbols);
        var weatherForecastTask = _weatherForeccastRequestService.GetWeatherForecastFor(settings.LocationForWeatherForecast);

        await Task.WhenAll(portfolioTask, weatherForecastTask);

        return Ok(new DashboardResponse(portfolioTask.Result, weatherForecastTask.Result));
    }
}
