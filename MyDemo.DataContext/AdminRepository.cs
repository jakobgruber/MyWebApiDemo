namespace MyDemo.DataContext;

public interface IAdminRepository
{
    public AdminSettings GetSettings();
    public void UpdateStockSymbols(IEnumerable<String> stockSymbols);
}

internal class AdminRepository : IAdminRepository
{
    private IEnumerable<String> _stockSymbols = ["TSLA" ,"AAPL" ,"GOOG"];

    public AdminSettings GetSettings()
    {
        return new(_stockSymbols);
    }

    public void UpdateStockSymbols(IEnumerable<String> stockSymbols)
    {
        _stockSymbols = stockSymbols.Where(s => s is not null).ToList();
    }
}
