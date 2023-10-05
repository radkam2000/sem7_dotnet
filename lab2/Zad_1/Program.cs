using Zad_1;
using System.Linq;
List<Fruit> fruits = new List<Fruit>();
for (int i = 0; i < 15; i++)
{
    fruits.Add(Fruit.Create());
}

fruits.ForEach((fruit) => { Console.WriteLine(fruit.ToString()); });
var f = fruits.Where(x => x.IsSweet == true).OrderByDescending(x => x.Price);
Console.WriteLine("--------");
foreach (var fruit in f)
{
    Console.WriteLine(fruit.ToString());
}