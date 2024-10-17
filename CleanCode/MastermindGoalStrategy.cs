using CleanCode.Interfaces;

namespace CleanCode
{
	public class MastermindGoalStrategy : IGoalStrategy
	{
		private static readonly Random randomGenerator = new Random();

		public string MakeGoal()
		{
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(6);
				string randomDigit = random.ToString();
				goal += randomDigit;
			}
			return goal;
		}
	}
}
