using CleanCode.Models;

namespace CleanCode.Interfaces
{
	public class GameStatistics : IGameStatistics
	{

        public void SaveGameResult(string playerName, int guessCount, string filePath)
		{
			using (StreamWriter output = new StreamWriter(filePath, append: true))
			{
				output.WriteLine($"{playerName}#&#{guessCount}");
			}
		}

		public List<Player> GetGameTopResults(string filePath)
		{
			var results = new List<Player>();

			foreach (var line in ReadLinesFromFile(filePath))
			{
				var player = ParsePlayer(line);
				UpdatePlayerResults(results, player);
			}

			results.Sort(ComparePlayersByAverageGuesses);
			return results;
		}

		private IEnumerable<string> ReadLinesFromFile(string filePath)
		{
			using (var reader = new StreamReader(filePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}

		private Player ParsePlayer(string line)
		{
			var nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
			string name = nameAndScore[0];
			int guesses = Convert.ToInt32(nameAndScore[1]);

			return new Player(name, guesses);
		}

		private void UpdatePlayerResults(List<Player> results, Player player)
		{
			var existingPlayer = results.FirstOrDefault(p => p.Name == player.Name);

			if (existingPlayer == null)
			{
				results.Add(player);
			}
			else
			{
				existingPlayer.Update(player.TotalGuessCount);
			}
		}

		private int ComparePlayersByAverageGuesses(Player p1, Player p2)
		{
			return p1.Average().CompareTo(p2.Average());
		}
	}
}
