using CleanCode.Interfaces;

namespace CleanCode;

public abstract class GameLogicBase
{
	protected abstract IGoalStrategy GoalStrategy { get; }
	protected abstract string FilePath { get; }

	private readonly IGameUI _gameUI;
	private readonly IGameStatistics _gameStatistics;
	private readonly IGuessChecker _gameLogic;

	public GameLogicBase(IGameUI gameUI, IGameStatistics gameStatistics, IGuessChecker gameLogic)
	{
		_gameUI = gameUI;
		_gameStatistics = gameStatistics;
		_gameLogic = gameLogic;
	}

	public void StartGame()
	{
		bool playOn = true;
		string playerName = _gameUI.GetUserName();

		while (playOn)
		{
			int guessCount = PlayGameRound(playerName);
			playOn = _gameUI.AskToContinueGame(guessCount);
		}
	}

	private int PlayGameRound(string playerName)
	{
		string goal = GoalStrategy.MakeGoal();
		_gameUI.ShowNewGameText(goal);

		int guessCount = HandleGuesses(goal);

		_gameStatistics.SaveGameResult(playerName, guessCount, FilePath);
		var topResults = _gameStatistics.GetGameTopResults(FilePath);
		_gameUI.ShowTopResults(topResults);

		return guessCount;
	}

	private int HandleGuesses(string goal)
	{
		int playerGuessCount = 0;
		bool correctGuess = false;

		do
		{
			string playerGuess = _gameUI.GetPlayerGuess();
			playerGuessCount++;
			_gameUI.ShowPlayerGuess(playerGuess);
			string bullsAndCows = _gameLogic.CheckPlayerGuess(goal, playerGuess);
			_gameUI.ShowPlayerBullsAndCows(bullsAndCows);

			if (bullsAndCows == "BBBB,")
			{
				correctGuess = true;
			}
		} while (!correctGuess);
		return playerGuessCount;
	}
}
