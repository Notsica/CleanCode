using CleanCode.Interfaces;

namespace CleanCode.Games;

public class MastermindLogic : GameLogicBase
{
	public MastermindLogic(IGameUI gameUI, IGameStatistics gameStatistics, IGuessChecker gameLogic) 
		: base(gameUI, gameStatistics, gameLogic) { }
	protected override IGoalStrategy GoalStrategy => new MastermindGoalStrategy();

	protected override string FilePath => "MastermindResults.txt";
}
