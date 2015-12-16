using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NatureOfCode.Vectors;

namespace NatureOfCode.OscillationContent
{
	public class Baton
	{
		private readonly Graphics _graphics;
		private readonly Panel _panel;
		private readonly float _length;
		private Vector _location;
		private Rectangle _rectangle;
		private float _angle;
		private float _angularVelocity;
		private float _angularAcceleration = (float)0.01;
		private Vector _velocity = new Vector(0, 0);
		private int _radius;
		private const int Width = 10;

		public Baton(Graphics graphics, Panel panel, float length)
		{
			_graphics = graphics;
			_panel = panel;
			_length = length;
			_location = new Vector(panel.Width / 2, panel.Height / 2);
			_rectangle = new Rectangle((int)_location.X, (int)_location.Y, (int)_length, Width);
			Acceleration = new Vector(0, 0);
		}

		private void CheckEdges()
		{
			if ((_location.X + _radius / 2) > _panel.Width)
			{
				_location.X = _panel.Width - _radius / 2;
				_velocity.X *= -1;
			}
			else if ((_location.X - _radius / 2) < 0)
			{
				_location.X = _radius / 2;
				_velocity.X *= -1;
			}
			if ((_location.Y + _radius / 2) > _panel.Height)
			{
				_velocity.Y *= -1;
				_location.Y = _panel.Height - _radius / 2;
			}
			else if ((_location.Y - _radius / 2) < 0)
			{
				_velocity.Y *= -1;
				_location.Y = _radius / 2;
			}
			//if (_location.X > Panel.Width || _location.X < 0)
			//	Acceleration.X *= -1;
			//if (_location.Y > Panel.Height || _location.Y < 0)
			//	Acceleration.Y *= -1;
		}

		public void Step()
		{
			CheckEdges();
			_velocity += Acceleration;
			if (_velocity.Magnitude > TopSpeed)
			{
				_velocity.Normalize();
				_velocity *= TopSpeed;
			}

			_location += _velocity;
			var angle = Math.Atan2(_velocity.Y, _velocity.X);
			Rotate((float)angle);
			Acceleration *= 0;
		}

		public void Step(Point target)
		{
			var mouse = new Vector(target.X, target.Y);
			var direction = mouse - _location;
			direction.Normalize();
			direction *= 0.7;
			Acceleration += direction;
			Step();
		}

		public void Display()
		{
			_graphics.FillRectangle(Brushes.Tomato, (float)_location.X, (float)_location.Y, _length, Width);
			_graphics.ResetTransform();
		}

		public double TopSpeed { get; set; }

		public Vector Acceleration { get; set; }

		public void Rotate(float angle)
		{
			_angle += angle;

			using (var m = new Matrix())
			{
				m.RotateAt(_angle, new PointF((float)(_location.X + (_length / 2) + Width / 2), (float)(_location.Y + (Width / 2) + (_length / 2))));
				_graphics.Transform = m;
			}
		}
	}
}
