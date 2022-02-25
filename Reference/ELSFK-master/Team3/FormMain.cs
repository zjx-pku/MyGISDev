using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Team3
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel panelScreen;
		public System.Windows.Forms.Panel panelCover;
		public  System.Windows.Forms.Label labelInfo;
		public System.Windows.Forms.Label labelScore;
        public System.Windows.Forms.Panel viewPanelScreen;
		public System.Windows.Forms.Label labelLever;
        public System.Windows.Forms.Label labelTempInfo;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Timers.Timer timerForTempInfo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private Label label4;



		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.panelScreen = new System.Windows.Forms.Panel();
            this.panelCover = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.viewPanelScreen = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLever = new System.Windows.Forms.Label();
            this.timerForTempInfo = new System.Timers.Timer();
            this.labelTempInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelScreen.SuspendLayout();
            this.panelCover.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerForTempInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScreen
            // 
            this.panelScreen.Controls.Add(this.labelTempInfo);
            this.panelScreen.Location = new System.Drawing.Point(12, 61);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(165, 320);
            this.panelScreen.TabIndex = 0;
            // 
            // panelCover
            // 
            this.panelCover.Controls.Add(this.label5);
            this.panelCover.Location = new System.Drawing.Point(11, 10);
            this.panelCover.Name = "panelCover";
            this.panelCover.Size = new System.Drawing.Size(468, 45);
            this.panelCover.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(75, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Team3的俄罗斯特产";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            this.labelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelInfo.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Green;
            this.labelInfo.Location = new System.Drawing.Point(198, 161);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(286, 39);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 116);
            this.label1.TabIndex = 2;
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelScore.Location = new System.Drawing.Point(77, 56);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(121, 31);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(198, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewPanelScreen
            // 
            this.viewPanelScreen.BackColor = System.Drawing.SystemColors.Control;
            this.viewPanelScreen.Location = new System.Drawing.Point(198, 87);
            this.viewPanelScreen.Name = "viewPanelScreen";
            this.viewPanelScreen.Size = new System.Drawing.Size(66, 58);
            this.viewPanelScreen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lever";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLever
            // 
            this.labelLever.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLever.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelLever.Location = new System.Drawing.Point(77, 24);
            this.labelLever.Name = "labelLever";
            this.labelLever.Size = new System.Drawing.Size(110, 32);
            this.labelLever.TabIndex = 2;
            this.labelLever.Text = "1";
            this.labelLever.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerForTempInfo
            // 
            this.timerForTempInfo.AutoReset = false;
            this.timerForTempInfo.Enabled = true;
            this.timerForTempInfo.Interval = 2000D;
            this.timerForTempInfo.SynchronizingObject = this;
            this.timerForTempInfo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerForTempInfo_Elapsed);
            // 
            // labelTempInfo
            // 
            this.labelTempInfo.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempInfo.ForeColor = System.Drawing.Color.Red;
            this.labelTempInfo.Location = new System.Drawing.Point(0, -3);
            this.labelTempInfo.Name = "labelTempInfo";
            this.labelTempInfo.Size = new System.Drawing.Size(165, 34);
            this.labelTempInfo.TabIndex = 4;
            this.labelTempInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTempInfo.TextChanged += new System.EventHandler(this.labelTempInfo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelScore);
            this.groupBox2.Controls.Add(this.labelLever);
            this.groupBox2.Location = new System.Drawing.Point(270, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 93);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(195, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "下一个：";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(11, 23);
            this.ClientSize = new System.Drawing.Size(513, 393);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.panelCover);
            this.Controls.Add(this.panelScreen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.viewPanelScreen);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.panelScreen.ResumeLayout(false);
            this.panelCover.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerForTempInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void FormMain_Load(object sender, System.EventArgs e)
		{
			//this.panelScreen.Width = Globals.WidthOfScreen;
			//this.panelScreen.Height = Globals.HeightOfScreen;

            Control.CheckForIllegalCrossThreadCalls = false;

			//显示网格背景方块
			for(int i=3; i<Globals.CountOfRow-1; i++)
			{
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					this.panelScreen.Controls.Add(Globals.BackBlocks[i,j]);
					Globals.BackBlocks[i,j].BringToFront();
				}
			}

			//加载动态方块
			for(int i=0; i<4; i++)
			{
				this.panelScreen.Controls.Add(Globals.DynamicBlocksArray[i]);
				Globals.DynamicBlocksArray[i].BringToFront();
			}

			//加载预览方块
			for(int i=0; i<4; i++)
			{
				this.viewPanelScreen.Controls.Add(Globals.ViewDynamicBlocksArray[i]);
				Globals.ViewDynamicBlocksArray[i].BringToFront();

			}

		}

		

		//按键
		private void FormMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Left)
			{
				if(Game.CanOp)
				{
					MoveAndRotate.ToLeft(Globals.IndexOfCurrentShape);
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Left.wav",IntPtr.Zero,1);
				}
			}
			else if(e.KeyCode == Keys.Right)
			{
				if(Game.CanOp)
				{
					MoveAndRotate.ToRight(Globals.IndexOfCurrentShape);
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Right.wav",IntPtr.Zero,1);
				}
			}
			else if(e.KeyCode == Keys.Down)
			{
				if(Game.CanOp)
				{
					AllShapes.timer.Stop();
					MoveAndRotate.ToDown(Globals.IndexOfCurrentShape);
					AllShapes.timer.Start();
				}
			}
			else if(e.KeyCode == Keys.Up)
			{
				if(Game.CanOp)
				{
					MoveAndRotate.Eddy(Globals.IndexOfCurrentShape);
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Up.wav",IntPtr.Zero,1);
				}
			}
			else if(e.KeyCode == Keys.Q)
			{
				Game.StartNewGame();
			}
			else if(e.KeyCode == Keys.P)
			{
				if(Game.State == GameStates.Playing)
				{
					Game.Pause();
				}
				else if(Game.State == GameStates.Paused)
				{
					Game.Resume();
				}
			}
			else if(e.KeyCode == Keys.O)//设置
			{
				Game.Pause();
				FormSet fs = new FormSet();
				fs.ShowDialog();
			}
			else if(e.KeyCode == Keys.S)//save
			{
				Game.Pause();
				FormSave fs = new FormSave();
				fs.ShowDialog();
			}
			else if(e.KeyCode == Keys.L)//Load
			{
				Game.Pause();
				FormLoad fL = new FormLoad();
				fL.ShowDialog();
			}
			else if(e.KeyCode == Keys.D1)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(1);	
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D2)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(2);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D3)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(3);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D4)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(4);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D5)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(5);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D6)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(6);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D7)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(7);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D8)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(8);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
			else if(e.KeyCode == Keys.D9)
			{
				if(Game.State == GameStates.Stoped)
				{
					Game.ChangeLevel(9);
				}
				else
				{
					this.labelTempInfo.Text = "游戏过程中不可设置速度级别";
				}
			}
		}

		private void label1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.label1.Text = "←  →  ↓ 控制方向   ↑ 旋转\nQ  开始新游戏\nP 暂停或继续   O 设置"+
				"\nS 保存    L 加载存档  \n1～9 改变级别";
		}

		private void timerForTempInfo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.labelTempInfo.Text = "";
		}

		private void labelTempInfo_TextChanged(object sender, System.EventArgs e)
		{
			if(this.labelTempInfo.Text.Length != 0)
			{
				this.timerForTempInfo.Start();
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click_1(object sender, EventArgs e)
		{

		}
	}
}
