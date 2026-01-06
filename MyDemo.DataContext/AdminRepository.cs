using MyDemo.Domain;

namespace MyDemo.DataContext;

public interface IAdminRepository
{
    public AdminSettings GetSettings();
    public void UpdateStockSymbols(IEnumerable<String> stockSymbols);
    public void UpdateLocationForWeatherForecast(WeatherLocation location);
}

internal class AdminRepository : IAdminRepository
{
    private IEnumerable<String> _stockSymbols = ["TSLA" ,"AAPL" ,"GOOG"];
    private WeatherLocation _locationForWeatherForecast = new(48.2167m, 16.3m); // 1160 Wien, Ottakring

    public AdminSettings GetSettings()
    {
        return new(_stockSymbols, _locationForWeatherForecast);
    }

    public void UpdateStockSymbols(IEnumerable<String> stockSymbols)
    {
        _stockSymbols = stockSymbols.Where(s => s is not null).ToList();
    }

    public void UpdateLocationForWeatherForecast(WeatherLocation location)
    {
        _locationForWeatherForecast = location;
    }
}
