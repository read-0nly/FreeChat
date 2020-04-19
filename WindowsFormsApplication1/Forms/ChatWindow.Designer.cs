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
            this.recvQueueTimer = new System.Windows.Forms.Timer(this.components);
            this.sendQueueTimer = new System.Windows.Forms.Timer(this.components);
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
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(448, 333);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(466, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(130, 329);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem,
            this.connectToPeerToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
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
            this.chatMsgTb.Location = new System.Drawing.Point(0, 366);
            this.chatMsgTb.Name = "chatMsgTb";
            this.chatMsgTb.Size = new System.Drawing.Size(596, 20);
            this.chatMsgTb.TabIndex = 3;
            this.chatMsgTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMsgTb_KeyDown);
            // 
            // selfEndpointTb
            // 
            this.selfEndpointTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selfEndpointTb.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.selfEndpointTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selfEndpointTb.Location = new System.Drawing.Point(422, 1);
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
            // recvQueueTimer
            // 
            this.recvQueueTimer.Enabled = true;
            this.recvQueueTimer.Interval = 166;
            this.recvQueueTimer.Tick += new System.EventHandler(this.recvQueueTimer_Tick);
            // 
            // sendQueueTimer
            // 
            this.sendQueueTimer.Enabled = true;
            this.sendQueueTimer.Interval = 333;
            this.sendQueueTimer.Tick += new System.EventHandler(this.sendQueueTimer_Tick);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 398);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.chatMsgTb);
            this.Controls.Add(this.selfEndpointTb);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
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
        private System.Windows.Forms.Timer recvQueueTimer;
        private System.Windows.Forms.Timer sendQueueTimer;
    }
}