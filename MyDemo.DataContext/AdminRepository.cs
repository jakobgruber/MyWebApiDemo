namespace MyDemo.DataContext;

public interface IAdminRepository
{
    public AdminSettings GetSettings();
    public void SetStockSymbols(String symbols);
}

internal class AdminRepository : IAdminRepository
{
    private IEnumerable<String> _stockSymbols = ["TSLA" ,"AAPL" ,"GOOG"];

    public AdminSettings GetSettings()
    {
        return new(_stockSymbols);
    }

    public void SetStockSymbols(String symbols)
    {
        _stockSymbols = symbols
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();
    }
}
