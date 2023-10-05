using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiratesFeladat
{
	internal class Pirate
	{
		private int intoxication;
		private bool passout;
		private bool death;		

		public Pirate()
		{
			this.intoxication = 0;
			this.death = false;
			this.passout = false;
		}

		public bool Death { get => death;}

		public int Intoxication { get => intoxication;}

		public bool Passout { get => passout; set => passout = value; }

		public int Random(int min, int max)
		{
			Random rnd = new Random();
			return rnd.Next(min, max+1);
		}

		public void DrinkSomeRum()
		{
			if(death)
			{
                Console.WriteLine("He's dead.");
            }
			else if(passout)
			{
                Console.WriteLine("He's passed out.");
            }
			else
			{
				intoxication++;
			}			
		}

		public void DrinkSomeRum2()
		{
			
			if (intoxication > 0 && this.passout)
			{
				intoxication -= 2;
			}
			else if (intoxication > 3 && !this.passout)
			{
				this.passout = true;
			}
			else
			{
				this.passout = false;
				intoxication++;
			}
		}
		
		public void HowsItGoingMate()
		{
			if(death)
			{
				Console.WriteLine("He's dead.");
			}
			else
			{
				if (intoxication < 4)
				{
					Console.WriteLine("Pour me anudder!");
				}
				else
				{
					Console.WriteLine("Arghh, I'ma Pirate. How d'ya d'ink its goin?");
					intoxication = 0;
					passout = true;
				}
			}			
		}

		public void Die()
		{
			death = true;
		}

		public void Fight(Pirate enemy)
		{
			if (death)
			{
				Console.WriteLine("He's dead.");
			}
			else
			{
				int result = Random(0, 2);
				if (result == 0)
				{
					Console.WriteLine("He won!");
					enemy.Die();
				}
				else if(result == 1)
				{
                    Console.WriteLine("He lost!");
					this.Die();
                }
				else
				{
                    Console.WriteLine("They both passed out!");
					this.Passout = true;
					enemy.Passout = true;
				}
			}
		}

		public string Status()
		{
			if (death)
			{
				return "Dead";
			}
			else if(passout)
			{
				return "Passed out";
			}
			else
			{
				return "Ready";
			}
		}
	}
}
