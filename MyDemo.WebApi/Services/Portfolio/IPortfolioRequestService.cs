using MyDemo.WebApi.Models;

namespace MyDemo.WebApi.Services.Portfolio;

public interface IPortfolioRequestService
{
    public Task<PortfolioDto> GetCurrentPortfolio(IEnumerable<String> symbols);
}
