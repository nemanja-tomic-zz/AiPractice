﻿using System.Drawing;
using System.Windows.Forms;

namespace NatureOfCode.Vectors
{
	public class SimpleBall : IMovingObject
	{
		private Vector _velocity;
		private Vector _location;
		private readonly float _mass;

		public Graphics Graphics { get; set; }
		public Panel Panel { get; set; }
		public Vector Acceleration { get; set; }
		public float TopSpeed { get; set; }
		public float Mass
		{
			get { return _mass; }
		}

		public Vector Velocity 
		{
			get { return _velocity; }
		}

		public SimpleBall(Panel panel, Graphics graphics, float mass)
		{
			Panel = panel;
			Graphics = graphics;
			_mass = mass;
			_velocity = new Vector(0, 0);
		}

		public SimpleBall(Panel panel, Graphics graphics, int x, int y, float mass)
			: this(panel, graphics, mass)
		{
			_location = new Vector(x, y);
		}

		public void Display()
		{
			Graphics.FillEllipse(Brushes.Aqua, (float)_location.X, (float)_location.Y, 30, 30);
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

		public void ApplyForce(Vector force)
		{
			var calculatedForce = force / _mass;
			Acceleration += calculatedForce;
		}

		private void CheckEdges()
		{
			if (_location.X > Panel.Width)
			{
				_location.X = Panel.Width;
				_velocity.X *= -1;
			}
			else if (_location.X < 0)
			{
				_location.X = 0;
				_velocity.X *= -1;
			}
			if (_location.Y > Panel.Height)
			{
				_velocity.Y *= -1;
				_location.Y = Panel.Height;
			}
			else if (_location.Y < 0)
			{
				_velocity.Y *= -1;
				_location.Y = 0;
			}
			//if (_location.X > Panel.Width || _location.X < 0)
			//	Acceleration.X *= -1;
			//if (_location.Y > Panel.Height || _location.Y < 0)
			//	Acceleration.Y *= -1;
		}
	}
}
