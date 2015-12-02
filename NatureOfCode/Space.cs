using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public partial class Space : Form
	{
		private readonly List<IMovingObject> _spaceObjects = new List<IMovingObject>();
		private Graphics _graphics;
		private BufferedGraphicsContext _context;
		private BufferedGraphics _bufferedGraphics;
		private readonly Attractor _attractor;

		public const float G = 1;


		public Space()
		{
			InitializeComponent();
			_attractor = new Attractor(mainPanel.Width / 2, mainPanel.Height / 2, 80);
		}


		private void spaceTimer_Tick(object sender, EventArgs e)
		{
			if (!_spaceObjects.Any()) return;
			ClearScreen();
			foreach (var movingObject in _spaceObjects)
			{
				if (movingObject.Acceleration == null)
					movingObject.Acceleration = new Vector(0, -2);
				movingObject.ApplyForce(_attractor.Attract(movingObject));
				movingObject.Step();
				movingObject.Display();
			}

			_bufferedGraphics.Render();
		}

		private void spaceBtn_Click(object sender, EventArgs e)
		{
			InitializeDrawing();
			ClearScreen();
			_spaceObjects.Clear();
			var object1 = new SimpleBall(mainPanel, _graphics, 400, 300, 3) { TopSpeed = 50 };
			var object2 = new SimpleBall(mainPanel, _graphics, 480, 365, 10) { TopSpeed = 50 };
			_spaceObjects.Add(object1);
			_spaceObjects.Add(object2);
			spaceTimer.Enabled = true;
			KeyPreview = false;
		}

		private void ClearScreen()
		{
			_graphics.FillRectangle(Brushes.Black, mainPanel.ClientRectangle);
			_attractor.Display(_graphics);
		}

		private void InitializeDrawing()
		{
			if (_context != null) return;

			_context = new BufferedGraphicsContext { MaximumBuffer = mainPanel.ClientSize };
			_bufferedGraphics = _context.Allocate(mainPanel.CreateGraphics(), new Rectangle(0, 0, mainPanel.ClientSize.Width, mainPanel.ClientSize.Height));
			_graphics = _bufferedGraphics.Graphics;
			_graphics.SmoothingMode = SmoothingMode.HighQuality;
		}
	}
}
