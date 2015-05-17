using System.Drawing;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public interface IMovingObject
	{
		void Display();
		void Step();
		void Step(Point target);
		Vector Acceleration { get; set; }
		float TopSpeed { get; set; }
		float Mass { get; }
		Vector Velocity { get; }
		void ApplyForce(Vector force);
	}
}