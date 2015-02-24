using System;
using System.Collections.Generic;
using System.Linq;

namespace Prison
{
	public class Prison
	{
		public const int PrisonerCount = 100;
		public const int NumbersOfAttemptsToOpenBox = PrisonerCount/2;

		private readonly Box[] _boxes;

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
			var numbers = new bool[PrisonerCount];

			var random = new Random((int)DateTime.Now.Ticks);

			foreach (var box in _boxes)
			{
				int? number = null;

				while(number == null)
				{
					var randomNumber = random.Next(PrisonerCount);

					if (numbers[randomNumber] == false)
					{
						numbers[randomNumber] = true;
						number = randomNumber;
					}
				}

				box.PrisonerId = number.Value;
			}
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
