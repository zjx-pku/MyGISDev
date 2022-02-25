namespace WHU2017301110147
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中心放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中心缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.漫游ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全图显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示地点名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭地点名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScaleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CoordinateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(11, 59);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(167, 195);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(182, 59);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(549, 380);
            this.axMapControl1.TabIndex = 1;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            this.axMapControl1.Enter += new System.EventHandler(this.axMapControl1_Enter);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(11, 27);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(199, 28);
            this.axToolbarControl1.TabIndex = 2;
            this.axToolbarControl1.UseWaitCursor = true;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            this.axToolbarControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseMoveEventHandler(this.axToolbarControl1_OnMouseMove);
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(696, 449);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 4;
            this.axLicenseControl2.UseWaitCursor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件管理ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseHover += new System.EventHandler(this.menuStrip1_MouseHover);
            // 
            // 文件管理ToolStripMenuItem
            // 
            this.文件管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载工程ToolStripMenuItem,
            this.加载图层ToolStripMenuItem});
            this.文件管理ToolStripMenuItem.Name = "文件管理ToolStripMenuItem";
            this.文件管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.文件管理ToolStripMenuItem.Text = "文件管理";
            this.文件管理ToolStripMenuItem.Click += new System.EventHandler(this.文件管理ToolStripMenuItem_Click);
            // 
            // 加载工程ToolStripMenuItem
            // 
            this.加载工程ToolStripMenuItem.Name = "加载工程ToolStripMenuItem";
            this.加载工程ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.加载工程ToolStripMenuItem.Text = "加载地图";
            this.加载工程ToolStripMenuItem.Click += new System.EventHandler(this.加载工程ToolStripMenuItem_Click);
            // 
            // 加载图层ToolStripMenuItem
            // 
            this.加载图层ToolStripMenuItem.Name = "加载图层ToolStripMenuItem";
            this.加载图层ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.加载图层ToolStripMenuItem.Text = "加载图层";
            this.加载图层ToolStripMenuItem.Click += new System.EventHandler(this.加载图层ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缩放ToolStripMenuItem,
            this.漫游ToolStripMenuItem,
            this.全图显示ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.中心放大ToolStripMenuItem,
            this.中心缩小ToolStripMenuItem});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.缩放ToolStripMenuItem.Text = "缩放";
            this.缩放ToolStripMenuItem.Click += new System.EventHandler(this.缩放ToolStripMenuItem_Click);
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 中心放大ToolStripMenuItem
            // 
            this.中心放大ToolStripMenuItem.Name = "中心放大ToolStripMenuItem";
            this.中心放大ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.中心放大ToolStripMenuItem.Text = "中心放大";
            this.中心放大ToolStripMenuItem.Click += new System.EventHandler(this.中心放大ToolStripMenuItem_Click);
            // 
            // 中心缩小ToolStripMenuItem
            // 
            this.中心缩小ToolStripMenuItem.Name = "中心缩小ToolStripMenuItem";
            this.中心缩小ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.中心缩小ToolStripMenuItem.Text = "中心缩小";
            this.中心缩小ToolStripMenuItem.Click += new System.EventHandler(this.中心缩小ToolStripMenuItem_Click);
            // 
            // 漫游ToolStripMenuItem
            // 
            this.漫游ToolStripMenuItem.Name = "漫游ToolStripMenuItem";
            this.漫游ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.漫游ToolStripMenuItem.Text = "漫游";
            this.漫游ToolStripMenuItem.Click += new System.EventHandler(this.漫游ToolStripMenuItem_Click);
            // 
            // 全图显示ToolStripMenuItem
            // 
            this.全图显示ToolStripMenuItem.Name = "全图显示ToolStripMenuItem";
            this.全图显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全图显示ToolStripMenuItem.Text = "全图显示";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.toolStripMenuItem1.Text = "导航";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性查询ToolStripMenuItem,
            this.空间查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 属性查询ToolStripMenuItem
            // 
            this.属性查询ToolStripMenuItem.Name = "属性查询ToolStripMenuItem";
            this.属性查询ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.属性查询ToolStripMenuItem.Text = "按属性查找";
            this.属性查询ToolStripMenuItem.Click += new System.EventHandler(this.属性查询ToolStripMenuItem_Click);
            // 
            // 空间查询ToolStripMenuItem
            // 
            this.空间查询ToolStripMenuItem.Name = "空间查询ToolStripMenuItem";
            this.空间查询ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.空间查询ToolStripMenuItem.Text = "按位置查找";
            this.空间查询ToolStripMenuItem.Click += new System.EventHandler(this.空间查询ToolStripMenuItem_Click);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axMapControl2.Location = new System.Drawing.Point(11, 259);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(167, 180);
            this.axMapControl2.TabIndex = 6;
            this.axMapControl2.UseWaitCursor = true;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开属性表ToolStripMenuItem,
            this.显示地点名称ToolStripMenuItem,
            this.关闭地点名称ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            this.打开属性表ToolStripMenuItem.Click += new System.EventHandler(this.打开属性表ToolStripMenuItem_Click);
            this.打开属性表ToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.打开属性表ToolStripMenuItem_MouseDown);
            // 
            // 显示地点名称ToolStripMenuItem
            // 
            this.显示地点名称ToolStripMenuItem.Name = "显示地点名称ToolStripMenuItem";
            this.显示地点名称ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示地点名称ToolStripMenuItem.Text = "显示地点名称";
            this.显示地点名称ToolStripMenuItem.Click += new System.EventHandler(this.显示地点名称ToolStripMenuItem_Click);
            // 
            // 关闭地点名称ToolStripMenuItem
            // 
            this.关闭地点名称ToolStripMenuItem.Name = "关闭地点名称ToolStripMenuItem";
            this.关闭地点名称ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关闭地点名称ToolStripMenuItem.Text = "关闭地点名称";
            this.关闭地点名称ToolStripMenuItem.Click += new System.EventHandler(this.关闭地点名称ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ScaleLabel,
            this.CoordinateLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(742, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.UseWaitCursor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(131, 17);
            this.StatusLabel.Text = "toolStripStatusLabel1";
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(131, 17);
            this.ScaleLabel.Text = "toolStripStatusLabel2";
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(131, 17);
            this.CoordinateLabel.Text = "toolStripStatusLabel3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(675, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 467);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axLicenseControl2);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "武汉大学游览系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseHover += new System.EventHandler(this.MainForm_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件管理ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ScaleLabel;
        private System.Windows.Forms.ToolStripStatusLabel CoordinateLabel;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 漫游ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全图显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中心放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中心缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示地点名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭地点名称ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
    

}

