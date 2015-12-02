using System.Drawing;

namespace NatureOfCode
{
	public class Air
	{
		public float X { get; private set; }
		public float Y { get; private set; }
		public float Height { get; private set; }
		public float Width { get; private set; }

		public Air(float x, float y, float height, float width)
		{
			X = x;
			Y = y;
			Height = height;
			Width = width;
		}

		public float DragCoefficient
		{
			get { return (float)0.0001; }
		}

		public void Display(Graphics graphics)
		{
			graphics.FillRectangle(Brushes.White, X, Y, Width, Height);
		}
	}
}