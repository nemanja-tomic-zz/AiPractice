using System;

namespace NatureOfCode.Vectors
{
	public class Vector
	{
		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get; set; }
		public double Y { get; set; }
		public double Magnitude
		{
			get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)); }
		}

		public void Normalize()
		{
			var magnitude = Magnitude;
			if (!(Math.Abs(magnitude) > double.Epsilon)) return;
			X /= magnitude;
			Y /= magnitude;
		}

		public static Vector operator ++(Vector v1)
		{
			return new Vector(v1.X, v1.Y + 1);
		}

		public static Vector operator --(Vector v1)
		{
			return new Vector(v1.X, v1.Y - 1);
		}

		public static Vector operator +(Vector v1, Vector v2)
		{
			return new Vector(v1.X + v2.X, v1.Y + v2.Y);
		}

		public static Vector operator -(Vector v1, Vector v2)
		{
			return new Vector(v1.X - v2.X, v1.Y - v2.Y);
		}

		public static Vector operator *(Vector v1, double scalar)
		{
			return new Vector(v1.X * scalar, v1.Y * scalar);
		}

		public static Vector operator /(Vector v1, double scalar)
		{
			return new Vector(v1.X / scalar, v1.Y / scalar);
		}
	}
}