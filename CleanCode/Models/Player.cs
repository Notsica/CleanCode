using System;

namespace CleanCode.Models
{
	public class Player
	{
		public string Name { get; private set; }
		public int GameRoundsPlayed { get; private set; }
		public int TotalGuessCount { get; private set; }


		public Player(string name, int guesses)
		{
			this.Name = name;
			GameRoundsPlayed = 1;
			TotalGuessCount = guesses;
		}

		public void Update(int guesses)
		{
			TotalGuessCount += guesses;
			GameRoundsPlayed++;
		}

		public double Average()
		{
			return (double)TotalGuessCount / GameRoundsPlayed;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((Player)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
