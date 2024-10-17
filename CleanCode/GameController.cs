using CleanCode.Games;
using CleanCode.Interfaces;

namespace CleanCode
{
	public class GameController
	{
		private readonly IGameUI _gameUI;
		private readonly IGameStatistics _gameStatistics;
		private readonly IGuessChecker _gameLogic;

		public GameController(IGameUI gameUI, IGameStatistics gameStatistics, IGuessChecker gameLogic)
		{
			_gameUI = gameUI;
			_gameStatistics = gameStatistics;
			_gameLogic = gameLogic;
		}

		public void Start()
		{
			var gameChoice = HandlePlayerGameChoice();
			StartChosenGame(gameChoice);
		}

		public string HandlePlayerGameChoice()
		{
			string gameChoice = _gameUI.GetPLayerGameChoice();
			if (gameChoice == "1" || gameChoice.ToLower() == "moo")
			{
				return "moo";
			}
			else if (gameChoice == "2" || gameChoice.ToLower() == "mastermind")
			{
				return "mastermind";
			}
			else
			{
				return "";
			}
		}

		public void StartChosenGame(string gameChoice)
		{
			if (gameChoice == "moo")
			{
				var gameLogic = new MooLogic(_gameUI, _gameStatistics, _gameLogic);
				gameLogic.StartGame();
			}
			else if (gameChoice == "mastermind")
			{
				var gameLogic = new MastermindLogic(_gameUI, _gameStatistics, _gameLogic);
				gameLogic.StartGame();
			}
			else
			{
			}
		}
	}
}
