using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NatureOfCode.OscillationContent;

namespace NatureOfCode
{
	public partial class Oscillation : Form
	{
		private BufferedGraphicsContext _context;
		private BufferedGraphics _bufferedGraphics;
		private Graphics _graphics;
		private Baton _baton;
		private Baton _baton2;
		private Point _mouseLocation;

		public Oscillation()
		{
			InitializeComponent();
		}

		private void flowTimer_Tick(object sender, EventArgs e)
		{
			ClearScreen();
			_graphics.FillEllipse(Brushes.Aqua, 20, 30, 20, 20);
			_baton.Step(_mouseLocation);
			_baton.Display();


			_bufferedGraphics.Render();
		}

		private void InitializeDrawing()
		{
			if (_context != null) return;

			_context = new BufferedGraphicsContext { MaximumBuffer = mainPanel.ClientSize };
			_bufferedGraphics = _context.Allocate(mainPanel.CreateGraphics(), new Rectangle(0, 0, mainPanel.ClientSize.Width, mainPanel.ClientSize.Height));
			_graphics = _bufferedGraphics.Graphics;
			_graphics.SmoothingMode = SmoothingMode.HighQuality;
		}

		private void ClearScreen()
		{
			_graphics.FillRectangle(Brushes.Black, mainPanel.ClientRectangle);
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			flowTimer.Interval = 16;
			flowTimer.Enabled = true;

			InitializeDrawing();
			ClearScreen();
			_baton = new Baton(_graphics, mainPanel, 40) { TopSpeed = 3 };
			_baton2 = new Baton(_graphics, mainPanel, 60) { TopSpeed = 30 };
		}

		private void mainPanel_MouseMove(object sender, MouseEventArgs e)
		{
			_mouseLocation = new Point(e.X, e.Y);
		}
	}
}
