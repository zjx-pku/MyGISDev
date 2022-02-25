using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tetris2
{
	/// <summary>
	/// FormSet 的摘要说明。
	/// </summary>
	public class FormSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBoxBack;
		private System.Windows.Forms.CheckBox checkBoxShowBackGird;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelBackColor;
		private System.Windows.Forms.Button buttonSetBackColor;
		private System.Windows.Forms.GroupBox groupBoxBlock;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelFixedBlockColor;
		private System.Windows.Forms.Label labelViewBlockColor;
		private System.Windows.Forms.Label labelDynamicBlockColor;
		private System.Windows.Forms.Button buttonSetDynamicColor;
		private System.Windows.Forms.Button buttonSetFixedColor;
		private System.Windows.Forms.Button buttonSetViewColor;
		private System.Windows.Forms.GroupBox groupBoxSound;
		private System.Windows.Forms.CheckBox checkBoxSound;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.CheckBox checkBoxMusic;
		private System.Windows.Forms.DomainUpDown domainUpDownVolume;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSet()
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
				if(components != null)
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
			this.groupBoxBack = new System.Windows.Forms.GroupBox();
			this.buttonSetBackColor = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxShowBackGird = new System.Windows.Forms.CheckBox();
			this.labelBackColor = new System.Windows.Forms.Label();
			this.groupBoxBlock = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelFixedBlockColor = new System.Windows.Forms.Label();
			this.labelViewBlockColor = new System.Windows.Forms.Label();
			this.labelDynamicBlockColor = new System.Windows.Forms.Label();
			this.buttonSetDynamicColor = new System.Windows.Forms.Button();
			this.buttonSetFixedColor = new System.Windows.Forms.Button();
			this.buttonSetViewColor = new System.Windows.Forms.Button();
			this.groupBoxSound = new System.Windows.Forms.GroupBox();
			this.domainUpDownVolume = new System.Windows.Forms.DomainUpDown();
			this.checkBoxSound = new System.Windows.Forms.CheckBox();
			this.checkBoxMusic = new System.Windows.Forms.CheckBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBoxBack.SuspendLayout();
			this.groupBoxBlock.SuspendLayout();
			this.groupBoxSound.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxBack
			// 
			this.groupBoxBack.Controls.Add(this.buttonSetBackColor);
			this.groupBoxBack.Controls.Add(this.label1);
			this.groupBoxBack.Controls.Add(this.checkBoxShowBackGird);
			this.groupBoxBack.Controls.Add(this.labelBackColor);
			this.groupBoxBack.Location = new System.Drawing.Point(8, 8);
			this.groupBoxBack.Name = "groupBoxBack";
			this.groupBoxBack.Size = new System.Drawing.Size(320, 80);
			this.groupBoxBack.TabIndex = 0;
			this.groupBoxBack.TabStop = false;
			this.groupBoxBack.Text = "背景   ";
			// 
			// buttonSetBackColor
			// 
			this.buttonSetBackColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.buttonSetBackColor.Location = new System.Drawing.Point(232, 40);
			this.buttonSetBackColor.Name = "buttonSetBackColor";
			this.buttonSetBackColor.Size = new System.Drawing.Size(64, 24);
			this.buttonSetBackColor.TabIndex = 2;
			this.buttonSetBackColor.Text = "更改 ";
			this.buttonSetBackColor.Click += new System.EventHandler(this.buttonSetBackColor_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "背景网格颜色";
			// 
			// checkBoxShowBackGird
			// 
			this.checkBoxShowBackGird.Checked = true;
			this.checkBoxShowBackGird.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxShowBackGird.Location = new System.Drawing.Point(16, 16);
			this.checkBoxShowBackGird.Name = "checkBoxShowBackGird";
			this.checkBoxShowBackGird.Size = new System.Drawing.Size(120, 24);
			this.checkBoxShowBackGird.TabIndex = 0;
			this.checkBoxShowBackGird.Text = "显示背景网格";
			this.checkBoxShowBackGird.CheckedChanged += new System.EventHandler(this.checkBoxShowBackGird_CheckedChanged);
			// 
			// labelBackColor
			// 
			this.labelBackColor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.labelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelBackColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelBackColor.Location = new System.Drawing.Point(144, 40);
			this.labelBackColor.Name = "labelBackColor";
			this.labelBackColor.Size = new System.Drawing.Size(64, 24);
			this.labelBackColor.TabIndex = 1;
			// 
			// groupBoxBlock
			// 
			this.groupBoxBlock.Controls.Add(this.label2);
			this.groupBoxBlock.Controls.Add(this.label3);
			this.groupBoxBlock.Controls.Add(this.label4);
			this.groupBoxBlock.Controls.Add(this.labelFixedBlockColor);
			this.groupBoxBlock.Controls.Add(this.labelViewBlockColor);
			this.groupBoxBlock.Controls.Add(this.labelDynamicBlockColor);
			this.groupBoxBlock.Controls.Add(this.buttonSetDynamicColor);
			this.groupBoxBlock.Controls.Add(this.buttonSetFixedColor);
			this.groupBoxBlock.Controls.Add(this.buttonSetViewColor);
			this.groupBoxBlock.Location = new System.Drawing.Point(8, 96);
			this.groupBoxBlock.Name = "groupBoxBlock";
			this.groupBoxBlock.Size = new System.Drawing.Size(320, 112);
			this.groupBoxBlock.TabIndex = 1;
			this.groupBoxBlock.TabStop = false;
			this.groupBoxBlock.Text = "方块";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "活动方块颜色";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "固定方块颜色";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "预览方块颜色";
			// 
			// labelFixedBlockColor
			// 
			this.labelFixedBlockColor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.labelFixedBlockColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelFixedBlockColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelFixedBlockColor.Location = new System.Drawing.Point(144, 48);
			this.labelFixedBlockColor.Name = "labelFixedBlockColor";
			this.labelFixedBlockColor.Size = new System.Drawing.Size(64, 24);
			this.labelFixedBlockColor.TabIndex = 1;
			// 
			// labelViewBlockColor
			// 
			this.labelViewBlockColor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.labelViewBlockColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelViewBlockColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelViewBlockColor.Location = new System.Drawing.Point(144, 80);
			this.labelViewBlockColor.Name = "labelViewBlockColor";
			this.labelViewBlockColor.Size = new System.Drawing.Size(64, 24);
			this.labelViewBlockColor.TabIndex = 1;
			// 
			// labelDynamicBlockColor
			// 
			this.labelDynamicBlockColor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.labelDynamicBlockColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelDynamicBlockColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelDynamicBlockColor.Location = new System.Drawing.Point(144, 16);
			this.labelDynamicBlockColor.Name = "labelDynamicBlockColor";
			this.labelDynamicBlockColor.Size = new System.Drawing.Size(64, 24);
			this.labelDynamicBlockColor.TabIndex = 1;
			// 
			// buttonSetDynamicColor
			// 
			this.buttonSetDynamicColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.buttonSetDynamicColor.Location = new System.Drawing.Point(232, 16);
			this.buttonSetDynamicColor.Name = "buttonSetDynamicColor";
			this.buttonSetDynamicColor.Size = new System.Drawing.Size(64, 24);
			this.buttonSetDynamicColor.TabIndex = 2;
			this.buttonSetDynamicColor.Text = "更改 ";
			this.buttonSetDynamicColor.Click += new System.EventHandler(this.buttonSetDynamicColor_Click);
			// 
			// buttonSetFixedColor
			// 
			this.buttonSetFixedColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.buttonSetFixedColor.Location = new System.Drawing.Point(232, 48);
			this.buttonSetFixedColor.Name = "buttonSetFixedColor";
			this.buttonSetFixedColor.Size = new System.Drawing.Size(64, 24);
			this.buttonSetFixedColor.TabIndex = 2;
			this.buttonSetFixedColor.Text = "更改 ";
			this.buttonSetFixedColor.Click += new System.EventHandler(this.buttonSetFixedColor_Click);
			// 
			// buttonSetViewColor
			// 
			this.buttonSetViewColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.buttonSetViewColor.Location = new System.Drawing.Point(232, 80);
			this.buttonSetViewColor.Name = "buttonSetViewColor";
			this.buttonSetViewColor.Size = new System.Drawing.Size(64, 24);
			this.buttonSetViewColor.TabIndex = 2;
			this.buttonSetViewColor.Text = "更改 ";
			this.buttonSetViewColor.Click += new System.EventHandler(this.buttonSetViewColor_Click);
			// 
			// groupBoxSound
			// 
			this.groupBoxSound.Controls.Add(this.domainUpDownVolume);
			this.groupBoxSound.Controls.Add(this.checkBoxSound);
			this.groupBoxSound.Controls.Add(this.checkBoxMusic);
			this.groupBoxSound.Location = new System.Drawing.Point(8, 216);
			this.groupBoxSound.Name = "groupBoxSound";
			this.groupBoxSound.Size = new System.Drawing.Size(232, 48);
			this.groupBoxSound.TabIndex = 2;
			this.groupBoxSound.TabStop = false;
			this.groupBoxSound.Text = "声音";
			// 
			// domainUpDownVolume
			// 
			this.domainUpDownVolume.Items.Add("9");
			this.domainUpDownVolume.Items.Add("8");
			this.domainUpDownVolume.Items.Add("7");
			this.domainUpDownVolume.Items.Add("6");
			this.domainUpDownVolume.Items.Add("5");
			this.domainUpDownVolume.Items.Add("4");
			this.domainUpDownVolume.Items.Add("3");
			this.domainUpDownVolume.Items.Add("2");
			this.domainUpDownVolume.Items.Add("1");
			this.domainUpDownVolume.Location = new System.Drawing.Point(184, 16);
			this.domainUpDownVolume.Name = "domainUpDownVolume";
			this.domainUpDownVolume.ReadOnly = true;
			this.domainUpDownVolume.Size = new System.Drawing.Size(32, 21);
			this.domainUpDownVolume.TabIndex = 1;
			this.domainUpDownVolume.Text = "1";
			this.domainUpDownVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.domainUpDownVolume.SelectedItemChanged += new System.EventHandler(this.domainUpDownVolume_SelectedItemChanged);
			// 
			// checkBoxSound
			// 
			this.checkBoxSound.Checked = true;
			this.checkBoxSound.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSound.Location = new System.Drawing.Point(16, 16);
			this.checkBoxSound.Name = "checkBoxSound";
			this.checkBoxSound.Size = new System.Drawing.Size(80, 24);
			this.checkBoxSound.TabIndex = 0;
			this.checkBoxSound.Text = "背景音效";
			this.checkBoxSound.CheckedChanged += new System.EventHandler(this.checkBoxSound_CheckedChanged);
			// 
			// checkBoxMusic
			// 
			this.checkBoxMusic.Checked = true;
			this.checkBoxMusic.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxMusic.Location = new System.Drawing.Point(104, 16);
			this.checkBoxMusic.Name = "checkBoxMusic";
			this.checkBoxMusic.Size = new System.Drawing.Size(80, 24);
			this.checkBoxMusic.TabIndex = 0;
			this.checkBoxMusic.Text = "背景音乐";
			this.checkBoxMusic.CheckStateChanged += new System.EventHandler(this.checkBoxMusic_CheckStateChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.buttonOK.Location = new System.Drawing.Point(248, 240);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 24);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "确定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// FormSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(344, 273);
			this.Controls.Add(this.groupBoxSound);
			this.Controls.Add(this.groupBoxBlock);
			this.Controls.Add(this.groupBoxBack);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(350, 297);
			this.Name = "FormSet";
			this.Text = "FormSet";
			this.Load += new System.EventHandler(this.FormSet_Load);
			this.groupBoxBack.ResumeLayout(false);
			this.groupBoxBlock.ResumeLayout(false);
			this.groupBoxSound.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		//初始化
		private void FormSet_Load(object sender, System.EventArgs e)
		{
			this.labelBackColor.BackColor  = Globals.ColorOfBackBlock;
			this.labelDynamicBlockColor.BackColor = Globals.ColorOfDynamicBlock;
			this.labelViewBlockColor.BackColor = Globals.ColorOfViewBlock;
			this.labelFixedBlockColor.BackColor = Globals.ColorOfFixedBlock;
			this.checkBoxSound.Checked = Globals.HasSound;
			this.checkBoxShowBackGird.Checked = Globals.IsShowBackBlock;
			this.checkBoxMusic.Checked = Globals.IsPlayBackMusic;
			this.domainUpDownVolume.SelectedIndex = 9 - Globals.SoundLevel/100;
		}

		//设置背景方块颜色
		private void buttonSetBackColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.labelBackColor.BackColor;
			if(this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				this.labelBackColor.BackColor = this.colorDialog1.Color;
				Globals.ColorOfBackBlock = this.colorDialog1.Color;
			}
		}

		//设置动态方块颜色
		private void buttonSetDynamicColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.labelDynamicBlockColor.BackColor;
			if(this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				this.labelDynamicBlockColor.BackColor = this.colorDialog1.Color;
				Globals.ColorOfDynamicBlock = this.colorDialog1.Color;
			}
		}

		//设置固定方块颜色
		private void buttonSetFixedColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.labelFixedBlockColor.BackColor;
			if(this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				this.labelFixedBlockColor.BackColor = this.colorDialog1.Color;
				Globals.ColorOfFixedBlock = this.colorDialog1.Color;
			}
		}

		//设置预览颜色
		private void buttonSetViewColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.labelViewBlockColor.BackColor;
			if(this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				this.labelViewBlockColor.BackColor = this.colorDialog1.Color;
				Globals.ColorOfViewBlock = this.colorDialog1.Color;
			}
		}

		//开启关闭背景网格
		private void checkBoxShowBackGird_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.checkBoxShowBackGird.Checked)
			{
				this.buttonSetBackColor.Enabled = true;
				Globals.IsShowBackBlock = true;
				if(this.labelBackColor.BackColor == System.Drawing.SystemColors.Control)
				{
					this.labelBackColor.BackColor = Color.LightCyan;
				}
				Globals.ColorOfBackBlock =  this.labelBackColor.BackColor;
			}
			else
			{
				this.buttonSetBackColor.Enabled = false;
				Globals.IsShowBackBlock = false;
				Globals.ColorOfBackBlock =  System.Drawing.SystemColors.Control;
			}
		}

		//开启关闭声音
		private void checkBoxSound_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.checkBoxSound.Checked)
			{
				Globals.HasSound = true;
			}
			else
			{
			    Globals.HasSound = false;
			}
		}

		//关闭窗口
		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//开启关闭背景音乐
		private void checkBoxMusic_CheckStateChanged(object sender, System.EventArgs e)
		{
			if(this.checkBoxMusic.Checked)
			{
				Globals.IsPlayBackMusic = true;
				Sound.PlayMusic(Globals.PathOfBackMusic,true);
			}
			else
			{
				Globals.IsPlayBackMusic = false;
				Sound.StopMusic();
			}
		}

		private void domainUpDownVolume_SelectedItemChanged(object sender, System.EventArgs e)
		{
			if(Globals.IsPlayBackMusic)
			{
				Sound.ResumeMusic();
			}
			Globals.SoundLevel = int.Parse(this.domainUpDownVolume.SelectedItem.ToString())*100;
		}

		
	}
}
