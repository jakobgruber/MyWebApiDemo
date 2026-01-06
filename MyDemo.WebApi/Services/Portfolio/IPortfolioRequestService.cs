using MyDemo.WebApi.Contracts;

namespace MyDemo.WebApi.Services.Portfolio;

public interface IPortfolioRequestService
{
    public Task<PortfolioResponse> GetCurrentPortfolio(IEnumerable<string> symbols);
}
