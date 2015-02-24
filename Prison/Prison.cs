using System;

namespace Prison
{
	public class Prison
	{
		public const int BoxesCount = 100;
		private readonly Box[] _boxes;

		public Prison()
		{
			_boxes = new Box[BoxesCount];

			for (int index = 0; index < _boxes.Length; index++)
			{
				_boxes[index] = new Box();
			}
		}

		public void Initialize()
		{
			var numbers = new bool[BoxesCount];

			var rnd = new Random();

			foreach (var box in _boxes)
			{
				int? number = null;

				while(number == null)
				{
					var randomNumber = rnd.Next(BoxesCount);

					if (numbers[randomNumber] == false)
					{
						numbers[randomNumber] = true;
						number = randomNumber;
					}
				}

				box.PrisonerId = number.Value;
			}
		}
	}
}
