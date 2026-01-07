using MyDemo.Domain;

namespace MyDemo.DataContext;

public interface IAdminRepository
{
    public AdminSettings GetSettings();
    public void UpdateStockSymbols(IEnumerable<string> stockSymbols);
    public void UpdateLocationForWeatherForecast(WeatherLocation location);
}
