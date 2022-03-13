namespace MyGIS.Forms
{
    partial class Map
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
            this.取消 = new System.Windows.Forms.Button();
            this.确定提交 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapID = new System.Windows.Forms.TextBox();
            this.MapName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RightLatiY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RightLongX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LeftLatiY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftLongX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CoorSys = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AltitudeSys = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MappingE = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.MappingS = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MappingUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Remark = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(296, 604);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(134, 44);
            this.取消.TabIndex = 12;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 确定提交
            // 
            this.确定提交.Location = new System.Drawing.Point(80, 604);
            this.确定提交.Name = "确定提交";
            this.确定提交.Size = new System.Drawing.Size(134, 44);
            this.确定提交.TabIndex = 11;
            this.确定提交.Text = "确定提交";
            this.确定提交.UseVisualStyleBackColor = true;
            this.确定提交.Click += new System.EventHandler(this.确定提交_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MapID);
            this.groupBox1.Controls.Add(this.MapName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 67);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.基本信息";
            // 
            // MapID
            // 
            this.MapID.Location = new System.Drawing.Point(115, 27);
            this.MapID.Name = "MapID";
            this.MapID.Size = new System.Drawing.Size(100, 28);
            this.MapID.TabIndex = 10;
            // 
            // MapName
            // 
            this.MapName.Location = new System.Drawing.Point(331, 25);
            this.MapName.Name = "MapName";
            this.MapName.Size = new System.Drawing.Size(100, 28);
            this.MapName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "图幅名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "图幅编号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RightLatiY);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.RightLongX);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LeftLatiY);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.LeftLongX);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(22, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 109);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.图幅范围";
            // 
            // RightLatiY
            // 
            this.RightLatiY.Location = new System.Drawing.Point(333, 61);
            this.RightLatiY.Name = "RightLatiY";
            this.RightLatiY.Size = new System.Drawing.Size(100, 28);
            this.RightLatiY.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "右上Y坐标：";
            // 
            // RightLongX
            // 
            this.RightLongX.Location = new System.Drawing.Point(116, 61);
            this.RightLongX.Name = "RightLongX";
            this.RightLongX.Size = new System.Drawing.Size(100, 28);
            this.RightLongX.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "右上X坐标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 4;
            // 
            // LeftLatiY
            // 
            this.LeftLatiY.Location = new System.Drawing.Point(332, 25);
            this.LeftLatiY.Name = "LeftLatiY";
            this.LeftLatiY.Size = new System.Drawing.Size(100, 28);
            this.LeftLatiY.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "左下Y坐标：";
            // 
            // LeftLongX
            // 
            this.LeftLongX.Location = new System.Drawing.Point(116, 25);
            this.LeftLongX.Name = "LeftLongX";
            this.LeftLongX.Size = new System.Drawing.Size(100, 28);
            this.LeftLongX.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "左下X坐标：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "坐标系统：";
            // 
            // CoorSys
            // 
            this.CoorSys.Location = new System.Drawing.Point(116, 25);
            this.CoorSys.Name = "CoorSys";
            this.CoorSys.Size = new System.Drawing.Size(317, 28);
            this.CoorSys.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 18);
            this.label14.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "高程系统：";
            // 
            // AltitudeSys
            // 
            this.AltitudeSys.Location = new System.Drawing.Point(116, 62);
            this.AltitudeSys.Name = "AltitudeSys";
            this.AltitudeSys.Size = new System.Drawing.Size(317, 28);
            this.AltitudeSys.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AltitudeSys);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.CoorSys);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(22, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 114);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3.坐标与高程系统";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MappingE);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.MappingS);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.MappingUnit);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(23, 323);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(449, 134);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4.填图信息";
            // 
            // MappingE
            // 
            this.MappingE.Location = new System.Drawing.Point(116, 93);
            this.MappingE.Name = "MappingE";
            this.MappingE.Size = new System.Drawing.Size(317, 28);
            this.MappingE.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 18);
            this.label12.TabIndex = 12;
            this.label12.Text = "结束时间：";
            // 
            // MappingS
            // 
            this.MappingS.Location = new System.Drawing.Point(116, 59);
            this.MappingS.Name = "MappingS";
            this.MappingS.Size = new System.Drawing.Size(317, 28);
            this.MappingS.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "开始时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 4;
            // 
            // MappingUnit
            // 
            this.MappingUnit.Location = new System.Drawing.Point(116, 25);
            this.MappingUnit.Name = "MappingUnit";
            this.MappingUnit.Size = new System.Drawing.Size(317, 28);
            this.MappingUnit.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "填图单位：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Remark);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(22, 464);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(450, 134);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "5.备注";
            // 
            // Remark
            // 
            this.Remark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Remark.Location = new System.Drawing.Point(14, 27);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(422, 96);
            this.Remark.TabIndex = 5;
            this.Remark.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 18);
            this.label17.TabIndex = 4;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 660);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.确定提交);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Map";
            this.Text = "图幅数据信息采集表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Button 确定提交;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox MapName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RightLatiY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RightLongX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LeftLatiY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LeftLongX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox MapID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox CoorSys;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AltitudeSys;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker MappingE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker MappingS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MappingUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox Remark;
        private System.Windows.Forms.Label label17;
    }
}