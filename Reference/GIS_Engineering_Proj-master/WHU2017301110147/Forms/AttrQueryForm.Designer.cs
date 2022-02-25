namespace WHU2017301110147.Forms
{
    partial class AttrQueryForm
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
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.listBoxField = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnmore = new System.Windows.Forms.Button();
            this.btnlike = new System.Windows.Forms.Button();
            this.btnis = new System.Windows.Forms.Button();
            this.btnnull = new System.Windows.Forms.Button();
            this.btnor = new System.Windows.Forms.Button();
            this.btnloe = new System.Windows.Forms.Button();
            this.btnmoe = new System.Windows.Forms.Button();
            this.btnunequal = new System.Windows.Forms.Button();
            this.btnpercent = new System.Windows.Forms.Button();
            this.btnunderline = new System.Windows.Forms.Button();
            this.btnempty = new System.Windows.Forms.Button();
            this.btnspace = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btnbetween = new System.Windows.Forms.Button();
            this.btnand = new System.Windows.Forms.Button();
            this.btncharacter = new System.Windows.Forms.Button();
            this.btnnot = new System.Windows.Forms.Button();
            this.btnless = new System.Windows.Forms.Button();
            this.btnequal = new System.Windows.Forms.Button();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnquery = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLayer
            // 
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(92, 27);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(295, 20);
            this.cboLayer.TabIndex = 0;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // listBoxValue
            // 
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.ItemHeight = 12;
            this.listBoxValue.Location = new System.Drawing.Point(220, 82);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(167, 100);
            this.listBoxValue.TabIndex = 1;
            this.listBoxValue.SelectedIndexChanged += new System.EventHandler(this.listBoxValue_SelectedIndexChanged);
            this.listBoxValue.DoubleClick += new System.EventHandler(this.listBoxValue_DoubleClick);
            // 
            // listBoxField
            // 
            this.listBoxField.FormattingEnabled = true;
            this.listBoxField.ItemHeight = 12;
            this.listBoxField.Location = new System.Drawing.Point(26, 82);
            this.listBoxField.Name = "listBoxField";
            this.listBoxField.Size = new System.Drawing.Size(167, 100);
            this.listBoxField.TabIndex = 2;
            this.listBoxField.SelectedIndexChanged += new System.EventHandler(this.listBoxField_SelectedIndexChanged);
            this.listBoxField.DoubleClick += new System.EventHandler(this.listBoxField_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnmore);
            this.groupBox1.Controls.Add(this.btnlike);
            this.groupBox1.Controls.Add(this.btnis);
            this.groupBox1.Controls.Add(this.btnnull);
            this.groupBox1.Controls.Add(this.btnor);
            this.groupBox1.Controls.Add(this.btnloe);
            this.groupBox1.Controls.Add(this.btnmoe);
            this.groupBox1.Controls.Add(this.btnunequal);
            this.groupBox1.Controls.Add(this.btnpercent);
            this.groupBox1.Controls.Add(this.btnunderline);
            this.groupBox1.Controls.Add(this.btnempty);
            this.groupBox1.Controls.Add(this.btnspace);
            this.groupBox1.Controls.Add(this.btnin);
            this.groupBox1.Controls.Add(this.btnbetween);
            this.groupBox1.Controls.Add(this.btnand);
            this.groupBox1.Controls.Add(this.btncharacter);
            this.groupBox1.Controls.Add(this.btnnot);
            this.groupBox1.Controls.Add(this.btnless);
            this.groupBox1.Controls.Add(this.btnequal);
            this.groupBox1.Location = new System.Drawing.Point(26, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表达式";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnmore
            // 
            this.btnmore.Location = new System.Drawing.Point(305, 21);
            this.btnmore.Name = "btnmore";
            this.btnmore.Size = new System.Drawing.Size(41, 23);
            this.btnmore.TabIndex = 0;
            this.btnmore.Text = ">";
            this.btnmore.UseVisualStyleBackColor = true;
            this.btnmore.Click += new System.EventHandler(this.btnmore_Click);
            // 
            // btnlike
            // 
            this.btnlike.Location = new System.Drawing.Point(238, 21);
            this.btnlike.Name = "btnlike";
            this.btnlike.Size = new System.Drawing.Size(41, 23);
            this.btnlike.TabIndex = 0;
            this.btnlike.Text = "like";
            this.btnlike.UseVisualStyleBackColor = true;
            this.btnlike.Click += new System.EventHandler(this.btnlike_Click);
            // 
            // btnis
            // 
            this.btnis.Location = new System.Drawing.Point(164, 20);
            this.btnis.Name = "btnis";
            this.btnis.Size = new System.Drawing.Size(41, 23);
            this.btnis.TabIndex = 0;
            this.btnis.Text = "is";
            this.btnis.UseVisualStyleBackColor = true;
            this.btnis.Click += new System.EventHandler(this.btnis_Click);
            // 
            // btnnull
            // 
            this.btnnull.Location = new System.Drawing.Point(238, 49);
            this.btnnull.Name = "btnnull";
            this.btnnull.Size = new System.Drawing.Size(41, 23);
            this.btnnull.TabIndex = 0;
            this.btnnull.Text = "null";
            this.btnnull.UseVisualStyleBackColor = true;
            this.btnnull.Click += new System.EventHandler(this.btnnull_Click);
            // 
            // btnor
            // 
            this.btnor.Location = new System.Drawing.Point(164, 50);
            this.btnor.Name = "btnor";
            this.btnor.Size = new System.Drawing.Size(41, 23);
            this.btnor.TabIndex = 0;
            this.btnor.Text = "or";
            this.btnor.UseVisualStyleBackColor = true;
            this.btnor.Click += new System.EventHandler(this.btnor_Click);
            // 
            // btnloe
            // 
            this.btnloe.Location = new System.Drawing.Point(89, 49);
            this.btnloe.Name = "btnloe";
            this.btnloe.Size = new System.Drawing.Size(41, 23);
            this.btnloe.TabIndex = 0;
            this.btnloe.Text = "<=";
            this.btnloe.UseVisualStyleBackColor = true;
            this.btnloe.Click += new System.EventHandler(this.btnloe_Click);
            // 
            // btnmoe
            // 
            this.btnmoe.Location = new System.Drawing.Point(15, 49);
            this.btnmoe.Name = "btnmoe";
            this.btnmoe.Size = new System.Drawing.Size(43, 23);
            this.btnmoe.TabIndex = 0;
            this.btnmoe.Text = ">=";
            this.btnmoe.UseVisualStyleBackColor = true;
            this.btnmoe.Click += new System.EventHandler(this.btnmoe_Click);
            // 
            // btnunequal
            // 
            this.btnunequal.Location = new System.Drawing.Point(89, 21);
            this.btnunequal.Name = "btnunequal";
            this.btnunequal.Size = new System.Drawing.Size(41, 23);
            this.btnunequal.TabIndex = 0;
            this.btnunequal.Text = "!=";
            this.btnunequal.UseVisualStyleBackColor = true;
            this.btnunequal.Click += new System.EventHandler(this.btnunequal_Click);
            // 
            // btnpercent
            // 
            this.btnpercent.Location = new System.Drawing.Point(305, 78);
            this.btnpercent.Name = "btnpercent";
            this.btnpercent.Size = new System.Drawing.Size(41, 23);
            this.btnpercent.TabIndex = 0;
            this.btnpercent.Text = "%";
            this.btnpercent.UseVisualStyleBackColor = true;
            this.btnpercent.Click += new System.EventHandler(this.btnpercent_Click);
            // 
            // btnunderline
            // 
            this.btnunderline.Location = new System.Drawing.Point(238, 78);
            this.btnunderline.Name = "btnunderline";
            this.btnunderline.Size = new System.Drawing.Size(41, 23);
            this.btnunderline.TabIndex = 0;
            this.btnunderline.Text = "_";
            this.btnunderline.UseVisualStyleBackColor = true;
            this.btnunderline.Click += new System.EventHandler(this.btnunderline_Click);
            // 
            // btnempty
            // 
            this.btnempty.Location = new System.Drawing.Point(271, 107);
            this.btnempty.Name = "btnempty";
            this.btnempty.Size = new System.Drawing.Size(75, 23);
            this.btnempty.TabIndex = 0;
            this.btnempty.Text = "清空";
            this.btnempty.UseVisualStyleBackColor = true;
            this.btnempty.Click += new System.EventHandler(this.btnempty_Click);
            // 
            // btnspace
            // 
            this.btnspace.Location = new System.Drawing.Point(172, 107);
            this.btnspace.Name = "btnspace";
            this.btnspace.Size = new System.Drawing.Size(80, 23);
            this.btnspace.TabIndex = 0;
            this.btnspace.Text = "空格";
            this.btnspace.UseVisualStyleBackColor = true;
            this.btnspace.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnin
            // 
            this.btnin.Location = new System.Drawing.Point(164, 78);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(41, 23);
            this.btnin.TabIndex = 0;
            this.btnin.Text = "in";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btnbetween
            // 
            this.btnbetween.Location = new System.Drawing.Point(81, 107);
            this.btnbetween.Name = "btnbetween";
            this.btnbetween.Size = new System.Drawing.Size(69, 23);
            this.btnbetween.TabIndex = 0;
            this.btnbetween.Text = "between";
            this.btnbetween.UseVisualStyleBackColor = true;
            this.btnbetween.Click += new System.EventHandler(this.btnbetween_Click);
            // 
            // btnand
            // 
            this.btnand.Location = new System.Drawing.Point(89, 78);
            this.btnand.Name = "btnand";
            this.btnand.Size = new System.Drawing.Size(41, 23);
            this.btnand.TabIndex = 0;
            this.btnand.Text = "and";
            this.btnand.UseVisualStyleBackColor = true;
            this.btnand.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncharacter
            // 
            this.btncharacter.Location = new System.Drawing.Point(15, 107);
            this.btncharacter.Name = "btncharacter";
            this.btncharacter.Size = new System.Drawing.Size(43, 23);
            this.btncharacter.TabIndex = 0;
            this.btncharacter.Text = "\' \'";
            this.btncharacter.UseVisualStyleBackColor = true;
            this.btncharacter.Click += new System.EventHandler(this.btncharacter_Click);
            // 
            // btnnot
            // 
            this.btnnot.Location = new System.Drawing.Point(15, 78);
            this.btnnot.Name = "btnnot";
            this.btnnot.Size = new System.Drawing.Size(43, 23);
            this.btnnot.TabIndex = 0;
            this.btnnot.Text = "not";
            this.btnnot.UseVisualStyleBackColor = true;
            this.btnnot.Click += new System.EventHandler(this.btnnot_Click);
            // 
            // btnless
            // 
            this.btnless.Location = new System.Drawing.Point(305, 50);
            this.btnless.Name = "btnless";
            this.btnless.Size = new System.Drawing.Size(41, 23);
            this.btnless.TabIndex = 0;
            this.btnless.Text = "<";
            this.btnless.UseVisualStyleBackColor = true;
            this.btnless.Click += new System.EventHandler(this.btnless_Click);
            // 
            // btnequal
            // 
            this.btnequal.Location = new System.Drawing.Point(15, 21);
            this.btnequal.Name = "btnequal";
            this.btnequal.Size = new System.Drawing.Size(43, 23);
            this.btnequal.TabIndex = 0;
            this.btnequal.Text = "=";
            this.btnequal.UseVisualStyleBackColor = true;
            this.btnequal.Click += new System.EventHandler(this.btnequal_Click);
            // 
            // textBoxSql
            // 
            this.textBoxSql.Location = new System.Drawing.Point(26, 376);
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.Size = new System.Drawing.Size(361, 21);
            this.textBoxSql.TabIndex = 4;
            this.textBoxSql.TextChanged += new System.EventHandler(this.textBoxSql_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "图层";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "字段";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "取值";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select * from where";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnquery
            // 
            this.btnquery.Location = new System.Drawing.Point(41, 415);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(80, 23);
            this.btnquery.TabIndex = 0;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(297, 415);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 0;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // AttrQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 464);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSql);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxField);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.cboLayer);
            this.Controls.Add(this.btnquery);
            this.Controls.Add(this.btncancel);
            this.Name = "AttrQueryForm";
            this.Text = "AttrQueryForm";
            this.Load += new System.EventHandler(this.AttrQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.ListBox listBoxField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.Button btnmore;
        private System.Windows.Forms.Button btnlike;
        private System.Windows.Forms.Button btnis;
        private System.Windows.Forms.Button btnnull;
        private System.Windows.Forms.Button btnor;
        private System.Windows.Forms.Button btnloe;
        private System.Windows.Forms.Button btnmoe;
        private System.Windows.Forms.Button btnunequal;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btnand;
        private System.Windows.Forms.Button btnnot;
        private System.Windows.Forms.Button btnless;
        private System.Windows.Forms.Button btnequal;
        private System.Windows.Forms.Button btnpercent;
        private System.Windows.Forms.Button btnunderline;
        private System.Windows.Forms.Button btnempty;
        private System.Windows.Forms.Button btnspace;
        private System.Windows.Forms.Button btnbetween;
        private System.Windows.Forms.Button btncharacter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.Button btncancel;
    }
}