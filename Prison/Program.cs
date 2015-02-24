using System;
using System.Linq;

namespace Prison
{
	class Program
	{
		static void Main(string[] args)
		{
			var prison = new Prison();
			prison.Initialize();

			var circles = prison.GetCircles();

			Console.WriteLine("Total number of prisoners: {0}.", Prison.PrisonerCount);
			Console.WriteLine("Number of circles: {0}.", circles.Count);

			foreach (var circle in circles)
			{
				Console.WriteLine(circle.Count);
			}

			Console.WriteLine(circles.Any(c => c.Count > Prison.NumbersOfAttemptsToOpenBox)
				                  ? "Prisoners can't escape."
				                  : "Prisoners can escape.");
		}
	}
}
