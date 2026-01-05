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

    public DashboardController(IPortfolioRequestService portfolioRequestService,  IAdminRepository adminRepository)
    {
        _portfolioRequestService = portfolioRequestService;
        _adminRepository = adminRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(DashboardDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDashboardData()
    {
        var settings = _adminRepository.GetSettings();
        if (settings is null)
        {
            return NotFound(new { Message = "Can not load data for dashboard, admin settings are not configured."});
        }
        
        var portfolioDto = await _portfolioRequestService.GetCurrentPortfolio(settings.stockSymbols);

        return Ok(new DashboardDto(portfolioDto));
    }
}
