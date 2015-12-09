using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatureOfCode
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Task.WaitAll(
				//Task.Factory.StartNew(() => Application.Run(new Form1())),
				//Task.Factory.StartNew(() => Application.Run(new Space())),
				Task.Factory.StartNew(() => Application.Run(new TheGame()))
			);
		}
	}
}
