using CleanCode.Models;

namespace CleanCode.Interfaces;

public interface IGameUI
{
	string GetPLayerGameChoice();
	string GetUserName();

	void ShowNewGameText(string goal);

	string GetPlayerGuess();

	void ShowPlayerBullsAndCows(string bullsAndCows);

	void ShowPlayerGuess(string playerGuess);

	void ShowTopResults(List<Player> results);

	bool AskToContinueGame(int guessCount);
}
