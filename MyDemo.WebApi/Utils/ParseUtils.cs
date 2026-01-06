namespace MyDemo.WebApi.Utils;

public class ParseUtils
{
    public static decimal ParseStringToDecimal(string value)
    {
        return decimal.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : 0m;
    }

    public static decimal ConvertFahrenheitToCelsius(decimal fahrenheit)
    {
        return (fahrenheit - 32m) * 5m / 9m;
    }
}
