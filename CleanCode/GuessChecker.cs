using CleanCode.Interfaces;

namespace CleanCode
{
	public class GuessChecker : IGuessChecker
	{
		public string CheckPlayerGuess(string goal, string guess)
		{
			int cows = 0;
			int bulls = 0;
			int targetNumberLength = goal.Length;

			guess = guess.PadRight(targetNumberLength);

			for (int i = 0; i < targetNumberLength; i++)
			{
				if (IsBull(goal[i], guess[i]))
				{
					bulls++;
				}
				else if (IsCow(goal, guess, i))
				{
					cows++;
				}
			}
			return FormatResult(bulls, cows);
		}

		public bool IsBull(char goal, char guess)
		{
			return goal == guess;
		}

		public bool IsCow(string goal, string guess, int index)
		{
			for (int j = 0; j < goal.Length; j++)
			{
				if (index != j && goal[index] == guess[j])
				{
					return true;
				}
			}
			return false;
		}

		public string FormatResult(int bulls, int cows)
		{
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
	}
}
