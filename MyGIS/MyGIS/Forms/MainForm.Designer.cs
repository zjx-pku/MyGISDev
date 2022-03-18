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
            this.新建图层文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图幅数据录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地质路线录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地层界线点数据ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.断层采集点数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.褶皱采集点数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑成图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制地层线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制断层线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图查属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助主题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.新建图层文件ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建图层文件ToolStripMenuItem
            // 
            this.新建图层文件ToolStripMenuItem.Name = "新建图层文件ToolStripMenuItem";
            this.新建图层文件ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.新建图层文件ToolStripMenuItem.Text = "新建图层文件";
            this.新建图层文件ToolStripMenuItem.Click += new System.EventHandler(this.新建图层文件ToolStripMenuItem_Click);
            // 
            // 数据采集ToolStripMenuItem
            // 
            this.数据采集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图幅数据录入ToolStripMenuItem,
            this.地质路线录入ToolStripMenuItem,
            this.地层界线点数据ToolStripMenuItem1,
            this.断层采集点数据ToolStripMenuItem,
            this.褶皱采集点数据ToolStripMenuItem});
            this.数据采集ToolStripMenuItem.Name = "数据采集ToolStripMenuItem";
            this.数据采集ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.数据采集ToolStripMenuItem.Text = "数据采集";
            // 
            // 图幅数据录入ToolStripMenuItem
            // 
            this.图幅数据录入ToolStripMenuItem.Name = "图幅数据录入ToolStripMenuItem";
            this.图幅数据录入ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.图幅数据录入ToolStripMenuItem.Text = "图幅数据录入";
            this.图幅数据录入ToolStripMenuItem.Click += new System.EventHandler(this.图幅数据录入ToolStripMenuItem_Click);
            // 
            // 地质路线录入ToolStripMenuItem
            // 
            this.地质路线录入ToolStripMenuItem.Name = "地质路线录入ToolStripMenuItem";
            this.地质路线录入ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.地质路线录入ToolStripMenuItem.Text = "地质路线录入";
            this.地质路线录入ToolStripMenuItem.Click += new System.EventHandler(this.地质路线录入ToolStripMenuItem_Click);
            // 
            // 地层界线点数据ToolStripMenuItem1
            // 
            this.地层界线点数据ToolStripMenuItem1.Name = "地层界线点数据ToolStripMenuItem1";
            this.地层界线点数据ToolStripMenuItem1.Size = new System.Drawing.Size(206, 28);
            this.地层界线点数据ToolStripMenuItem1.Text = "地层界线点数据";
            this.地层界线点数据ToolStripMenuItem1.Click += new System.EventHandler(this.地层界线点数据ToolStripMenuItem1_Click);
            // 
            // 断层采集点数据ToolStripMenuItem
            // 
            this.断层采集点数据ToolStripMenuItem.Name = "断层采集点数据ToolStripMenuItem";
            this.断层采集点数据ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.断层采集点数据ToolStripMenuItem.Text = "断层采集点数据";
            this.断层采集点数据ToolStripMenuItem.Click += new System.EventHandler(this.断层采集点数据ToolStripMenuItem_Click);
            // 
            // 褶皱采集点数据ToolStripMenuItem
            // 
            this.褶皱采集点数据ToolStripMenuItem.Name = "褶皱采集点数据ToolStripMenuItem";
            this.褶皱采集点数据ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.褶皱采集点数据ToolStripMenuItem.Text = "褶皱采集点数据";
            this.褶皱采集点数据ToolStripMenuItem.Click += new System.EventHandler(this.褶皱采集点数据ToolStripMenuItem_Click);
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
            this.数据管理ToolStripMenuItem1.Click += new System.EventHandler(this.数据管理ToolStripMenuItem_Click);
            // 
            // 编辑成图ToolStripMenuItem
            // 
            this.编辑成图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑状态ToolStripMenuItem,
            this.绘制地层线ToolStripMenuItem,
            this.绘制断层线ToolStripMenuItem});
            this.编辑成图ToolStripMenuItem.Name = "编辑成图ToolStripMenuItem";
            this.编辑成图ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.编辑成图ToolStripMenuItem.Text = "编辑成图";
            // 
            // 编辑状态ToolStripMenuItem
            // 
            this.编辑状态ToolStripMenuItem.Name = "编辑状态ToolStripMenuItem";
            this.编辑状态ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.编辑状态ToolStripMenuItem.Text = "开始编辑";
            this.编辑状态ToolStripMenuItem.Click += new System.EventHandler(this.编辑状态ToolStripMenuItem_Click);
            // 
            // 绘制地层线ToolStripMenuItem
            // 
            this.绘制地层线ToolStripMenuItem.Enabled = false;
            this.绘制地层线ToolStripMenuItem.Name = "绘制地层线ToolStripMenuItem";
            this.绘制地层线ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.绘制地层线ToolStripMenuItem.Text = "绘制地层线";
            this.绘制地层线ToolStripMenuItem.Click += new System.EventHandler(this.绘制地层线ToolStripMenuItem_Click);
            // 
            // 绘制断层线ToolStripMenuItem
            // 
            this.绘制断层线ToolStripMenuItem.Enabled = false;
            this.绘制断层线ToolStripMenuItem.Name = "绘制断层线ToolStripMenuItem";
            this.绘制断层线ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.绘制断层线ToolStripMenuItem.Text = "绘制断层线";
            this.绘制断层线ToolStripMenuItem.Click += new System.EventHandler(this.绘制断层线ToolStripMenuItem_Click);
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
            // 图查属性ToolStripMenuItem
            // 
            this.图查属性ToolStripMenuItem.Name = "图查属性ToolStripMenuItem";
            this.图查属性ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.图查属性ToolStripMenuItem.Text = "图查属性";
            this.图查属性ToolStripMenuItem.Click += new System.EventHandler(this.图查属性ToolStripMenuItem_Click);
            // 
            // 属性查图ToolStripMenuItem
            // 
            this.属性查图ToolStripMenuItem.Name = "属性查图ToolStripMenuItem";
            this.属性查图ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.属性查图ToolStripMenuItem.Text = "属性查图";
            this.属性查图ToolStripMenuItem.Click += new System.EventHandler(this.属性查图ToolStripMenuItem_Click);
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
            this.帮助主题ToolStripMenuItem.Click += new System.EventHandler(this.帮助主题ToolStripMenuItem_Click);
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            this.关于软件ToolStripMenuItem.Click += new System.EventHandler(this.关于软件ToolStripMenuItem_Click);
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
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem 数据采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助主题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 编辑成图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制地层线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制断层线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地质路线录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地层界线点数据ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 断层采集点数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 褶皱采集点数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图查属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图幅数据录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建图层文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;


    }
}