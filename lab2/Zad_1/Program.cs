using Zad_1;

List<Fruit> fruits = new List<Fruit>();
for (int i = 0; i < 15; i++)
{
    fruits.Add(Fruit.Create());
}

fruits.ForEach((fruit) => { Console.WriteLine(fruit.ToString()); });