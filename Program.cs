using PiratesFeladat;
using System;

Ship s1 = new Ship();
s1.FillShip();

Ship s2 = new Ship();
s2.FillShip();

do
{
	Console.WriteLine(s1.ToString());
	Console.WriteLine();
	Console.WriteLine(s2.ToString());

	if (s1.Battle(s2))
	{
		Console.WriteLine("s1 won!");
	}
	else
	{
		Console.WriteLine("s1 lost!");
	}
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
} while (!s1.Captian.Death && !s2.Captian.Death && s1.Crew.Count() > 10 && s2.Crew.Count() > 10);

Console.WriteLine(s1.ToString());
Console.WriteLine();
Console.WriteLine(s2.ToString());