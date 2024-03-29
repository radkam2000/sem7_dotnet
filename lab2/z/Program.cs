﻿using System.Globalization;
using Zad_1;
UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();

List<Fruit> fruits = new List<Fruit>();
for (int i = 0; i < 15; i++)
{
    fruits.Add(Fruit.Create());
}

fruits.ForEach((fruit) => { Console.WriteLine(fruit.ToString()); });
var f = fruits.Where(x => x.IsSweet == true).OrderByDescending(x => x.Price);
Console.WriteLine("--------");
Console.WriteLine(UsdCourse.Current.ToString());
foreach (var fruit in f)
{
    Console.WriteLine(fruit.ToString());
}