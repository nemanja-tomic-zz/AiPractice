using System.Drawing;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public interface IMovingObject
	{
		void Display();
		void Step();
		void Step(Point target);
		void ApplyForce(Vector force);

		Vector Acceleration { get; set; }
		float TopSpeed { get; set; }
		float Mass { get; }
		Vector Velocity { get; }
		Vector Location { get; }
		Vector Attract(IMovingObject movingObject);
	}
}