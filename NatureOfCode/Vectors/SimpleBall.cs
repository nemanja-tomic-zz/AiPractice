using System;
using System.Drawing;
using System.Windows.Forms;

namespace NatureOfCode.Vectors
{
	public class SimpleBall : IMovingObject
	{
		private Vector _velocity;
		private Vector _location;

		public Graphics Graphics { get; set; }
		public Panel Panel { get; set; }
		public Vector Acceleration { get; set; }
		public float TopSpeed { get; set; }

		public SimpleBall(Panel panel, Graphics graphics)
		{
			Panel = panel;
			Graphics = graphics;
			_velocity = new Vector(0, 0);
		}

		public SimpleBall(Panel panel, Graphics graphics, int x, int y) : this(panel, graphics)
		{
			_location = new Vector(x, y);
		}

		public void Display()
		{
			Graphics.FillEllipse(Brushes.Aqua, (float)_location.X, (float)_location.Y, 10, 10);
		}

		public void Step()
		{
			_velocity += Acceleration;
			if (_velocity.Magnitude > TopSpeed)
			{
				_velocity.Normalize();
				_velocity *= TopSpeed;
			}

			_location += _velocity;

			CheckEdges();
		}

		private void CheckEdges()
		{
			if (_location.X > Panel.Width)
				_location.X = 0;
			else if (_location.X < 0)
				_location.X = Panel.Width;
			if (_location.Y > Panel.Height)
				_location.Y = 0;
			else if (_location.Y < 0)
				_location.Y = Panel.Height;

			//if (_location.X > Panel.Width || _location.X < 0)
			//	_velocity.X *= -1;
			//if (_location.Y > Panel.Height || _location.Y < 0)
			//	_velocity.Y *= -1;
		}

		public void Step(Point target)
		{
			var mouse = new Vector(target.X, target.Y);
			var direction = mouse - _location;
			direction.Normalize();
			//direction *= 0.5;
			Acceleration = direction;
			Step();
		}
	}
}
