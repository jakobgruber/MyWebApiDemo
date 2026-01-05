using Microsoft.AspNetCore.Mvc;
using MyDemo.DataContext;

namespace MyDemo.WebApi.Controllers;

[Route("api/settings")]
[ApiController]
public class AdminSettingsController : ControllerBase
{
    private readonly IAdminRepository _repository;

    public AdminSettingsController(IAdminRepository repository)
    {
        _repository = repository; 
    }

    [HttpGet()]

    [ProducesResponseType(200, Type = typeof(AdminSettingsDto))]
    public AdminSettingsDto GetStockSymbols()
    {
        return _repository.GetSettings();
    }

    [HttpPut()]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult UpdateAdminSettings([FromBody]AdminSettingsDto adminSettings)
    {
        if (adminSettings is null || adminSettings.stockSymbols?.Any() == false)
        {
            return BadRequest();
        }

        _repository.SetStockSymbols(adminSettings.stockSymbols!);
        return Ok();
    }
}
