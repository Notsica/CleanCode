namespace CleanCode.Interfaces;

public interface IGuessChecker
{
	string CheckPlayerGuess(string goal, string guess);
	bool IsBull(char goal, char guess);
	bool IsCow(string goal, string guess, int index);
	string FormatResult(int bulls, int cows);
}
