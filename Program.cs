using PiratesFeladat;
using System;

Ship BlackPearl = new Ship();
BlackPearl.FillShip();

Ship FlyingDutchman = new Ship();
FlyingDutchman.FillShip();

do
{
	Console.WriteLine(BlackPearl.ToString());
	Console.WriteLine();
	Console.WriteLine(FlyingDutchman.ToString());

	if (BlackPearl.Battle(FlyingDutchman))
	{
		Console.WriteLine("The Black Pearl won!");
	}
	else
	{
		Console.WriteLine("The Black Pearl lost!");
	}
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
} while ((!BlackPearl.Captian.Death && !FlyingDutchman.Captian.Death) && (BlackPearl.CrewSize() > 10 && FlyingDutchman.CrewSize() > 10));

Console.WriteLine(BlackPearl.ToString());
Console.WriteLine();
Console.WriteLine(FlyingDutchman.ToString());