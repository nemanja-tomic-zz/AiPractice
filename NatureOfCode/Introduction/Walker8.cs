namespace NatureOfCode.Introduction
{
	class Walker8 : Walker
	{
		public Walker8(int x, int y) : base(x, y)
		{
		}

		public override void Step()
		{
			var stepx = Random.Next(-1, 2);
			var stepy = Random.Next(-1, 2);

			X += stepx;
			Y += stepy;
		}
	}
}