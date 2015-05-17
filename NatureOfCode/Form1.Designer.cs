namespace NatureOfCode
{
	partial class Form1
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
			this.startWalkerBtn = new System.Windows.Forms.Button();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.flowTimer = new System.Windows.Forms.Timer(this.components);
			this.startWalker8Btn = new System.Windows.Forms.Button();
			this.walkerToRightBtn = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.guidedWalkerBtn = new System.Windows.Forms.Button();
			this.bouncingBallBtn = new System.Windows.Forms.Button();
			this.objectCount = new System.Windows.Forms.TextBox();
			this.objectCountLabel = new System.Windows.Forms.Label();
			this.randomObjectsBtn = new System.Windows.Forms.Button();
			this.multipleObjectsTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// startWalkerBtn
			// 
			this.startWalkerBtn.Location = new System.Drawing.Point(12, 12);
			this.startWalkerBtn.Name = "startWalkerBtn";
			this.startWalkerBtn.Size = new System.Drawing.Size(89, 23);
			this.startWalkerBtn.TabIndex = 0;
			this.startWalkerBtn.Text = "RandomWalker";
			this.startWalkerBtn.UseVisualStyleBackColor = true;
			this.startWalkerBtn.Click += new System.EventHandler(this.startWalkerBtn_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Location = new System.Drawing.Point(13, 42);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(957, 440);
			this.mainPanel.TabIndex = 1;
			this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
			// 
			// flowTimer
			// 
			this.flowTimer.Interval = 13;
			this.flowTimer.Tick += new System.EventHandler(this.flowTimer_Tick);
			// 
			// startWalker8Btn
			// 
			this.startWalker8Btn.Location = new System.Drawing.Point(107, 13);
			this.startWalker8Btn.Name = "startWalker8Btn";
			this.startWalker8Btn.Size = new System.Drawing.Size(80, 23);
			this.startWalker8Btn.TabIndex = 2;
			this.startWalker8Btn.Text = "Walker8";
			this.startWalker8Btn.UseVisualStyleBackColor = true;
			this.startWalker8Btn.Click += new System.EventHandler(this.startWalker8Btn_Click);
			// 
			// walkerToRightBtn
			// 
			this.walkerToRightBtn.Location = new System.Drawing.Point(193, 12);
			this.walkerToRightBtn.Name = "walkerToRightBtn";
			this.walkerToRightBtn.Size = new System.Drawing.Size(95, 23);
			this.walkerToRightBtn.TabIndex = 3;
			this.walkerToRightBtn.Text = "Walker To Right";
			this.walkerToRightBtn.UseVisualStyleBackColor = true;
			this.walkerToRightBtn.Click += new System.EventHandler(this.walkerToRightBtn_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(888, 487);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(35, 13);
			this.statusLabel.TabIndex = 4;
			this.statusLabel.Text = "label1";
			// 
			// guidedWalkerBtn
			// 
			this.guidedWalkerBtn.Location = new System.Drawing.Point(294, 13);
			this.guidedWalkerBtn.Name = "guidedWalkerBtn";
			this.guidedWalkerBtn.Size = new System.Drawing.Size(83, 23);
			this.guidedWalkerBtn.TabIndex = 5;
			this.guidedWalkerBtn.Text = "GuidedWalker";
			this.guidedWalkerBtn.UseVisualStyleBackColor = true;
			this.guidedWalkerBtn.Click += new System.EventHandler(this.guidedWalkerBtn_Click);
			// 
			// bouncingBallBtn
			// 
			this.bouncingBallBtn.Location = new System.Drawing.Point(384, 12);
			this.bouncingBallBtn.Name = "bouncingBallBtn";
			this.bouncingBallBtn.Size = new System.Drawing.Size(86, 23);
			this.bouncingBallBtn.TabIndex = 6;
			this.bouncingBallBtn.Text = "BouncingBall";
			this.bouncingBallBtn.UseVisualStyleBackColor = true;
			this.bouncingBallBtn.Click += new System.EventHandler(this.bouncingBallBtn_Click);
			// 
			// objectCount
			// 
			this.objectCount.Location = new System.Drawing.Point(870, 12);
			this.objectCount.Name = "objectCount";
			this.objectCount.Size = new System.Drawing.Size(100, 20);
			this.objectCount.TabIndex = 7;
			// 
			// objectCountLabel
			// 
			this.objectCountLabel.AutoSize = true;
			this.objectCountLabel.Location = new System.Drawing.Point(791, 12);
			this.objectCountLabel.Name = "objectCountLabel";
			this.objectCountLabel.Size = new System.Drawing.Size(73, 13);
			this.objectCountLabel.TabIndex = 8;
			this.objectCountLabel.Text = "Total Objects:";
			// 
			// randomObjectsBtn
			// 
			this.randomObjectsBtn.Location = new System.Drawing.Point(476, 13);
			this.randomObjectsBtn.Name = "randomObjectsBtn";
			this.randomObjectsBtn.Size = new System.Drawing.Size(100, 23);
			this.randomObjectsBtn.TabIndex = 9;
			this.randomObjectsBtn.Text = "Random Objects";
			this.randomObjectsBtn.UseVisualStyleBackColor = true;
			this.randomObjectsBtn.Click += new System.EventHandler(this.randomObjectsBtn_Click);
			// 
			// multipleObjectsTimer
			// 
			this.multipleObjectsTimer.Interval = 10;
			this.multipleObjectsTimer.Tick += new System.EventHandler(this.multipleObjectsTimer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 509);
			this.Controls.Add(this.randomObjectsBtn);
			this.Controls.Add(this.objectCountLabel);
			this.Controls.Add(this.objectCount);
			this.Controls.Add(this.bouncingBallBtn);
			this.Controls.Add(this.guidedWalkerBtn);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.walkerToRightBtn);
			this.Controls.Add(this.startWalker8Btn);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.startWalkerBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startWalkerBtn;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Timer flowTimer;
		private System.Windows.Forms.Button startWalker8Btn;
		private System.Windows.Forms.Button walkerToRightBtn;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button guidedWalkerBtn;
		private System.Windows.Forms.Button bouncingBallBtn;
		private System.Windows.Forms.TextBox objectCount;
		private System.Windows.Forms.Label objectCountLabel;
		private System.Windows.Forms.Button randomObjectsBtn;
		private System.Windows.Forms.Timer multipleObjectsTimer;
	}
}

