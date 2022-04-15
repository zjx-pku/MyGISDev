namespace MyGIS.Forms
{
    partial class GeoBoundaryPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoBoundaryPoint));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RouteID = new System.Windows.Forms.ComboBox();
            this.MapID = new System.Windows.Forms.ComboBox();
            this.PointID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MapName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RightBody = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LeftBody = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Strike = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DipAngle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Dip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ContactRela = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.获取经纬度和高程 = new System.Windows.Forms.Button();
            this.Altitude = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Longitude = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Remark = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.确定提交 = new System.Windows.Forms.Button();
            this.取消 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RouteID);
            this.groupBox1.Controls.Add(this.MapID);
            this.groupBox1.Controls.Add(this.PointID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MapName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.采集点信息";
            // 
            // RouteID
            // 
            this.RouteID.FormattingEnabled = true;
            this.RouteID.Location = new System.Drawing.Point(524, 25);
            this.RouteID.Name = "RouteID";
            this.RouteID.Size = new System.Drawing.Size(121, 26);
            this.RouteID.TabIndex = 9;
            // 
            // MapID
            // 
            this.MapID.FormattingEnabled = true;
            this.MapID.Location = new System.Drawing.Point(94, 25);
            this.MapID.Name = "MapID";
            this.MapID.Size = new System.Drawing.Size(121, 26);
            this.MapID.TabIndex = 8;
            this.MapID.TextChanged += new System.EventHandler(this.MapID_TextChanged);
            // 
            // PointID
            // 
            this.PointID.Location = new System.Drawing.Point(755, 25);
            this.PointID.Name = "PointID";
            this.PointID.Size = new System.Drawing.Size(100, 28);
            this.PointID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "地质点号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "路线号：";
            // 
            // MapName
            // 
            this.MapName.Location = new System.Drawing.Point(319, 25);
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
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "图幅编号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RightBody);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.LeftBody);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Strike);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DipAngle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Dip);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ContactRela);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.基本信息";
            // 
            // RightBody
            // 
            this.RightBody.Location = new System.Drawing.Point(333, 100);
            this.RightBody.Name = "RightBody";
            this.RightBody.Size = new System.Drawing.Size(100, 28);
            this.RightBody.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "右边地质体：";
            // 
            // LeftBody
            // 
            this.LeftBody.Location = new System.Drawing.Point(116, 100);
            this.LeftBody.Name = "LeftBody";
            this.LeftBody.Size = new System.Drawing.Size(100, 28);
            this.LeftBody.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "左边地质体：";
            // 
            // Strike
            // 
            this.Strike.Location = new System.Drawing.Point(333, 62);
            this.Strike.Name = "Strike";
            this.Strike.Size = new System.Drawing.Size(100, 28);
            this.Strike.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "界线走向：";
            // 
            // DipAngle
            // 
            this.DipAngle.Location = new System.Drawing.Point(115, 62);
            this.DipAngle.Name = "DipAngle";
            this.DipAngle.Size = new System.Drawing.Size(100, 28);
            this.DipAngle.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "界线倾角：";
            // 
            // Dip
            // 
            this.Dip.Location = new System.Drawing.Point(332, 25);
            this.Dip.Name = "Dip";
            this.Dip.Size = new System.Drawing.Size(100, 28);
            this.Dip.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "界线倾向：";
            // 
            // ContactRela
            // 
            this.ContactRela.Location = new System.Drawing.Point(116, 25);
            this.ContactRela.Name = "ContactRela";
            this.ContactRela.Size = new System.Drawing.Size(100, 28);
            this.ContactRela.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "接触关系：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.获取经纬度和高程);
            this.groupBox3.Controls.Add(this.Altitude);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.Latitude);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.Longitude);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(12, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 174);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3.经纬度与高程";
            // 
            // 获取经纬度和高程
            // 
            this.获取经纬度和高程.Location = new System.Drawing.Point(233, 27);
            this.获取经纬度和高程.Name = "获取经纬度和高程";
            this.获取经纬度和高程.Size = new System.Drawing.Size(215, 102);
            this.获取经纬度和高程.TabIndex = 16;
            this.获取经纬度和高程.Text = "获取经纬度和高程";
            this.获取经纬度和高程.UseVisualStyleBackColor = true;
            this.获取经纬度和高程.Click += new System.EventHandler(this.获取经纬度和高程_Click);
            // 
            // Altitude
            // 
            this.Altitude.Location = new System.Drawing.Point(113, 101);
            this.Altitude.Name = "Altitude";
            this.Altitude.Size = new System.Drawing.Size(100, 28);
            this.Altitude.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "高程：";
            // 
            // Latitude
            // 
            this.Latitude.Location = new System.Drawing.Point(113, 62);
            this.Latitude.Name = "Latitude";
            this.Latitude.Size = new System.Drawing.Size(100, 28);
            this.Latitude.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "纬度：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 18);
            this.label14.TabIndex = 4;
            // 
            // Longitude
            // 
            this.Longitude.Location = new System.Drawing.Point(112, 25);
            this.Longitude.Name = "Longitude";
            this.Longitude.Size = new System.Drawing.Size(100, 28);
            this.Longitude.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "经度：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Remark);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(526, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 341);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4.备注信息";
            // 
            // Remark
            // 
            this.Remark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Remark.Location = new System.Drawing.Point(11, 28);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(356, 268);
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
            // 确定提交
            // 
            this.确定提交.Location = new System.Drawing.Point(237, 473);
            this.确定提交.Name = "确定提交";
            this.确定提交.Size = new System.Drawing.Size(134, 44);
            this.确定提交.TabIndex = 5;
            this.确定提交.Text = "确定提交";
            this.确定提交.UseVisualStyleBackColor = true;
            this.确定提交.Click += new System.EventHandler(this.确定提交_Click);
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(550, 473);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(134, 44);
            this.取消.TabIndex = 6;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // GeoBoundaryPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 522);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.确定提交);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeoBoundaryPoint";
            this.Text = "地质界线采集点信息表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PointID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MapName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RightBody;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox LeftBody;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Strike;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DipAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Dip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ContactRela;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Altitude;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Latitude;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Longitude;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox Remark;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button 确定提交;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.ComboBox RouteID;
        private System.Windows.Forms.ComboBox MapID;
        private System.Windows.Forms.Button 获取经纬度和高程;
    }
}