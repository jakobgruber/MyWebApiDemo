using Microsoft.AspNetCore.Mvc;
using MyDemo.DataContext;
using MyDemo.WebApi.Models;
using MyDemo.WebApi.Services.Portfolio;

namespace MyDemo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    IPortfolioRequestService _portfolioRequestService;
    IAdminRepository _adminRepository;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(IPortfolioRequestService portfolioRequestService,  IAdminRepository adminRepository, ILogger<DashboardController> logger)
    {
        _portfolioRequestService = portfolioRequestService;
        _adminRepository = adminRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(DashboardDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDashboardData()
    {
        var settings = _adminRepository.GetSettings();
        if (settings is null)
        {
            _logger.LogError("Loading data for dashboard failed - no admin settings");
            return NotFound(new { Message = "Can not load data for dashboard, admin settings are not configured."});
        }
        
        var portfolioDto = await _portfolioRequestService.GetCurrentPortfolio(settings.stockSymbols);

        return Ok(new DashboardDto(portfolioDto));
    }
}
