using System;
using System.Collections.Generic;
using System.Linq;

namespace Prison
{
	public class Prison
	{
		public const int PrisonerCount = 100;
		public const int NumbersOfAttemptsToOpenBox = PrisonerCount/2;

		private Box[] _boxes;

		public Prison()
		{
			_boxes = new Box[PrisonerCount];

			for (var index = 0; index < _boxes.Length; index++)
			{
				_boxes[index] = new Box();
			}
		}

		public void Initialize()
		{
			for (var i = 0; i < _boxes.Length; i++)
			{
				_boxes[i].PrisonerId = i;
			}

			var random = new Random((int)DateTime.Now.Ticks);
			_boxes = _boxes.OrderBy(b => random.Next()).ToArray();
		}

		public List<List<Box>> GetCircles()
		{
			var circles = new List<List<Box>>();

			for (var number = 0; number < PrisonerCount; number++)
			{
				var box = _boxes[number];

				if (circles.Any(c => c.Contains(box)))
				{
					continue;
				}

				var circle = new List<Box> {box};

				while (box.PrisonerId != number)
				{
					box = _boxes[box.PrisonerId];
					circle.Add(box);
				}

				circles.Add(circle);
			}

			return circles;
		}
	}
}
