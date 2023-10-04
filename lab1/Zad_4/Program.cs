var rand = new Random();
var value = rand.Next(1, 101);

var result = 0;
int guess = -1;

while (guess != value)
{
    Console.WriteLine("Podaj liczbę");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess < value)
    {
        result++;
        Console.WriteLine("Podana liczba jest za mała");
    }
    else if (guess > value)
    {
        result++;
        Console.WriteLine("Podana liczba jest za duża");
    }
    else
    {
        result++;
        Console.WriteLine("Wygrałeś w " + result + " ruchach");
    }

}

//////////////////