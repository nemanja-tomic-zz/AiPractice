using System;
using System.Drawing;
using NatureOfCode.Vectors;

namespace NatureOfCode.Introduction
{
	public class Walker : IMovingObject
	{
		protected readonly Random Random;

		public Walker(int x, int y)
		{
			X = x;
			Y = y;
			Random = new Random();
		}

		public virtual void Step()
		{
			var choice = Random.Next(4);

			switch (choice)
			{
				case 0:
					X++;
					break;
				case 1:
					X--;
					break;
				case 2:
					Y++;
					break;
				case 3:
					Y--;
					break;
			}
		}

		public virtual void Step(Point target)
		{
			Step();
		}

		public Vector Acceleration { get; set; }
		public float TopSpeed { get; set; }

		public void Display()
		{
			Graphics.FillEllipse(Brushes.White, X, Y, 2, 2);
		}

		public int X { get; set; }

		public int Y { get; set; }

		public Graphics Graphics { get; set; }
	}
}