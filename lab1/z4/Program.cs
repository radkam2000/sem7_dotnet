using Zad_4;
using System.Text.Json;
var rand = new Random();
var value = rand.Next(1, 101);

var trials = 0;
int guess = -1;

while (guess != value)
{
    Console.WriteLine("Podaj liczbę");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess < value)
    {
        trials++;
        Console.WriteLine("Podana liczba jest za mała");
    }
    else
    {
        trials++;
        Console.WriteLine("Podana liczba jest za duża");
    }
}
trials++;
Console.WriteLine("Wygrałeś w " + trials + " ruchach");
Console.WriteLine("Podaj swoje imie:");
var name = Console.ReadLine();
var hs = new HighScore { Name = name, Trials = trials };
List<HighScore> highScores;
const string FileName = "highscores.json";

if (File.Exists(FileName))
    highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
else
    highScores = new List<HighScore>();
highScores.Add(hs);
File.WriteAllText(FileName, JsonSerializer.Serialize(highScores));
foreach (var item in highScores)
{
    Console.WriteLine($"{item.Name} -- {item.Trials} prób");
}

//////////////////