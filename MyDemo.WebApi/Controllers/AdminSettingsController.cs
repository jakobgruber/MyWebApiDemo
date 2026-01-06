using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDemo.DataContext;
using MyDemo.WebApi.Constants;

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
    public AdminSettings GetStockSymbols()
    {
        return _repository.GetSettings();
    }

    [HttpPut()]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult UpdateAdminSettings([FromBody]AdminSettings adminSettings)
    {
        if (adminSettings is null || adminSettings.stockSymbols?.Any() == false)
        {
            _logger.LogError("UpdateAdminSettings failed - invalid data");
            return BadRequest();
        }

        _repository.SetStockSymbols(adminSettings.stockSymbols!);
        _logger.LogInformation("AdminSettings updated");
        return Ok();
    }
}
