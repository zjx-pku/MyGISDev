using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Team3
{
	/// <summary>
	/// FormSave 的摘要说明。
	/// </summary>
	public class FormSave : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ListBox listBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSave()
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
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// textBoxInput
			// 
			this.textBoxInput.Location = new System.Drawing.Point(8, 8);
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(208, 21);
			this.textBoxInput.TabIndex = 0;
			this.textBoxInput.Text = "";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(224, 8);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(64, 20);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Save";
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(8, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(280, 112);
			this.listBox1.TabIndex = 2;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// FormSave
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(296, 158);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(302, 182);
			this.Name = "FormSave";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormSave";
			this.Load += new System.EventHandler(this.FormSave_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonSave_Click(object sender, System.EventArgs e)
		{
			if(this.textBoxInput.Text.Trim().Length == 0)
			{
				return;
			}

			if( SaveOrOpen.SaveGame(this.textBoxInput.Text))
			{
				this.Close();
			}

		}

		private void FormSave_Load(object sender, System.EventArgs e)
		{
			DirectoryInfo dInfo = new DirectoryInfo(SaveOrOpen.Directory);
			FileInfo[] files = dInfo.GetFiles("*.dt");

			foreach(FileInfo file in files)
			{
				this.listBox1.Items.Add(   file.Name.Substring(0,file.Name.IndexOf("."))  );
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.textBoxInput.Text = this.listBox1.SelectedItem.ToString();
		}
	}
}
