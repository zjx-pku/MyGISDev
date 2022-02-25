using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Tetris2
{
	/// <summary>
	/// Form1 ��ժҪ˵����
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		
		
	
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.viewPanelScreen = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.labelLever = new System.Windows.Forms.Label();
			this.timerForTempInfo = new System.Timers.Timer();
			this.labelTempInfo = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panelCover.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timerForTempInfo)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelScreen
			// 
			this.panelScreen.Location = new System.Drawing.Point(8, 16);
			this.panelScreen.Name = "panelScreen";
			this.panelScreen.Size = new System.Drawing.Size(120, 264);
			this.panelScreen.TabIndex = 0;
			// 
			// panelCover
			// 
			this.panelCover.Controls.Add(this.label5);
			this.panelCover.Location = new System.Drawing.Point(8, 8);
			this.panelCover.Name = "panelCover";
			this.panelCover.Size = new System.Drawing.Size(128, 40);
			this.panelCover.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 24);
			this.label5.TabIndex = 2;
			this.label5.Text = "T e T r i s";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelInfo
			// 
			this.labelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelInfo.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelInfo.ForeColor = System.Drawing.Color.Green;
			this.labelInfo.Location = new System.Drawing.Point(144, 120);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(208, 32);
			this.labelInfo.TabIndex = 2;
			this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Teal;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 96);
			this.label1.TabIndex = 2;
			this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// labelScore
			// 
			this.labelScore.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelScore.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.labelScore.Location = new System.Drawing.Point(264, 48);
			this.labelScore.Name = "labelScore";
			this.labelScore.Size = new System.Drawing.Size(88, 16);
			this.labelScore.TabIndex = 2;
			this.labelScore.Text = "0";
			this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.ForeColor = System.Drawing.Color.Teal;
			this.groupBox1.Location = new System.Drawing.Point(144, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 112);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.Enabled = false;
			this.label4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "zhou yinhui 2006.1.12";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Green;
			this.label2.Location = new System.Drawing.Point(208, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Score";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// viewPanelScreen
			// 
			this.viewPanelScreen.BackColor = System.Drawing.SystemColors.Control;
			this.viewPanelScreen.Location = new System.Drawing.Point(144, 48);
			this.viewPanelScreen.Name = "viewPanelScreen";
			this.viewPanelScreen.Size = new System.Drawing.Size(48, 48);
			this.viewPanelScreen.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Green;
			this.label3.Location = new System.Drawing.Point(208, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Lever";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLever
			// 
			this.labelLever.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelLever.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.labelLever.Location = new System.Drawing.Point(272, 24);
			this.labelLever.Name = "labelLever";
			this.labelLever.Size = new System.Drawing.Size(80, 16);
			this.labelLever.TabIndex = 2;
			this.labelLever.Text = "1";
			this.labelLever.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerForTempInfo
			// 
			this.timerForTempInfo.AutoReset = false;
			this.timerForTempInfo.Enabled = true;
			this.timerForTempInfo.Interval = 2000;
			this.timerForTempInfo.SynchronizingObject = this;
			this.timerForTempInfo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerForTempInfo_Elapsed);
			// 
			// labelTempInfo
			// 
			this.labelTempInfo.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelTempInfo.ForeColor = System.Drawing.Color.Red;
			this.labelTempInfo.Location = new System.Drawing.Point(144, 104);
			this.labelTempInfo.Name = "labelTempInfo";
			this.labelTempInfo.Size = new System.Drawing.Size(208, 16);
			this.labelTempInfo.TabIndex = 4;
			this.labelTempInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelTempInfo.TextChanged += new System.EventHandler(this.labelTempInfo_TextChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(200, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(160, 96);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(368, 293);
			this.Controls.Add(this.labelTempInfo);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.panelCover);
			this.Controls.Add(this.panelScreen);
			this.Controls.Add(this.labelScore);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelLever);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.viewPanelScreen);
			this.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormMain";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.panelCover.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.timerForTempInfo)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void FormMain_Load(object sender, System.EventArgs e)
		{
			//this.panelScreen.Width = Globals.WidthOfScreen;
			//this.panelScreen.Height = Globals.HeightOfScreen;

            Control.CheckForIllegalCrossThreadCalls = false;

			//��ʾ���񱳾�����
			for(int i=3; i<Globals.CountOfRow-1; i++)
			{
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					this.panelScreen.Controls.Add(Globals.BackBlocks[i,j]);
					Globals.BackBlocks[i,j].BringToFront();
				}
			}

			//���ض�̬����
			for(int i=0; i<4; i++)
			{
				this.panelScreen.Controls.Add(Globals.DynamicBlocksArray[i]);
				Globals.DynamicBlocksArray[i].BringToFront();
			}

			//����Ԥ������
			for(int i=0; i<4; i++)
			{
				this.viewPanelScreen.Controls.Add(Globals.ViewDynamicBlocksArray[i]);
				Globals.ViewDynamicBlocksArray[i].BringToFront();

			}

		}

		

		//����
		private void FormMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Left)
			{
				if(Game.CanOp)
				{
					AllShapes.ToLeft(Globals.IndexOfCurrentShape);
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Left.wav",IntPtr.Zero,1);
				}
			}
			else if(e.KeyCode == Keys.Right)
			{
				if(Game.CanOp)
				{
					AllShapes.ToRight(Globals.IndexOfCurrentShape);
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Right.wav",IntPtr.Zero,1);
				}
			}
			else if(e.KeyCode == Keys.Down)
			{
				if(Game.CanOp)
				{
					AllShapes.timer.Stop();
					AllShapes.ToDown(Globals.IndexOfCurrentShape);
					AllShapes.timer.Start();
				}
			}
			else if(e.KeyCode == Keys.Up)
			{
				if(Game.CanOp)
				{
					AllShapes.Eddy(Globals.IndexOfCurrentShape);
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
			else if(e.KeyCode == Keys.O)//����
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
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
					this.labelTempInfo.Text = "��Ϸ�����в��������ٶȼ���";
				}
			}
		}

		private void label1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.label1.Text = "��  ��  �� ���Ʒ���   �� ��ת\nQ  ��ʼ����Ϸ\nP ��ͣ�����   O ����"+
				"\nS ����    L ���ش浵  \n1��9 �ı伶��";
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

		
	}
}
