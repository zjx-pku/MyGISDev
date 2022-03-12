namespace MyGIS.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建工作空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开工作空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存工作空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地层界线点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑成图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助主题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.标注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一般图形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图查属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地质路线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地层界线点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.断层采集点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.褶皱采集点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矿产采集点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.样品采集点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.化石采集点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(223, 71);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(573, 375);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.axMapControl2.Location = new System.Drawing.Point(8, 259);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(209, 187);
            this.axMapControl2.TabIndex = 1;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(8, 71);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(209, 182);
            this.axTOCControl1.TabIndex = 2;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(12, 35);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1194, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(1065, 649);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性表ToolStripMenuItem,
            this.移除图层ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 60);
            // 
            // 属性表ToolStripMenuItem
            // 
            this.属性表ToolStripMenuItem.Name = "属性表ToolStripMenuItem";
            this.属性表ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.属性表ToolStripMenuItem.Text = "属性表";
            this.属性表ToolStripMenuItem.Click += new System.EventHandler(this.属性表ToolStripMenuItem_Click);
            // 
            // 移除图层ToolStripMenuItem
            // 
            this.移除图层ToolStripMenuItem.Name = "移除图层ToolStripMenuItem";
            this.移除图层ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.移除图层ToolStripMenuItem.Text = "移除图层";
            this.移除图层ToolStripMenuItem.Click += new System.EventHandler(this.移除图层ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.数据采集ToolStripMenuItem,
            this.数据管理ToolStripMenuItem,
            this.编辑成图ToolStripMenuItem,
            this.空间分析ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1218, 32);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建工作空间ToolStripMenuItem,
            this.打开工作空间ToolStripMenuItem,
            this.保存工作空间ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建工作空间ToolStripMenuItem
            // 
            this.新建工作空间ToolStripMenuItem.Name = "新建工作空间ToolStripMenuItem";
            this.新建工作空间ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.新建工作空间ToolStripMenuItem.Text = "新建工作空间";
            // 
            // 打开工作空间ToolStripMenuItem
            // 
            this.打开工作空间ToolStripMenuItem.Name = "打开工作空间ToolStripMenuItem";
            this.打开工作空间ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.打开工作空间ToolStripMenuItem.Text = "打开工作空间";
            // 
            // 保存工作空间ToolStripMenuItem
            // 
            this.保存工作空间ToolStripMenuItem.Name = "保存工作空间ToolStripMenuItem";
            this.保存工作空间ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.保存工作空间ToolStripMenuItem.Text = "保存工作空间";
            // 
            // 数据采集ToolStripMenuItem
            // 
            this.数据采集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地层界线点ToolStripMenuItem,
            this.地质路线ToolStripMenuItem,
            this.地层界线点ToolStripMenuItem1,
            this.断层采集点ToolStripMenuItem,
            this.褶皱采集点ToolStripMenuItem,
            this.矿产采集点ToolStripMenuItem,
            this.样品采集点ToolStripMenuItem,
            this.化石采集点ToolStripMenuItem});
            this.数据采集ToolStripMenuItem.Name = "数据采集ToolStripMenuItem";
            this.数据采集ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.数据采集ToolStripMenuItem.Text = "数据采集";
            // 
            // 地层界线点ToolStripMenuItem
            // 
            this.地层界线点ToolStripMenuItem.Name = "地层界线点ToolStripMenuItem";
            this.地层界线点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.地层界线点ToolStripMenuItem.Text = "填图人员";
            this.地层界线点ToolStripMenuItem.Click += new System.EventHandler(this.地层界线点ToolStripMenuItem_Click);
            // 
            // 编辑成图ToolStripMenuItem
            // 
            this.编辑成图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.点ToolStripMenuItem,
            this.线ToolStripMenuItem,
            this.标注ToolStripMenuItem,
            this.一般图形ToolStripMenuItem});
            this.编辑成图ToolStripMenuItem.Name = "编辑成图ToolStripMenuItem";
            this.编辑成图ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.编辑成图ToolStripMenuItem.Text = "编辑成图";
            // 
            // 点ToolStripMenuItem
            // 
            this.点ToolStripMenuItem.Name = "点ToolStripMenuItem";
            this.点ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.点ToolStripMenuItem.Text = "地层线";
            this.点ToolStripMenuItem.Click += new System.EventHandler(this.点ToolStripMenuItem_Click);
            // 
            // 线ToolStripMenuItem
            // 
            this.线ToolStripMenuItem.Name = "线ToolStripMenuItem";
            this.线ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.线ToolStripMenuItem.Text = "断层线";
            this.线ToolStripMenuItem.Click += new System.EventHandler(this.折线ToolStripMenuItem_Click);
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图查属性ToolStripMenuItem,
            this.属性查图ToolStripMenuItem});
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助主题ToolStripMenuItem,
            this.关于软件ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.关于ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助主题ToolStripMenuItem
            // 
            this.帮助主题ToolStripMenuItem.Name = "帮助主题ToolStripMenuItem";
            this.帮助主题ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.帮助主题ToolStripMenuItem.Text = "帮助主题";
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1021);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1218, 29);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(195, 24);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // 标注ToolStripMenuItem
            // 
            this.标注ToolStripMenuItem.Name = "标注ToolStripMenuItem";
            this.标注ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.标注ToolStripMenuItem.Text = "标注";
            // 
            // 一般图形ToolStripMenuItem
            // 
            this.一般图形ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.点ToolStripMenuItem1,
            this.线ToolStripMenuItem1,
            this.面ToolStripMenuItem});
            this.一般图形ToolStripMenuItem.Name = "一般图形ToolStripMenuItem";
            this.一般图形ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.一般图形ToolStripMenuItem.Text = "一般图形";
            // 
            // 点ToolStripMenuItem1
            // 
            this.点ToolStripMenuItem1.Name = "点ToolStripMenuItem1";
            this.点ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.点ToolStripMenuItem1.Text = "点";
            // 
            // 线ToolStripMenuItem1
            // 
            this.线ToolStripMenuItem1.Name = "线ToolStripMenuItem1";
            this.线ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.线ToolStripMenuItem1.Text = "线";
            // 
            // 面ToolStripMenuItem
            // 
            this.面ToolStripMenuItem.Name = "面ToolStripMenuItem";
            this.面ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.面ToolStripMenuItem.Text = "面";
            // 
            // 图查属性ToolStripMenuItem
            // 
            this.图查属性ToolStripMenuItem.Name = "图查属性ToolStripMenuItem";
            this.图查属性ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.图查属性ToolStripMenuItem.Text = "图查属性";
            // 
            // 属性查图ToolStripMenuItem
            // 
            this.属性查图ToolStripMenuItem.Name = "属性查图ToolStripMenuItem";
            this.属性查图ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.属性查图ToolStripMenuItem.Text = "属性查图";
            // 
            // 地质路线ToolStripMenuItem
            // 
            this.地质路线ToolStripMenuItem.Name = "地质路线ToolStripMenuItem";
            this.地质路线ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.地质路线ToolStripMenuItem.Text = "地质路线";
            // 
            // 地层界线点ToolStripMenuItem1
            // 
            this.地层界线点ToolStripMenuItem1.Name = "地层界线点ToolStripMenuItem1";
            this.地层界线点ToolStripMenuItem1.Size = new System.Drawing.Size(170, 28);
            this.地层界线点ToolStripMenuItem1.Text = "地层界线点";
            this.地层界线点ToolStripMenuItem1.Click += new System.EventHandler(this.地层界线点ToolStripMenuItem1_Click);
            // 
            // 断层采集点ToolStripMenuItem
            // 
            this.断层采集点ToolStripMenuItem.Name = "断层采集点ToolStripMenuItem";
            this.断层采集点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.断层采集点ToolStripMenuItem.Text = "断层采集点";
            // 
            // 褶皱采集点ToolStripMenuItem
            // 
            this.褶皱采集点ToolStripMenuItem.Name = "褶皱采集点ToolStripMenuItem";
            this.褶皱采集点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.褶皱采集点ToolStripMenuItem.Text = "褶皱采集点";
            // 
            // 矿产采集点ToolStripMenuItem
            // 
            this.矿产采集点ToolStripMenuItem.Name = "矿产采集点ToolStripMenuItem";
            this.矿产采集点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.矿产采集点ToolStripMenuItem.Text = "矿产采集点";
            // 
            // 样品采集点ToolStripMenuItem
            // 
            this.样品采集点ToolStripMenuItem.Name = "样品采集点ToolStripMenuItem";
            this.样品采集点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.样品采集点ToolStripMenuItem.Text = "样品采集点";
            // 
            // 化石采集点ToolStripMenuItem
            // 
            this.化石采集点ToolStripMenuItem.Name = "化石采集点ToolStripMenuItem";
            this.化石采集点ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.化石采集点ToolStripMenuItem.Text = "化石采集点";
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据管理ToolStripMenuItem1});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 数据管理ToolStripMenuItem1
            // 
            this.数据管理ToolStripMenuItem1.Name = "数据管理ToolStripMenuItem1";
            this.数据管理ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.数据管理ToolStripMenuItem1.Text = "数据管理";
            this.数据管理ToolStripMenuItem1.Click += new System.EventHandler(this.地层界线点ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 1050);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axMapControl1);
            this.Name = "MainForm";
            this.Text = "区域地质调查填图辅助系统";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除图层ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地层界线点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助主题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 编辑成图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标注ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 一般图形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 线ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地质路线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地层界线点ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 断层采集点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 褶皱采集点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矿产采集点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 样品采集点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 化石采集点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图查属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem1;


    }
}