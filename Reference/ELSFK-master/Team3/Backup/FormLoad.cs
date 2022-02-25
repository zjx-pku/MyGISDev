using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Tetris2
{
	/// <summary>
	/// FormLoad 的摘要说明。
	/// </summary>
	public class FormLoad : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listViewFiles;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonLoad;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormLoad()
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
			this.listViewFiles = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listViewFiles
			// 
			this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader1,
																							this.columnHeader2});
			this.listViewFiles.FullRowSelect = true;
			this.listViewFiles.Location = new System.Drawing.Point(0, 0);
			this.listViewFiles.MultiSelect = false;
			this.listViewFiles.Name = "listViewFiles";
			this.listViewFiles.Size = new System.Drawing.Size(304, 120);
			this.listViewFiles.TabIndex = 0;
			this.listViewFiles.View = System.Windows.Forms.View.Details;
			this.listViewFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewFiles_MouseDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "存档";
			this.columnHeader1.Width = 137;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "文件位置";
			this.columnHeader2.Width = 146;
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(152, 122);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(64, 20);
			this.buttonDel.TabIndex = 1;
			this.buttonDel.Text = "Del";
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(232, 123);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(64, 20);
			this.buttonLoad.TabIndex = 1;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// FormLoad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 144);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.listViewFiles);
			this.Controls.Add(this.buttonLoad);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(310, 168);
			this.Name = "FormLoad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormLoad";
			this.Load += new System.EventHandler(this.FormLoad_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormLoad_Load(object sender, System.EventArgs e)
		{
			try
			{
				DirectoryInfo dInfo = new DirectoryInfo(SaveOrOpen.Directory);
				FileInfo[] files = dInfo.GetFiles("*.dt");

				foreach(FileInfo file in files)
				{
					ListViewItem lvi = new ListViewItem(new string[]{file.Name.Substring(0,file.Name.IndexOf(".")), file.FullName});
					this.listViewFiles.Items.Add(lvi);
				}
			}
			catch{}
		}

		private void listViewFiles_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Clicks>1)
			{
				if(SaveOrOpen.LoadGame(this.listViewFiles.GetItemAt(e.X,e.Y).SubItems[1].Text))
				{
					Game.Start();
					this.Close();
				}
			}
		}

		private void buttonDel_Click(object sender, System.EventArgs e)
		{
			if(this.listViewFiles.SelectedItems.Count>0)
			{
				try
				{
				
					string  path = this.listViewFiles.SelectedItems[0].SubItems[1].Text;
					File.Delete(path);
				}
				catch(Exception ex)
				{
					MessageBox.Show("删除失败!\n原因是:\n"+ex.Message);
					return;
				}

				this.listViewFiles.Items.Remove(this.listViewFiles.SelectedItems[0]);
			}

		}

		private void buttonLoad_Click(object sender, System.EventArgs e)
		{
			if(this.listViewFiles.SelectedItems.Count>0 && 
				SaveOrOpen.LoadGame(this.listViewFiles.SelectedItems[0].SubItems[1].Text))
			{
				Game.Start();
				this.Close();
			}
		}


	}
}
