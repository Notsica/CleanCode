using CleanCode.Interfaces;

namespace CleanCode
{
	public class MooGoalStrategy : IGoalStrategy
	{
		private static readonly Random randomGenerator = new Random();

		public string MakeGoal()
		{
			var digits = Enumerable.Range(0, 10).OrderBy(x => randomGenerator.Next()).Take(4);
			return string.Concat(digits);
		}
	}
}
