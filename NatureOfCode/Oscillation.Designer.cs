namespace NatureOfCode
{
	partial class Oscillation
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.startBtn = new System.Windows.Forms.Button();
			this.flowTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(12, 39);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(1455, 489);
			this.mainPanel.TabIndex = 0;
			this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(12, 10);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(75, 23);
			this.startBtn.TabIndex = 1;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// flowTimer
			// 
			this.flowTimer.Tick += new System.EventHandler(this.flowTimer_Tick);
			// 
			// Oscillation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1479, 540);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.mainPanel);
			this.Name = "Oscillation";
			this.Text = "Oscillation";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Timer flowTimer;
	}
}