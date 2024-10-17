using CleanCode.Interfaces;

namespace CleanCode.Tests;

[TestClass()]
public class GuessCheckerTests
{
	[TestMethod()]
	public void CheckPlayerGuess_CorrectGuess_ReturnsBulls()
	{
		// Arrange
		IGuessChecker gameLogic = new GuessChecker();
		string goal = "1234";
		string guess = "1234";

		// Act
		string result = gameLogic.CheckPlayerGuess(goal, guess);

		// Assert
		Assert.AreEqual("BBBB,", result);
	}

	[TestMethod()]
	public void CheckPlayerGuess_EntirelyIncorrectGuess_ReturnsComma()
	{
		// Arrange
		IGuessChecker gameLogic = new GuessChecker();
		string goal = "1234";
		string guess = "5555";

		// Act
		string result = gameLogic.CheckPlayerGuess(goal, guess);

		// Assert
		Assert.AreEqual(",", result);
	}

	[TestMethod()]
	public void CheckPlayerGuess_CorrectGuessWithJumbledOrder_ReturnsCows()
	{
		// Arrange
		IGuessChecker gameLogic = new GuessChecker();
		string goal = "1234";
		string guess = "4321";

		// Act
		string result = gameLogic.CheckPlayerGuess(goal, guess);

		// Assert
		Assert.AreEqual(",CCCC", result);
	}

	[TestMethod()]
	public void CheckPlayerGuess_HalfCorrectHalfWrongGuess_ReturnsBullsAndCows()
	{
		// Arrange
		IGuessChecker gameLogic = new GuessChecker();
		string goal = "1234";
		string guess = "1289";

		// Act
		string result = gameLogic.CheckPlayerGuess(goal, guess);

		// Assert
		Assert.AreEqual("BB,", result);
	}

	[TestMethod()]
	public void IsBull_CorrectCharInCorrectPosition_ReturnsTrue()
	{
		//Arrange
		IGuessChecker gameLogic = new GuessChecker();
		char goal = '5';
		char guess = '5';

		//Act
		bool result = gameLogic.IsBull(goal, guess);

		//Assert
		Assert.IsTrue(result);

	}

	[TestMethod()]
	public void IsCow_CorrectCharInWrongPosition_ReturnsTrue()
	{
		//Arrange
		IGuessChecker gameLogic = new GuessChecker();
		string goal = "1234";
		string guess = "9991";
		int index = 0;

		//Act
		bool result = gameLogic.IsCow(goal, guess, index);

		//Assert
		Assert.IsTrue(result);
	}

	[TestMethod()]
	public void FormatResult_TwoBullsOneCow_ReturnsBBCommaC()
	{
		//Arrange
		IGuessChecker gameLogic = new GuessChecker();
		int bulls = 2;
		int cows = 1;

		//Act
		string result = gameLogic.FormatResult(bulls, cows);

		//Assert
		Assert.AreEqual("BB,C", result);
	}
}