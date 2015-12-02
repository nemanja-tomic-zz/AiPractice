using System;
using System.Collections.Generic;
using System.Linq;
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
			var intro = Task.Factory.StartNew(() => Application.Run(new Form1()));
			var space = Task.Factory.StartNew(() => Application.Run(new Space()));
			Task.WaitAll(intro, space);
		}
	}
}
