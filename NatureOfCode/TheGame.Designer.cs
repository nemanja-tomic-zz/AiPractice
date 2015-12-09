namespace NatureOfCode
{
	partial class TheGame
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
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.statusArea = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.remoteMachine = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.opponentMouse = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(12, 32);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(1420, 541);
			this.mainPanel.TabIndex = 0;
			this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
			// 
			// gameTimer
			// 
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 580);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Status:";
			// 
			// statusArea
			// 
			this.statusArea.AutoSize = true;
			this.statusArea.Location = new System.Drawing.Point(16, 608);
			this.statusArea.Name = "statusArea";
			this.statusArea.Size = new System.Drawing.Size(0, 13);
			this.statusArea.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// remoteMachine
			// 
			this.remoteMachine.Location = new System.Drawing.Point(93, 5);
			this.remoteMachine.Name = "remoteMachine";
			this.remoteMachine.Size = new System.Drawing.Size(138, 20);
			this.remoteMachine.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1206, 580);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(151, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Opponent Mouse Coordinates:";
			// 
			// opponentMouse
			// 
			this.opponentMouse.AutoSize = true;
			this.opponentMouse.Location = new System.Drawing.Point(1363, 580);
			this.opponentMouse.Name = "opponentMouse";
			this.opponentMouse.Size = new System.Drawing.Size(0, 13);
			this.opponentMouse.TabIndex = 6;
			// 
			// TheGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1444, 630);
			this.Controls.Add(this.opponentMouse);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.remoteMachine);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.statusArea);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mainPanel);
			this.Name = "TheGame";
			this.Text = "TheGame";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusArea;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox remoteMachine;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label opponentMouse;
	}
}