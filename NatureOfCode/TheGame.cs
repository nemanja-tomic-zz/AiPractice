using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NatureOfCode.Vectors;

namespace NatureOfCode
{
	public partial class TheGame : Form
	{
		private BufferedGraphicsContext _context;
		private Graphics _graphics;
		private BufferedGraphics _bufferedGraphics;
		private IPEndPoint _remoteMachine;
		private readonly UdpClient _myself;
		//private const string RemoteIp = "192.168.50.102"; //milivoj
		//private const string RemoteIp = "192.168.50.49"; //nemanja
		//private const string RemoteIp = "192.168.50.120"; //deki
		private string _remoteIp;
		private Point _mouseLocation;
		private Vector _opponent;
		private readonly SimpleBall _myObject;
		private const int Port = 8887;

		public TheGame()
		{
			InitializeComponent();
			remoteMachine.Text = "192.168.50.120";
			PrintStatus("Initializing...");
			_myself = new UdpClient(Port) { Client = { ReceiveTimeout = 2000 } };
			StartListening();

			InitializeDrawing();
			ClearScreen();
			_myObject = new SimpleBall(mainPanel, _graphics, mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2, 10)
			{
				Acceleration = new Vector(0, 1),
				TopSpeed = 10
			};
			KeyPreview = true;
		}

		private void StartListening()
		{
			Task.Factory.StartNew(() =>
			{
				var ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
				while (true)
				{
					try
					{
						var data = _myself.Receive(ref ipEndPoint);
						var testConnection = Util.ByteArrayToObject<TestConnection>(data);
						if (testConnection.Ready)
						{
							var sendData = Util.ObjectToByteArray(new TestConnection { Ready = true });
							_myself.Send(sendData, sendData.Length, ipEndPoint);
						}
						if (testConnection.ObjectLocation != null && !testConnection.ObjectLocation.Equals(default(Vector)))
						{
							_opponent = testConnection.ObjectLocation;
						}
					}
					catch (SocketException)
					{
					}
					catch (Exception ex)
					{
						Console.WriteLine("Bad data: {0}", ex.Message);
					}
				}
			});
		}

		private void Connect()
		{
			var testConnection = new TestConnection { Ready = true };
			var message = Util.ObjectToByteArray(testConnection);
			_myself.Send(message, message.Length, _remoteMachine);

			var timer = 0;
			while (timer <= 10)
			{
				try
				{
					var data = _myself.Receive(ref _remoteMachine);
					var response = Util.ByteArrayToObject<TestConnection>(data);
					if (response.Ready)
						return;
				}
				catch
				{
					// ignored
				}
				Thread.Sleep(1000);
				timer++;
			}
			throw new Exception("Couldn't connect to the remote machine.");
		}

		private void gameTimer_Tick(object sender, EventArgs e)
		{
			ClearScreen();

			_myObject.Step(_mouseLocation);
			_myObject.Display();

			if (_opponent != null)
			{
				opponentLocation.Text = string.Format("{0}.{1}", (int)_opponent.X, (int)_opponent.Y);
				_graphics.DrawEllipse(Pens.Red, (float)_opponent.X - 5, (float)_opponent.Y - 5, 10, 10);
			}

			_bufferedGraphics.Render();

			var testConnection = new TestConnection { ObjectLocation = _myObject.Location };
			var data = Util.ObjectToByteArray(testConnection);
			_myself.Send(data, data.Length, _remoteMachine);
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

		private void PrintStatus(string statusText)
		{
			statusArea.Text = statusText;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				_remoteIp = remoteMachine.Text;
				_remoteMachine = new IPEndPoint(IPAddress.Parse(_remoteIp), Port);
				if (string.IsNullOrEmpty(_remoteIp))
					throw new Exception("Please enter remote IP address.");
				PrintStatus("Connecting...");
				Connect();
				PrintStatus("Ready!");
				gameTimer.Enabled = true;
				gameTimer.Interval = 16;
			}
			catch (Exception ex)
			{
				PrintStatus(ex.Message);
			}
		}

		private void mainPanel_MouseMove(object sender, MouseEventArgs e)
		{
			_mouseLocation = new Point(e.X, e.Y);
		}
	}
}
