using System.Drawing;

namespace NatureOfCode.Introduction
{
	class WalkerToCursor : Walker
	{
		public WalkerToCursor(int x, int y) : base(x, y)
		{
		}

		public override void Step(Point target)
		{
			var random = Random.Next(11);
			var stepx = Random.Next(-1, 2);
			var stepy = Random.Next(-1, 2);

			if (random < 4)
			{
				if (X < target.X)
					X++;
				else
					X--;
				if (Y < target.Y)
					Y++;
				else
					Y--;
			}
			else
			{
				X += stepx;
				Y += stepy;
			}
		}
	}
}