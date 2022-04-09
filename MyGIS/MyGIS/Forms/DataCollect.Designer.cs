namespace MyGIS.Forms
{
    partial class DataCollect
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
            this.删除所选 = new System.Windows.Forms.Button();
            this.编辑 = new System.Windows.Forms.Button();
            this.生成图层文件 = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.mapDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.foldpointDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.faultpointDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.geoboundarypointDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.routeDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foldpointDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faultpointDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.geoboundarypointDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // 删除所选
            // 
            this.删除所选.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.删除所选.Location = new System.Drawing.Point(106, 604);
            this.删除所选.Name = "删除所选";
            this.删除所选.Size = new System.Drawing.Size(150, 35);
            this.删除所选.TabIndex = 1;
            this.删除所选.Text = "删除所选";
            this.删除所选.UseVisualStyleBackColor = true;
            this.删除所选.Click += new System.EventHandler(this.删除所选_Click);
            // 
            // 编辑
            // 
            this.编辑.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.编辑.Location = new System.Drawing.Point(353, 604);
            this.编辑.Name = "编辑";
            this.编辑.Size = new System.Drawing.Size(198, 35);
            this.编辑.TabIndex = 2;
            this.编辑.Text = "开始编辑";
            this.编辑.UseVisualStyleBackColor = true;
            this.编辑.Click += new System.EventHandler(this.编辑_Click);
            // 
            // 生成图层文件
            // 
            this.生成图层文件.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.生成图层文件.Location = new System.Drawing.Point(634, 604);
            this.生成图层文件.Name = "生成图层文件";
            this.生成图层文件.Size = new System.Drawing.Size(150, 35);
            this.生成图层文件.TabIndex = 3;
            this.生成图层文件.Text = "生成图层文件";
            this.生成图层文件.UseVisualStyleBackColor = true;
            this.生成图层文件.Click += new System.EventHandler(this.生成图层文件_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.mapDataGridView);
            this.tabPage9.Location = new System.Drawing.Point(4, 28);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(902, 554);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "图幅信息数据";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // mapDataGridView
            // 
            this.mapDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mapDataGridView.Location = new System.Drawing.Point(8, 8);
            this.mapDataGridView.Name = "mapDataGridView";
            this.mapDataGridView.ReadOnly = true;
            this.mapDataGridView.RowTemplate.Height = 30;
            this.mapDataGridView.Size = new System.Drawing.Size(902, 516);
            this.mapDataGridView.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.foldpointDataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(902, 554);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "褶皱采集点";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // foldpointDataGridView
            // 
            this.foldpointDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldpointDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foldpointDataGridView.Location = new System.Drawing.Point(8, 8);
            this.foldpointDataGridView.Name = "foldpointDataGridView";
            this.foldpointDataGridView.ReadOnly = true;
            this.foldpointDataGridView.RowTemplate.Height = 30;
            this.foldpointDataGridView.Size = new System.Drawing.Size(902, 516);
            this.foldpointDataGridView.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.faultpointDataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(902, 554);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "断层采集点";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // faultpointDataGridView
            // 
            this.faultpointDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.faultpointDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faultpointDataGridView.Location = new System.Drawing.Point(8, 8);
            this.faultpointDataGridView.Name = "faultpointDataGridView";
            this.faultpointDataGridView.ReadOnly = true;
            this.faultpointDataGridView.RowTemplate.Height = 30;
            this.faultpointDataGridView.Size = new System.Drawing.Size(902, 516);
            this.faultpointDataGridView.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.geoboundarypointDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(902, 554);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "地层界限点";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // geoboundarypointDataGridView
            // 
            this.geoboundarypointDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geoboundarypointDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.geoboundarypointDataGridView.Location = new System.Drawing.Point(8, 8);
            this.geoboundarypointDataGridView.Name = "geoboundarypointDataGridView";
            this.geoboundarypointDataGridView.ReadOnly = true;
            this.geoboundarypointDataGridView.RowTemplate.Height = 30;
            this.geoboundarypointDataGridView.Size = new System.Drawing.Size(902, 516);
            this.geoboundarypointDataGridView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.routeDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(902, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "地质路线";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // routeDataGridView
            // 
            this.routeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.routeDataGridView.Name = "routeDataGridView";
            this.routeDataGridView.ReadOnly = true;
            this.routeDataGridView.RowTemplate.Height = 30;
            this.routeDataGridView.Size = new System.Drawing.Size(902, 516);
            this.routeDataGridView.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage9);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(910, 586);
            this.tabControl.TabIndex = 0;
            // 
            // DataCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 643);
            this.Controls.Add(this.生成图层文件);
            this.Controls.Add(this.编辑);
            this.Controls.Add(this.删除所选);
            this.Controls.Add(this.tabControl);
            this.Name = "DataCollect";
            this.Text = "数据管理";
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapDataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.foldpointDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.faultpointDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.geoboundarypointDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 删除所选;
        private System.Windows.Forms.Button 编辑;
        private System.Windows.Forms.Button 生成图层文件;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.DataGridView mapDataGridView;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView foldpointDataGridView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView faultpointDataGridView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView geoboundarypointDataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView routeDataGridView;
        private System.Windows.Forms.TabControl tabControl;
    }
}