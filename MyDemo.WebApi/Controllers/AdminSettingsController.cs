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
    public AdminSettings GetStockSymbols()
    {
        return _repository.GetSettings();
    }
}
