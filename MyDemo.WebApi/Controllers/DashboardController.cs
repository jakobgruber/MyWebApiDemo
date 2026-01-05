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
    public async Task<IActionResult> GetDashboardData()
    {
        var settings = _adminRepository.GetSettings();
        if (settings is null)
        {
            return NotFound();
        }
        
        var portfolioDto = await _portfolioRequestService.GetCurrentPortfolio(settings.StockSymbols);

        return Ok(new DashboardDto(portfolioDto));
    }
}
