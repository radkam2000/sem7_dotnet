using System.Globalization;

namespace Zad_1;
internal class Fruit
{
    public String Name { get; set; }
    public Boolean IsSweet { get; set; }
    public Double Price { get; set; }
    public Double UsdPrice => Price / UsdCourse.Current;

    public override string ToString()
    {
        return "Fruit: Name= " + Name + ", IsSweet=" + IsSweet + ", Price (PLN)=" + MyFormatter.FormatPlnPrice(Price) + ", Price (USD)=" + MyFormatter.FormatUsdPrice(UsdPrice);
    }
    public static Fruit Create()
    {
        Random r = new Random();
        string[] names = new string[] { "Apple", "Banana", "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };

        return new Fruit
        {
            Name = names[r.Next(names.Length)],
            IsSweet = r.NextDouble() > 0.5,
            Price = r.NextDouble() * 10
        };
    }
}