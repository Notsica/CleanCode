using CleanCode.Interfaces;

namespace CleanCode.Tests;

[TestClass()]
public class GoalStrategyTests
{
	[TestMethod()]
	public void MakeGoal_GenerateMooGoal_Generates4UniqueDigits()
	{
		//Arrange
		IGoalStrategy mooStrategy = new MooGoalStrategy();

		//Act
		string goal = mooStrategy.MakeGoal();

		//Assert
		Assert.AreEqual(4, goal.Length);
		Assert.AreEqual(4, goal.Distinct().Count());
		Assert.IsTrue(goal.All(char.IsDigit));
	}

	[TestMethod()]
	public void MakeGoal_GenerateMastermindGoal_Generates4Digits()
	{
		//Arrange
		IGoalStrategy mastermindStrategy = new MastermindGoalStrategy();

		//Act
		string goal = mastermindStrategy.MakeGoal();

		//Assert
		Assert.AreEqual(4, goal.Length);
		Assert.IsTrue(goal.All(char.IsDigit));
	}
}