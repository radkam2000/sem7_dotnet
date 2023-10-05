namespace Zad_1;
internal class Fruit
{
    public String Name { get; set; }
    public Boolean IsSweet { get; set; }
    public Double Price { get; set; }

    public override string ToString()
    {
        return "Fruit: Name= " + Name + ", IsSweet=" + IsSweet + ", Price=" + Price.ToString("C2");
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