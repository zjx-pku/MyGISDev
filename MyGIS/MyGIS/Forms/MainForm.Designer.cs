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
            this.PrintOutput = new System.Windows.Forms.Button();
            this.SpatialAnalyze = new System.Windows.Forms.Button();
            this.EditData = new System.Windows.Forms.Button();
            this.CollectData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintOutput
            // 
            this.PrintOutput.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PrintOutput.Location = new System.Drawing.Point(756, 81);
            this.PrintOutput.Name = "PrintOutput";
            this.PrintOutput.Size = new System.Drawing.Size(171, 76);
            this.PrintOutput.TabIndex = 7;
            this.PrintOutput.Text = "打印输出";
            this.PrintOutput.UseVisualStyleBackColor = true;
            this.PrintOutput.Click += new System.EventHandler(this.PrintOutput_Click);
            // 
            // SpatialAnalyze
            // 
            this.SpatialAnalyze.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SpatialAnalyze.Location = new System.Drawing.Point(540, 81);
            this.SpatialAnalyze.Name = "SpatialAnalyze";
            this.SpatialAnalyze.Size = new System.Drawing.Size(171, 76);
            this.SpatialAnalyze.TabIndex = 6;
            this.SpatialAnalyze.Text = "空间分析";
            this.SpatialAnalyze.UseVisualStyleBackColor = true;
            this.SpatialAnalyze.Click += new System.EventHandler(this.SpatialAnalyze_Click);
            // 
            // EditData
            // 
            this.EditData.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EditData.Location = new System.Drawing.Point(318, 81);
            this.EditData.Name = "EditData";
            this.EditData.Size = new System.Drawing.Size(171, 76);
            this.EditData.TabIndex = 5;
            this.EditData.Text = "建库成图";
            this.EditData.UseVisualStyleBackColor = true;
            this.EditData.Click += new System.EventHandler(this.EditData_Click);
            // 
            // CollectData
            // 
            this.CollectData.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CollectData.Location = new System.Drawing.Point(89, 81);
            this.CollectData.Name = "CollectData";
            this.CollectData.Size = new System.Drawing.Size(171, 76);
            this.CollectData.TabIndex = 4;
            this.CollectData.Text = "数据采集";
            this.CollectData.UseVisualStyleBackColor = true;
            this.CollectData.Click += new System.EventHandler(this.CollectData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 238);
            this.Controls.Add(this.PrintOutput);
            this.Controls.Add(this.SpatialAnalyze);
            this.Controls.Add(this.EditData);
            this.Controls.Add(this.CollectData);
            this.Name = "MainForm";
            this.Text = "区域地质调查填图辅助系统";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintOutput;
        private System.Windows.Forms.Button SpatialAnalyze;
        private System.Windows.Forms.Button EditData;
        private System.Windows.Forms.Button CollectData;
    }
}