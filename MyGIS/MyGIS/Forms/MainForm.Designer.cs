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
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地层界线点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助主题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.axToolbarControl1.Size = new System.Drawing.Size(427, 28);
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
            this.编辑ToolStripMenuItem,
            this.数据采集ToolStripMenuItem,
            this.空间分析ToolStripMenuItem,
            this.打印输出ToolStripMenuItem,
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
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.重做ToolStripMenuItem,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.撤销ToolStripMenuItem.Text = "撤销";
            // 
            // 重做ToolStripMenuItem
            // 
            this.重做ToolStripMenuItem.Name = "重做ToolStripMenuItem";
            this.重做ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.重做ToolStripMenuItem.Text = "重做";
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.剪切ToolStripMenuItem.Text = "剪切";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 数据采集ToolStripMenuItem
            // 
            this.数据采集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地层界线点ToolStripMenuItem});
            this.数据采集ToolStripMenuItem.Name = "数据采集ToolStripMenuItem";
            this.数据采集ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.数据采集ToolStripMenuItem.Text = "数据采集";
            // 
            // 地层界线点ToolStripMenuItem
            // 
            this.地层界线点ToolStripMenuItem.Name = "地层界线点ToolStripMenuItem";
            this.地层界线点ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.地层界线点ToolStripMenuItem.Text = "数据采集";
            this.地层界线点ToolStripMenuItem.Click += new System.EventHandler(this.地层界线点ToolStripMenuItem_Click);
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // 打印输出ToolStripMenuItem
            // 
            this.打印输出ToolStripMenuItem.Name = "打印输出ToolStripMenuItem";
            this.打印输出ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.打印输出ToolStripMenuItem.Text = "打印输出";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 1050);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axMapControl1);
            this.Name = "MainForm";
            this.Text = "数据采集功能模块";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存工作空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重做ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地层界线点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助主题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;


    }
}