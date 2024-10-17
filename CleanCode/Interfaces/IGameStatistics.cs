using CleanCode.Models;

namespace CleanCode.Interfaces;

public interface IGameStatistics
{
	void SaveGameResult(string playerName, int guessCount, string filePath);
	List<Player> GetGameTopResults(string filePath);
}
