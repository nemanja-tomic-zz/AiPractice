using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NatureOfCode.Introduction;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public partial class Form1 : Form
	{
		private BufferedGraphicsContext _context;
		private BufferedGraphics _bufferedGraphics;
		private Graphics _graphics;
		private IMovingObject _movingObject;
		private bool _targetingEnabled;
		private Point _currentTarget;
		private bool _leaveTrail = true;
		private readonly IEnumerable<Vector> _forces;
		private IList<IMovingObject> _movingObjects = new List<IMovingObject>();
		private static readonly Vector Gravity = new Vector(0, 0.1);
		private readonly Water _water;
		private Air _air;
		private const float FrictionCoeff = (float)0.01;

		public Form1()
		{
			InitializeComponent();
			_water = new Water(0, mainPanel.Height / 2, mainPanel.Height / 2, mainPanel.Width);
			_air = new Air(0, 0, mainPanel.Height / 2, mainPanel.Width);
			var wind = new Vector(0.01, 0);
			_forces = new[] { wind };
		}

		private void flowTimer_Tick(object sender, EventArgs e)
		{
			ApplyForces();
			if (!_leaveTrail)
				ClearScreen();
			if (_targetingEnabled)
				_movingObject.Step(_currentTarget);
			else
				_movingObject.Step();
			_movingObject.Display();
			_bufferedGraphics.Render();
		}

		private void multipleObjectsTimer_Tick(object sender, EventArgs e)
		{
			if (_movingObjects.Count == 0) return;

			ApplyGravity();
			ApplyForces();
			ApplyDrag();

			if (!_leaveTrail)
				ClearScreen();
			if (_targetingEnabled)
			{
				foreach (var movingObject in _movingObjects)
				{
					movingObject.Step(_currentTarget);
				}
			}
			else
			{
				foreach (var movingObject in _movingObjects)
				{
					const int normal = 1;
					var friction = movingObject.Velocity * -1 * normal;
					friction.Normalize();
					friction *= FrictionCoeff;
					movingObject.ApplyForce(friction);
					movingObject.Step();
				}
			}
			foreach (var movingObject in _movingObjects)
			{
				movingObject.Display();
			}
			_bufferedGraphics.Render();
		}

		private void ApplyDrag()
		{
			foreach (var movingObject in _movingObjects)
			{
				if (movingObject.Location.Y < _water.Y) continue;
				var speed = movingObject.Velocity.Magnitude;
				var dragMagnitude = _water.DragCoefficient * speed * speed;
				var drag = movingObject.Velocity * -1;
				drag.Normalize();
				drag *= dragMagnitude;
				movingObject.ApplyForce(drag);

				if (movingObject.Location.Y < _air.Y) continue;
				var airspeed = movingObject.Velocity.Magnitude;
				var airdragMagnitude = _air.DragCoefficient * airspeed * airspeed;
				var airdrag = movingObject.Velocity * -1;
				airdrag.Normalize();
				airdrag *= airdragMagnitude;
				movingObject.ApplyForce(airdrag);
			}
		}

		private void ApplyGravity()
		{
			foreach (var movingObject in _movingObjects)
			{
				movingObject.ApplyForce(new Vector(Gravity.X, Gravity.Y * movingObject.Mass));
			}
		}

		private void ApplyForces()
		{
			if (_forces == null) return;
			foreach (var force in _forces)
			{
				foreach (var movingObject in _movingObjects)
				{
					movingObject.ApplyForce(force);
				}
			}
		}

		#region Walkers
		private void startWalkerBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			_movingObjects.Clear();
			ClearScreen();
			_movingObject = new Walker(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2) { Graphics = _graphics };
			_targetingEnabled = false;
			_leaveTrail = true;
			flowTimer.Enabled = true;
			KeyPreview = false;
		}

		private void startWalker8Btn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			_movingObjects.Clear();
			ClearScreen();
			_movingObject = new Walker8(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2) { Graphics = _graphics };
			_targetingEnabled = false;
			_leaveTrail = true;
			flowTimer.Enabled = true;
			KeyPreview = false;
		}

		private void walkerToRightBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			_movingObjects.Clear();
			ClearScreen();
			_movingObject = new WalkerToRight(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2) { Graphics = _graphics };
			_targetingEnabled = false;
			_leaveTrail = true;
			flowTimer.Enabled = true;
			KeyPreview = false;
		}

		private void guidedWalkerBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			_movingObjects.Clear();
			ClearScreen();
			_movingObject = new WalkerToCursor(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2) { Graphics = _graphics };
			_targetingEnabled = true;
			_leaveTrail = true;
			flowTimer.Enabled = true;
			KeyPreview = false;
		}
		#endregion

		private void bouncingBallBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			_movingObjects.Clear();
			ClearScreen();
			_movingObject = new SimpleBall(mainPanel, _graphics, mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2, 10)
			{
				Acceleration = new Vector(0, 1),
				TopSpeed = 10
			};
			_targetingEnabled = true;
			flowTimer.Enabled = true;
			_leaveTrail = false;
			KeyPreview = true;
		}

		private void randomObjectsBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			ClearScreen();
			_movingObjects = new List<IMovingObject>();
			int objects;
			int.TryParse(objectCount.Text, out objects);
			var random = new Random((int)DateTime.Now.Ticks);
			foreach (var i in Enumerable.Range(1, objects))
			{
				var movingObject = new SimpleBall(mainPanel, _graphics, 50, 50, random.Next(3, 20))
				{
					Acceleration = new Vector(0, 0),
					TopSpeed = 20
				};
				_movingObjects.Add(movingObject);
			}
			//_targetingEnabled = true;
			multipleObjectsTimer.Enabled = true;
			_leaveTrail = false;
		}

		private void ClearScreen()
		{
			_graphics.FillRectangle(Brushes.Black, mainPanel.ClientRectangle);
			_water.Display(_graphics);
			_air.Display(_graphics);
		}

		private void InitializeDrawing()
		{
			if (_context != null) return;

			_context = new BufferedGraphicsContext { MaximumBuffer = mainPanel.ClientSize };
			_bufferedGraphics = _context.Allocate(mainPanel.CreateGraphics(), new Rectangle(0, 0, mainPanel.ClientSize.Width, mainPanel.ClientSize.Height));
			_graphics = _bufferedGraphics.Graphics;
			_graphics.SmoothingMode = SmoothingMode.HighQuality;
		}

		private void mainPanel_MouseMove(object sender, MouseEventArgs e)
		{
			statusLabel.Text = string.Format("X: {0}, Y:{1}", e.X, e.Y);
			_currentTarget = e.Location;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (_movingObject == null || _movingObject.Acceleration == null) return base.ProcessCmdKey(ref msg, keyData);
			switch (keyData)
			{
				case Keys.Up:
					_movingObject.Acceleration++;
					break;
				case Keys.Down:
					_movingObject.Acceleration--;
					break;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
