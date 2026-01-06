namespace MyDemo.WebApi.Utils;

public class ParseUtils
{
    public static decimal ParseStringToDecimal(string value)
    {
        return decimal.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : 0m;
    }

    public static decimal ConvertKelvinToCelsius(decimal kelvin)
    {
        return kelvin - 273.15m;
    }
}
