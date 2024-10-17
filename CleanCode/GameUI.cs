using CleanCode.Interfaces;
using CleanCode.Models;

namespace CleanCode
{
	public class GameUI : IGameUI
	{
		public string GetPLayerGameChoice()
		{
			Console.WriteLine("Enter '1' to play: Moo");
			Console.WriteLine("Enter '2' to play: MasterMind");
			Console.WriteLine("Enter anything else to quit");
			String playerGameChoice = Console.ReadLine();
			return playerGameChoice;
		}
		public string GetUserName() {
			Console.WriteLine("Enter your user name:\n");
			string playerName = Console.ReadLine();
			return playerName;
		}

		public void ShowNewGameText(string goal)
		{
			Console.WriteLine("New game:\n");
			//comment out or remove next line to play real games!
			Console.WriteLine("For practice, number is: " + goal + "\n");
		}

		public string GetPlayerGuess()
		{
			return Console.ReadLine();
		}

		public void ShowPlayerBullsAndCows(string bullsAndCows)
		{
			Console.WriteLine($"{bullsAndCows}\n");
		}

		public void ShowPlayerGuess(string playerGuess)
		{
			Console.WriteLine(playerGuess + "\n");
		}

		public void ShowTopResults(List<Player> results)
		{
			Console.WriteLine("Player   games average");
			foreach (Player p in results)
			{
				Console.WriteLine($"{p.Name,-9}{p.GameRoundsPlayed,5}{p.Average(),9:F2}");
			}
		}

		public bool AskToContinueGame(int guessCount)
		{
			Console.WriteLine($"Correct, it took {guessCount} guesses.\nDo you want to continue? (Type 'no' to end the game)");
			string answer = Console.ReadLine();
			if (!String.IsNullOrEmpty(answer) && answer.ToLower().StartsWith("n"))
			{
				return false;
			};
			return true; 
		}

	}
}
