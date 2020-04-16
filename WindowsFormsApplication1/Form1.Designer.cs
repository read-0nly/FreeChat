namespace FreeChat
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.receivePortTB = new System.Windows.Forms.TextBox();
            this.sendPortTB = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.connectorStatus = new System.Windows.Forms.Label();
            this.receiverStatus = new System.Windows.Forms.Label();
            this.senderStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.remoteEndpointTB = new System.Windows.Forms.TextBox();
            this.selfEndpointTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chatHistoryTb = new System.Windows.Forms.TextBox();
            this.chatMsgTb = new System.Windows.Forms.TextBox();
            this.chatSendBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(296, 297);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(288, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Location = new System.Drawing.Point(20, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Identity Settings";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(142, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pick Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
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
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(142, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.receivePortTB);
            this.groupBox1.Controls.Add(this.sendPortTB);
            this.groupBox1.Location = new System.Drawing.Point(20, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 72);
            this.groupBox1.TabIndex = 0;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.disconnectBtn);
            this.tabPage2.Controls.Add(this.connectBtn);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(288, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(18, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 48);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption Settings";
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
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(50, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.connectorStatus);
            this.groupBox5.Controls.Add(this.receiverStatus);
            this.groupBox5.Controls.Add(this.senderStatus);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(21, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 75);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // connectorStatus
            // 
            this.connectorStatus.AutoSize = true;
            this.connectorStatus.Location = new System.Drawing.Point(109, 46);
            this.connectorStatus.Name = "connectorStatus";
            this.connectorStatus.Size = new System.Drawing.Size(63, 13);
            this.connectorStatus.TabIndex = 5;
            this.connectorStatus.Text = "Uninitialized";
            // 
            // receiverStatus
            // 
            this.receiverStatus.AutoSize = true;
            this.receiverStatus.Location = new System.Drawing.Point(109, 33);
            this.receiverStatus.Name = "receiverStatus";
            this.receiverStatus.Size = new System.Drawing.Size(63, 13);
            this.receiverStatus.TabIndex = 4;
            this.receiverStatus.Text = "Uninitialized";
            // 
            // senderStatus
            // 
            this.senderStatus.AutoSize = true;
            this.senderStatus.Location = new System.Drawing.Point(109, 20);
            this.senderStatus.Name = "senderStatus";
            this.senderStatus.Size = new System.Drawing.Size(63, 13);
            this.senderStatus.TabIndex = 3;
            this.senderStatus.Text = "Uninitialized";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Connector Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Receiver Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sender Status:";
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectBtn.Location = new System.Drawing.Point(191, 85);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.disconnectBtn.TabIndex = 2;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectBtn.Location = new System.Drawing.Point(21, 85);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.remoteEndpointTB);
            this.groupBox4.Controls.Add(this.selfEndpointTB);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(21, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 73);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Endpoints";
            // 
            // remoteEndpointTB
            // 
            this.remoteEndpointTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteEndpointTB.Location = new System.Drawing.Point(112, 45);
            this.remoteEndpointTB.Name = "remoteEndpointTB";
            this.remoteEndpointTB.Size = new System.Drawing.Size(127, 20);
            this.remoteEndpointTB.TabIndex = 3;
            // 
            // selfEndpointTB
            // 
            this.selfEndpointTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selfEndpointTB.Location = new System.Drawing.Point(112, 19);
            this.selfEndpointTB.Name = "selfEndpointTB";
            this.selfEndpointTB.Size = new System.Drawing.Size(127, 20);
            this.selfEndpointTB.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Your endpoint";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remote Endpoint";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chatHistoryTb);
            this.tabPage3.Controls.Add(this.chatMsgTb);
            this.tabPage3.Controls.Add(this.chatSendBtn);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(288, 268);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chat";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chatHistoryTb
            // 
            this.chatHistoryTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatHistoryTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatHistoryTb.Location = new System.Drawing.Point(8, 31);
            this.chatHistoryTb.Multiline = true;
            this.chatHistoryTb.Name = "chatHistoryTb";
            this.chatHistoryTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatHistoryTb.Size = new System.Drawing.Size(272, 229);
            this.chatHistoryTb.TabIndex = 2;
            // 
            // chatMsgTb
            // 
            this.chatMsgTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatMsgTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatMsgTb.Location = new System.Drawing.Point(8, 5);
            this.chatMsgTb.Name = "chatMsgTb";
            this.chatMsgTb.Size = new System.Drawing.Size(196, 20);
            this.chatMsgTb.TabIndex = 1;
            // 
            // chatSendBtn
            // 
            this.chatSendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chatSendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatSendBtn.Location = new System.Drawing.Point(210, 3);
            this.chatSendBtn.Name = "chatSendBtn";
            this.chatSendBtn.Size = new System.Drawing.Size(70, 23);
            this.chatSendBtn.TabIndex = 0;
            this.chatSendBtn.Text = "Send";
            this.chatSendBtn.UseVisualStyleBackColor = true;
            this.chatSendBtn.Click += new System.EventHandler(this.chatSendBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 297);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox receivePortTB;
        private System.Windows.Forms.TextBox sendPortTB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label connectorStatus;
        private System.Windows.Forms.Label receiverStatus;
        private System.Windows.Forms.Label senderStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox remoteEndpointTB;
        private System.Windows.Forms.TextBox selfEndpointTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox chatHistoryTb;
        private System.Windows.Forms.TextBox chatMsgTb;
        private System.Windows.Forms.Button chatSendBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;



    }
}

