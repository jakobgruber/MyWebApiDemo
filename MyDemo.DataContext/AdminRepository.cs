namespace MyDemo.DataContext;

public interface IAdminRepository
{
    public AdminSettingsDto GetSettings();
    public void SetStockSymbols(IEnumerable<String> stockSymbols);
}

internal class AdminRepository : IAdminRepository
{
    private IEnumerable<String> _stockSymbols = ["TSLA" ,"AAPL" ,"GOOG"];

    public AdminSettingsDto GetSettings()
    {
        return new(_stockSymbols);
    }

    public void SetStockSymbols(IEnumerable<String> stockSymbols)
    {
        _stockSymbols = stockSymbols.Where(s => s is not null).ToList();
    }
}
