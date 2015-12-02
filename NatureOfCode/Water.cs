using System.Drawing;

namespace NatureOfCode
{
	public class Water
	{
		public readonly float X;
		public readonly float Y;
		public readonly float Height;
		public readonly float Width;

		public Water(float x, float y, float height, float width)
		{
			X = x;
			Y = y;
			Height = height;
			Width = width;
		}

		public float DragCoefficient
		{
			get { return (float)0.3; }
		}

		public void Display(Graphics graphics)
		{
			graphics.FillRectangle(Brushes.Aqua, X, Y, Width, Height);
		}
	}
}