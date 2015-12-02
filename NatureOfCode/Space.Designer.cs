namespace NatureOfCode
{
	partial class Space
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
			this.spaceBtn = new System.Windows.Forms.Button();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.spaceTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// spaceBtn
			// 
			this.spaceBtn.Location = new System.Drawing.Point(12, 12);
			this.spaceBtn.Name = "spaceBtn";
			this.spaceBtn.Size = new System.Drawing.Size(100, 23);
			this.spaceBtn.TabIndex = 11;
			this.spaceBtn.Text = "Space";
			this.spaceBtn.UseVisualStyleBackColor = true;
			this.spaceBtn.Click += new System.EventHandler(this.spaceBtn_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(12, 41);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(1228, 668);
			this.mainPanel.TabIndex = 12;
			// 
			// spaceTimer
			// 
			this.spaceTimer.Interval = 10;
			this.spaceTimer.Tick += new System.EventHandler(this.spaceTimer_Tick);
			// 
			// Space
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1252, 721);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.spaceBtn);
			this.Name = "Space";
			this.Text = "Space";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button spaceBtn;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Timer spaceTimer;
	}
}