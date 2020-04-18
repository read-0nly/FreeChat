namespace FreeChat
{
    partial class UserConfig
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.receivePortTB = new System.Windows.Forms.TextBox();
            this.sendPortTB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.secretGenBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.secretTb = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.thTbBorderBtn = new System.Windows.Forms.Button();
            this.thBtnHoverBtn = new System.Windows.Forms.Button();
            this.thBtnBorderBtn = new System.Windows.Forms.Button();
            this.thBtnBackBtn = new System.Windows.Forms.Button();
            this.thBtnForeBtn = new System.Windows.Forms.Button();
            this.thTbBackBtn = new System.Windows.Forms.Button();
            this.thTbForeBtn = new System.Windows.Forms.Button();
            this.thWinBackBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.thWinForeBtn = new System.Windows.Forms.Button();
            this.colorPick = new System.Windows.Forms.ColorDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nameTB);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Identity Settings";
            // 
            // colorBtn
            // 
            this.colorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBtn.Location = new System.Drawing.Point(142, 45);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(100, 23);
            this.colorBtn.TabIndex = 4;
            this.colorBtn.Text = "Pick Color";
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name";
            // 
            // nameTB
            // 
            this.nameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTB.Location = new System.Drawing.Point(142, 19);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 20);
            this.nameTB.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.receivePortTB);
            this.groupBox1.Controls.Add(this.sendPortTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Receiving Port (1-65535)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sending Port (1-65535)";
            // 
            // receivePortTB
            // 
            this.receivePortTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.receivePortTB.Location = new System.Drawing.Point(142, 45);
            this.receivePortTB.Name = "receivePortTB";
            this.receivePortTB.Size = new System.Drawing.Size(100, 20);
            this.receivePortTB.TabIndex = 1;
            // 
            // sendPortTB
            // 
            this.sendPortTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sendPortTB.Location = new System.Drawing.Point(142, 19);
            this.sendPortTB.Name = "sendPortTB";
            this.sendPortTB.Size = new System.Drawing.Size(100, 20);
            this.sendPortTB.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.secretGenBtn);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.secretTb);
            this.groupBox3.Location = new System.Drawing.Point(12, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 73);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption Settings";
            // 
            // secretGenBtn
            // 
            this.secretGenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secretGenBtn.Location = new System.Drawing.Point(142, 44);
            this.secretGenBtn.Name = "secretGenBtn";
            this.secretGenBtn.Size = new System.Drawing.Size(97, 23);
            this.secretGenBtn.TabIndex = 3;
            this.secretGenBtn.Text = "Generate";
            this.secretGenBtn.UseVisualStyleBackColor = true;
            this.secretGenBtn.Click += new System.EventHandler(this.secretGenBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Secret";
            // 
            // secretTb
            // 
            this.secretTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secretTb.Location = new System.Drawing.Point(50, 19);
            this.secretTb.Name = "secretTb";
            this.secretTb.Size = new System.Drawing.Size(189, 20);
            this.secretTb.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(266, 216);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(102, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Location = new System.Drawing.Point(424, 216);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(102, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.thTbBorderBtn);
            this.groupBox4.Controls.Add(this.thBtnHoverBtn);
            this.groupBox4.Controls.Add(this.thBtnBorderBtn);
            this.groupBox4.Controls.Add(this.thBtnBackBtn);
            this.groupBox4.Controls.Add(this.thBtnForeBtn);
            this.groupBox4.Controls.Add(this.thTbBackBtn);
            this.groupBox4.Controls.Add(this.thTbForeBtn);
            this.groupBox4.Controls.Add(this.thWinBackBtn);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.thWinForeBtn);
            this.groupBox4.Location = new System.Drawing.Point(266, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 190);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Color Scheme";
            // 
            // thTbBorderBtn
            // 
            this.thTbBorderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thTbBorderBtn.Location = new System.Drawing.Point(133, 98);
            this.thTbBorderBtn.Name = "thTbBorderBtn";
            this.thTbBorderBtn.Size = new System.Drawing.Size(56, 23);
            this.thTbBorderBtn.TabIndex = 27;
            this.thTbBorderBtn.Text = "Border";
            this.thTbBorderBtn.UseVisualStyleBackColor = true;
            this.thTbBorderBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thBtnHoverBtn
            // 
            this.thBtnHoverBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thBtnHoverBtn.Location = new System.Drawing.Point(195, 155);
            this.thBtnHoverBtn.Name = "thBtnHoverBtn";
            this.thBtnHoverBtn.Size = new System.Drawing.Size(56, 23);
            this.thBtnHoverBtn.TabIndex = 26;
            this.thBtnHoverBtn.Text = "Hover";
            this.thBtnHoverBtn.UseVisualStyleBackColor = true;
            this.thBtnHoverBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thBtnBorderBtn
            // 
            this.thBtnBorderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thBtnBorderBtn.Location = new System.Drawing.Point(133, 155);
            this.thBtnBorderBtn.Name = "thBtnBorderBtn";
            this.thBtnBorderBtn.Size = new System.Drawing.Size(56, 23);
            this.thBtnBorderBtn.TabIndex = 25;
            this.thBtnBorderBtn.Text = "Border";
            this.thBtnBorderBtn.UseVisualStyleBackColor = true;
            this.thBtnBorderBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thBtnBackBtn
            // 
            this.thBtnBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thBtnBackBtn.Location = new System.Drawing.Point(71, 155);
            this.thBtnBackBtn.Name = "thBtnBackBtn";
            this.thBtnBackBtn.Size = new System.Drawing.Size(56, 23);
            this.thBtnBackBtn.TabIndex = 24;
            this.thBtnBackBtn.Text = "Back";
            this.thBtnBackBtn.UseVisualStyleBackColor = true;
            this.thBtnBackBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thBtnForeBtn
            // 
            this.thBtnForeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thBtnForeBtn.Location = new System.Drawing.Point(9, 155);
            this.thBtnForeBtn.Name = "thBtnForeBtn";
            this.thBtnForeBtn.Size = new System.Drawing.Size(56, 23);
            this.thBtnForeBtn.TabIndex = 23;
            this.thBtnForeBtn.Text = "Fore";
            this.thBtnForeBtn.UseVisualStyleBackColor = true;
            this.thBtnForeBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thTbBackBtn
            // 
            this.thTbBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thTbBackBtn.Location = new System.Drawing.Point(71, 98);
            this.thTbBackBtn.Name = "thTbBackBtn";
            this.thTbBackBtn.Size = new System.Drawing.Size(56, 23);
            this.thTbBackBtn.TabIndex = 22;
            this.thTbBackBtn.Text = "Back";
            this.thTbBackBtn.UseVisualStyleBackColor = true;
            this.thTbBackBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thTbForeBtn
            // 
            this.thTbForeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thTbForeBtn.Location = new System.Drawing.Point(9, 98);
            this.thTbForeBtn.Name = "thTbForeBtn";
            this.thTbForeBtn.Size = new System.Drawing.Size(56, 23);
            this.thTbForeBtn.TabIndex = 21;
            this.thTbForeBtn.Text = "Fore";
            this.thTbForeBtn.UseVisualStyleBackColor = true;
            this.thTbForeBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // thWinBackBtn
            // 
            this.thWinBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thWinBackBtn.Location = new System.Drawing.Point(71, 43);
            this.thWinBackBtn.Name = "thWinBackBtn";
            this.thWinBackBtn.Size = new System.Drawing.Size(56, 23);
            this.thWinBackBtn.TabIndex = 20;
            this.thWinBackBtn.Text = "Back";
            this.thWinBackBtn.UseVisualStyleBackColor = true;
            this.thWinBackBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Button";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Textbox";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Window";
            // 
            // thWinForeBtn
            // 
            this.thWinForeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thWinForeBtn.Location = new System.Drawing.Point(9, 43);
            this.thWinForeBtn.Name = "thWinForeBtn";
            this.thWinForeBtn.Size = new System.Drawing.Size(56, 23);
            this.thWinForeBtn.TabIndex = 0;
            this.thWinForeBtn.Text = "Fore";
            this.thWinForeBtn.UseVisualStyleBackColor = true;
            this.thWinForeBtn.Click += new System.EventHandler(this.setColor_Click);
            // 
            // UserConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 257);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserConfig";
            this.Text = "UserConfig";
            this.Load += new System.EventHandler(this.UserConfig_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox receivePortTB;
        private System.Windows.Forms.TextBox sendPortTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button secretGenBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox secretTb;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button thWinForeBtn;
        private System.Windows.Forms.Button thTbBackBtn;
        private System.Windows.Forms.Button thTbForeBtn;
        private System.Windows.Forms.Button thWinBackBtn;
        private System.Windows.Forms.Button thTbBorderBtn;
        private System.Windows.Forms.Button thBtnHoverBtn;
        private System.Windows.Forms.Button thBtnBorderBtn;
        private System.Windows.Forms.Button thBtnBackBtn;
        private System.Windows.Forms.Button thBtnForeBtn;
        private System.Windows.Forms.ColorDialog colorPick;
    }
}