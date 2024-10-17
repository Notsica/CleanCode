using CleanCode.Interfaces;
namespace CleanCode.Games;

public class MooLogic : GameLogicBase
{
	public MooLogic(IGameUI gameUI, IGameStatistics gameStatistics, IGuessChecker gameLogic) 
		: base(gameUI, gameStatistics, gameLogic) { }
	protected override IGoalStrategy GoalStrategy => new MooGoalStrategy();

	protected override string FilePath => "MooResults.txt";
}
