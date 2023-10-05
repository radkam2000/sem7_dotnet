using System.Globalization;

public class MyFormatter
{
    public static string FormatUsdPrice(double price)
    {
        var usc = new CultureInfo("en-us");
        return price.ToString("C2", usc);
    }

    public static string FormatPlnPrice(double price)
    {
        var pl = new CultureInfo("pl-pl");
        return price.ToString("C2", pl);
    }
}
