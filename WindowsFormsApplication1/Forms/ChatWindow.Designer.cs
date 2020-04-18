namespace FreeChat
{
    partial class ChatWindow
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.initializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToPeerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatMsgTb = new System.Windows.Forms.TextBox();
            this.selfEndpointTb = new System.Windows.Forms.TextBox();
            this.keepAliveTimer = new System.Windows.Forms.Timer(this.components);
            this.queueTimer = new System.Windows.Forms.Timer(this.components);
            this.chatHistoryTb = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 27);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(494, 336);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(512, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(87, 212);
            this.listBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem,
            this.connectToPeerToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(611, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // initializeToolStripMenuItem
            // 
            this.initializeToolStripMenuItem.Name = "initializeToolStripMenuItem";
            this.initializeToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.initializeToolStripMenuItem.Text = "Initialize";
            this.initializeToolStripMenuItem.Click += new System.EventHandler(this.initializeToolStripMenuItem_Click);
            // 
            // connectToPeerToolStripMenuItem
            // 
            this.connectToPeerToolStripMenuItem.Name = "connectToPeerToolStripMenuItem";
            this.connectToPeerToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.connectToPeerToolStripMenuItem.Text = "Connect to Peer";
            this.connectToPeerToolStripMenuItem.Click += new System.EventHandler(this.connectToPeerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // chatMsgTb
            // 
            this.chatMsgTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatMsgTb.Location = new System.Drawing.Point(12, 369);
            this.chatMsgTb.Name = "chatMsgTb";
            this.chatMsgTb.Size = new System.Drawing.Size(494, 20);
            this.chatMsgTb.TabIndex = 3;
            this.chatMsgTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMsgTb_KeyDown);
            // 
            // selfEndpointTb
            // 
            this.selfEndpointTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selfEndpointTb.Location = new System.Drawing.Point(425, 1);
            this.selfEndpointTb.Name = "selfEndpointTb";
            this.selfEndpointTb.Size = new System.Drawing.Size(174, 20);
            this.selfEndpointTb.TabIndex = 4;
            // 
            // keepAliveTimer
            // 
            this.keepAliveTimer.Enabled = true;
            this.keepAliveTimer.Interval = 1000;
            this.keepAliveTimer.Tick += new System.EventHandler(this.keepAliveTimer_Tick);
            // 
            // queueTimer
            // 
            this.queueTimer.Enabled = true;
            this.queueTimer.Tick += new System.EventHandler(this.queueTimer_tick);
            // 
            // chatHistoryTb
            // 
            this.chatHistoryTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chatHistoryTb.Location = new System.Drawing.Point(512, 244);
            this.chatHistoryTb.Multiline = true;
            this.chatHistoryTb.Name = "chatHistoryTb";
            this.chatHistoryTb.Size = new System.Drawing.Size(87, 145);
            this.chatHistoryTb.TabIndex = 5;
            this.chatHistoryTb.WordWrap = false;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 398);
            this.Controls.Add(this.chatHistoryTb);
            this.Controls.Add(this.selfEndpointTb);
            this.Controls.Add(this.chatMsgTb);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem initializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToPeerToolStripMenuItem;
        private System.Windows.Forms.TextBox chatMsgTb;
        private System.Windows.Forms.TextBox selfEndpointTb;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Timer keepAliveTimer;
        private System.Windows.Forms.Timer queueTimer;
        private System.Windows.Forms.TextBox chatHistoryTb;
    }
}