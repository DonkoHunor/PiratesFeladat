using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiratesFeladat
{
	internal class Ship
	{
		private Pirate captian;
		private List<Pirate> crew;

		public Ship()
		{
			this.crew = new List<Pirate>();
		}

		internal Pirate Captian { get => captian; set => captian = value; }
		internal List<Pirate> Crew { get => crew; set => crew = value; }

		public int Random(int min, int max)
		{
			Random rnd = new Random();
			return rnd.Next(min, max + 1);
		}

		public void FillShip()
		{
			this.captian = new Pirate();
			int j = Random(10, 113);
			for (int i = 0; i < j; i++)
			{
				this.crew.Add(new Pirate());
			}
		}

		public int Score()
		{
			int score = 0;

			if (!this.captian.Death && !this.captian.Passout)
			{
				score += 5;
			}
			else if(this.captian.Passout)
			{
				score -= 10;
			}

            foreach (Pirate p in crew)
            {
				if (!p.Death && !p.Passout)
				{
					score++;
				}
				else if(p.Passout)
				{
					score--;
				}
			}

			return score;
        }

		public void Lose()
		{
			if(Random(1,20) < 4)
			{
				this.captian.Die();
			}
			for (int i = 0; i < Random(0,this.crew.Count()); i++)
			{
				this.crew[Random(0, this.crew.Count()-1)].Die();
			}
		}

		public bool Battle(Ship enemy)
		{
			bool won = false;

			if(this.Score() > enemy.Score())
			{
				won = true;
				this.captian.DrinkSomeRum2();
				for (int i = 0; i < Random(0, this.crew.Count()); i++)
				{
					this.crew[Random(0, this.crew.Count() - 1)].DrinkSomeRum2();
				}
				enemy.Lose();
            }
			else if(this.Score() < enemy.Score())
			{
				this.Lose();
				enemy.captian.DrinkSomeRum2();
				for (int i = 0; i < Random(0, enemy.crew.Count()); i++)
				{
					enemy.crew[Random(0, enemy.crew.Count() - 1)].DrinkSomeRum2();
				}
			}
			else
			{
				this.Lose();
				enemy.Lose();
			}

			return won;
		}

		public override string ToString() 
		{		
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Captain state: {this.captian.Status()} - Rum consumed: {this.captian.Intoxication}");
			int crewSize = 0;
            foreach (Pirate p in crew)
            {
				if (!p.Death)
				{
					crewSize++;
				}
            }
			sb.AppendLine($"Crew size: {crewSize}");
			return sb.ToString();
        }
	}
}
