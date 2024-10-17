using CleanCode.Interfaces;

namespace CleanCode
{
	class Program
	{
		static void Main()
		{
			IGameStatistics gameStatistics = new GameStatistics();
			IGameUI gameUI = new GameUI();
			IGuessChecker gameLogic = new GuessChecker();

			GameController game = new GameController(gameUI, gameStatistics, gameLogic);
			game.Start();
		}
	}
}