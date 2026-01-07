using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDemo.DataContext;
using MyDemo.Domain;
using MyDemo.WebApi.Constants;
using MyDemo.WebApi.Contracts;

namespace MyDemo.WebApi.Controllers;

[Authorize(Roles = Roles.Admin)]
[Route("api/settings")]
[ApiController]
public class AdminSettingsController : ControllerBase
{
    private readonly IAdminRepository _repository;
    private readonly ILogger<AdminSettingsController> _logger;

    public AdminSettingsController(IAdminRepository repository, ILogger<AdminSettingsController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet()]
    [ProducesResponseType(200, Type = typeof(AdminSettings))]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [EndpointDescription("Returns admin settings which are used by [GET /api/dashboard] to request data.")]
    public AdminSettings GetStockSymbols()
    {
        return _repository.GetSettings();
    }

    [HttpPut("stock")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [EndpointDescription("Updates stock symbols for which stock data should be requested. See [GET /api/dahsboard] endpoint to get stock data for the new stock symbols.")]
    public ActionResult UpdateStockSymbols([FromBody] IEnumerable<string> stockSymbols)
    {
        if (stockSymbols?.Any() == false)
        {
            _logger.LogError("UpdateStockSymbols failed - invalid data");
            return BadRequest();
        }

        _repository.UpdateStockSymbols(stockSymbols!);
        _logger.LogInformation("StockSymbols updated");
        return Ok();
    }

    [HttpPut("weather")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [EndpointDescription("Updates location for which the weater forecast should be requested. See [GET /api/dahsboard] endpoint to get weather forecast for the new location.")]
    public ActionResult UpdateLocationForWeatherForecast([FromBody] UpdateWeatherLocationRequest location)
    {
        WeatherLocation newLocation = new(location.Latitude, location.Longitude);
        _repository.UpdateLocationForWeatherForecast(newLocation);
        _logger.LogInformation("WeatherForecast updated");
        return Ok();
    }
}
