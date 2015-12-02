using System.Drawing;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public class Attractor
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float Mass { get; set; }

		public Attractor(float x, float y, float mass)
		{
			X = x;
			Y = y;
			Mass = mass;
		}

		public void Display(Graphics graphics)
		{
			graphics.FillEllipse(Brushes.Gold, X, Y, Mass, Mass);
		}

		public Vector Attract(IMovingObject mover)
		{
			var gravForce = new Vector(X, Y) - mover.Location;
			var distance = gravForce.Magnitude;
			if (distance < 5)
				distance = 5;
			if (distance > 50)
				distance = 50;
			var magnitude = (Space.G * Mass * mover.Mass) / (distance * distance);
			gravForce.Normalize();
			
			return gravForce * magnitude;
		}
	}
}