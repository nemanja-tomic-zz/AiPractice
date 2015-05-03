namespace NatureOfCode.Introduction
{
	class WalkerToRight : Walker
	{
		public WalkerToRight(int x, int y) : base(x, y)
		{
		}

		public override void Step()
		{
			var random = Random.Next(11);

			if (random < 5)
				X++;
			else if (random < 7)
				X--;
			else if (random < 9)
				Y++;
			else if (random < 11)
				Y--;
		}
	}
}