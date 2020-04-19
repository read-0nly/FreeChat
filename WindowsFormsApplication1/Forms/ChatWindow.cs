
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using Microsoft.VisualBasic;

/*
 * For easy naviagtion/searching
 * 
 * Function Blocks:
 *      CONSTRUCTOR
 *      SEND MESSAGE
 *      LISTENING LOOP
 *      PROCESS
 *      EVENT
 */

namespace FreeChat
{
    public partial class ChatWindow : Form
    {
// MAIN VARS BLOCK
        MulticonMgr cm;
        string msgHistory = "";
        bool listenSwitch = false;
        Thread thread;
        ArrayList PacketStack = new ArrayList();
        ArrayList ConvoStack = new ArrayList();
        int offlineTimer = 10; //seconds
        int timeoutTimer = 5; //minutes


// END MAIN VARS

// CONSTRUCTOR FUNCTION
        public ChatWindow()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(listenLoop));
            setColors();
        }
// con
        public void setColors()
        {
            this.BackColor = Properties.Settings.Default.ThemeBack;
            this.ForeColor = Properties.Settings.Default.ThemeFore;

            menuStrip1.BackColor = Properties.Settings.Default.ThemeBack; 
            menuStrip1.ForeColor = Properties.Settings.Default.ThemeFore;

            chatMsgTb.BackColor = Properties.Settings.Default.ThemeTBBack;
            chatMsgTb.ForeColor = Properties.Settings.Default.ThemeTBFore;

            selfEndpointTb.BackColor = Properties.Settings.Default.ThemeTBBack;
            selfEndpointTb.ForeColor = Properties.Settings.Default.ThemeTBFore;
        }
// CONSTUCTOR

// SEND MESSAGE FUNCTION     
        private void sendChatMessage()
        {
            /*
             *
             * 
             * 
             * MAKE THIS INTO A SPEPARATE FUNCTION SO YOU CAN DO TARGETED MESSAGES
             * 
             * 
             */
            string msg = "" +
                cm.self.hexCode + ":" +
                WebUtility.UrlEncode(Properties.Settings.Default.Name) + ":" +
                ((int)(DateTime.Now.Ticks / 100)).ToString("X8") + ":" +
                Properties.Settings.Default.Color + ":" +
                WebUtility.UrlEncode(chatMsgTb.Text + ";");
            foreach (ChatEndpoint n in cm.neighbours.Values)
            {
                n.MsgStack.Add(new ChatMessage(msg));
            }
            chatMsgTb.Text = "";
        }
        private void sendChatMessage(ChatEndpoint target)
        {
            string whisper = Microsoft.VisualBasic.Interaction.InputBox("Please enter your message", "Whisper");
            if (whisper != null && whisper != "")
            {
                string msg = "" +
                    cm.self.hexCode + ":" +
                    WebUtility.UrlEncode(Properties.Settings.Default.Name) + ":" +
                    ((int)(DateTime.Now.Ticks / 100)).ToString("X8") + ":" +
                    Properties.Settings.Default.Color + ":" +
                    WebUtility.UrlEncode(whisper) + ":Whisper;";
                target.MsgStack.Add(new ChatMessage(msg));
            }
        }
// END SEND MESSAGE



// LISTENING LOOP FUNCTION
        private void listenLoop()
        {
            while (listenSwitch)
            {
                string msg = "";
                if (Properties.Settings.Default.Secret != "")
                {
                    byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                    byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                    Packet p = cm.receiveBytes(cm.inClient);
                    string ep = ChatEndpoint.encodeEndpointAddress((new IPEndPoint(p.sender.Address, 0)),p.sender);
                    ep = ep.Substring(0, 8) + "...." + ep.Substring(12, 4);
                    foreach (string n in cm.neighbours.Keys)
                    {
                        if (System.Text.RegularExpressions.Regex.Match(n, ep).Success)
                        {
                            cm.neighbours[n].lastSeen = DateTime.Now;
                        }
                    }
                    msg = MulticonMgr.DecryptStringFromBytes(p.bytes, key, iv);

                }
                else{
                    Packet p = cm.receiveBytes(cm.inClient);
                    msg = Encoding.ASCII.GetString(p.bytes);
                }

                this.msgHistory = msg + "\r\n" + this.msgHistory;
                switch (msg.Substring(0, 2))
                {
                    case "S:":
                        {
                            lock (this)
                            {
                                foreach (string m in msg.Substring(2, msg.Length - 2).Split(';')){
                                    if (m.Length > 0)
                                    {
                                        PacketStack.Add(new ChatMessage(m));
                                    }
                                }
                                break;
                            }
                        }
                    case "R:":
                        {
                            lock (this)
                            {

                                cm.neighbours[msg.Split(':')[1]].ReceivedStack.Add(new ChatReceipt(msg.Substring(2, msg.Length - 2)));
                                break;
                            }
                        }
                    case "!:":
                        {
                            lock (this)
                            {
                                PacketStack.Insert(0, msg);
                                break;
                            }
                        }

                }

            }
        }
// END LISTENING LOOP



// PROCESS FUNCTIONS
        private void processReceivedSendcode(string p)
        {

            //split packed messages and handle
            string[] msgArray = p.Substring(2, p.Length - 2).Split(';');
            foreach (string msg in msgArray)
            {
                ChatMessage msgMsg = new ChatMessage(msg);
                cm.neighbours[msgMsg.ownerHex].nickname = msgMsg.owner;
                ChatReceipt receipt = new ChatReceipt(cm.self.hexCode, msgMsg.owner, msgMsg.tickCode);
                bool isDup = false;
                // adviseReceived

                if (Properties.Settings.Default.Secret != "")
                {
                    string message = ("R:" + receipt);
                    byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                    byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                    byte[] msgB = MulticonMgr.EncryptStringToBytes(message, key, iv);
                    MulticonMgr.sendBytes(msgB, cm.neighbours[msgMsg.ownerHex].InPoint, cm.outClient);
                }
                else
                {
                    MulticonMgr.sendString(
                        ("R:" + receipt),
                        cm.neighbours[msgMsg.ownerHex].InPoint, cm.outClient);
                }
                //identify duplicates and add and rotate.
                foreach (ChatMessage histMsg in ConvoStack)
                {
                    if (histMsg.tickCode == msgMsg.tickCode)
                    {
                        if (histMsg.owner == msgMsg.owner)
                        {
                            isDup = true;
                        }
                    }
                }
                if (!isDup)
                {
                    if (ConvoStack.Count > (Properties.Settings.Default.ChatHistory))
                    {
                        ConvoStack.RemoveAt(0);
                    }
                    ConvoStack.Add(msgMsg);
                }

            }
        }
// Proc
        private void processReceivedSendcode(ChatMessage p)
        {
            ChatReceipt receipt = new ChatReceipt(cm.self.hexCode, p.owner, p.tickCode);
            if (!(cm.neighbours[p.ownerHex].nickname == p.owner))
            {
                cm.neighbours[p.ownerHex].nickname = p.owner;
                object[] bucket = new object[listBox1.Items.Count];
                listBox1.Items.CopyTo(bucket,0);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(bucket);
            }
            
            // adviseReceived

            if (Properties.Settings.Default.Secret != "")
            {
                string message = ("R:" + receipt);
                byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                byte[] msgB = MulticonMgr.EncryptStringToBytes(message, key, iv);
                MulticonMgr.sendBytes(msgB, cm.neighbours[p.ownerHex].InPoint, cm.outClient);
            }
            else
            {
                MulticonMgr.sendString(
                    ("R:" + receipt),
                    cm.neighbours[p.ownerHex].InPoint, cm.outClient);
            }
            //identify duplicates and add and rotate.
            bool isDup = false;
            foreach (ChatMessage histMsg in ConvoStack)
            {
                if (histMsg.tickCode == p.tickCode)
                {
                    if (histMsg.owner == p.owner)
                    {
                        isDup = true;
                    }
                }
            }
            if (!isDup)
            {
                if (ConvoStack.Count > (Properties.Settings.Default.ChatHistory))
                {
                    ConvoStack.RemoveAt(0);
                }
                ConvoStack.Add(p);
            }
        }
// Proc
        private void processReceived()
        {
            //handle Receive queue
            ArrayList packetRemove = new ArrayList();
            lock (this)
            {
                foreach (object packet in PacketStack)
                {
                    if(packet is String){
                        string p = ((string)packet);
                        switch (p.Substring(0, 2))
                        {
                            case "S:":
                                {
                                    processReceivedSendcode(p);
                                    break;
                                }
                            case "!:":
                                {
                                    switch (p.Split(':')[1])
                                    {
                                        case "PingPong":
                                            {
                                                break;
                                            }
                                        case "Net":
                                            {
                                                foreach (string hex in p.Split(':')[2].Split(';'))
                                                {
                                                    if (hex!= "" && !cm.neighbours.ContainsKey(hex) && hex!=cm.self.hexCode)
                                                    {
                                                        cm.connectToEndpoint(hex);
                                                    }
                                                }
                                                break;
                                            }

                                    }
                                    break;
                                }

                        }
                    }
                    else if(packet is ChatMessage){
                        processReceivedSendcode(((ChatMessage)packet));
                    }
                    packetRemove.Add(packet);
                }
            }

            foreach (object packet in packetRemove)
            {
                PacketStack.Remove(packet);
            }
        }
// Proc
        private void processSend()
        {

            //remove already-received messages, pack message, send;
            foreach (ChatEndpoint n in cm.neighbours.Values)
            {
                ArrayList RemoveBucket = new ArrayList();
                foreach (ChatMessage Sending in n.MsgStack)
                {
                    lock (this)
                    {
                        foreach (ChatReceipt Received in n.ReceivedStack)
                        {
                            if (Sending.owner == Received.Owner &&
                                Sending.tickCode == Received.Tick)
                            {
                                RemoveBucket.Add(Sending);
                            }
                        }
                    }
                }
                foreach (ChatMessage RemMsg in RemoveBucket)
                {
                    n.MsgStack.Remove(RemMsg);
                }
                if (n.MsgStack.Count > 0)
                {
                    string message = "S:";
                    foreach (ChatMessage Sending in n.MsgStack)
                    {
                        message += Sending.ToString();
                        //identify duplicates and add and rotate.
                        bool isDup = false;
                        foreach (ChatMessage histMsg in ConvoStack)
                        {
                            if (histMsg.tickCode == Sending.tickCode)
                            {
                                if (histMsg.owner == Sending.owner)
                                {
                                    isDup = true;
                                }
                            }
                        }
                        if (!isDup)
                        {
                            if (ConvoStack.Count > (Properties.Settings.Default.ChatHistory))
                            {
                                ConvoStack.RemoveAt(0);
                            }
                            ConvoStack.Add(Sending);
                        }
                    }
                    message = message.Substring(0, message.Length);
                    if (Properties.Settings.Default.Secret != "")
                    {
                        byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                        byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                        byte[] msgB = MulticonMgr.EncryptStringToBytes(message, key, iv);
                        MulticonMgr.sendBytes(msgB, n.InPoint, cm.outClient);
                    }
                    else
                    {
                        MulticonMgr.sendString(message, n.InPoint, cm.outClient);
                    }
                }
            }
        }
// Proc
        private void processConvo()
        {
            Console.WriteLine(msgHistory);
            msgHistory = "";

            string pageHead = "<body style='background-color:black; font-family: monospace; font-size:10pt'>";
            string pageCode = pageHead;
            ChatMessage pMsg = null;
            foreach (ChatMessage cMsg in ConvoStack)
            {
                if (pMsg == null)
                {
                    pageCode += "<div style='color:#" +cMsg.color + "; margin:2px; border: solid 1px #" + cMsg.color + "; width:100%; '>";
                }
                else if (pMsg.owner != cMsg.owner)
                {
                    pageCode += "</div>";
                    pageCode += "<div style='color:#" + cMsg.color + "; margin:2px; border: solid 1px #" + cMsg.color + "; width:100%; '>";
                }
                pageCode += "<b>" + cMsg.owner + "</b>: " +
                    (cMsg.whisper?"<i>":"") + 
                     cMsg.message.Substring(0, cMsg.message.Length - 1) +
                     (cMsg.whisper ? "</i>" : "") + "<br>";
                pMsg = cMsg;
            }
            if (pageCode != pageHead)
            {
                pageCode += "</div>";
            }
            if (webBrowser1.DocumentText != pageCode)
            {
                webBrowser1.DocumentText = pageCode;
            }

        }
// END PROCESS



// EVENT FUNCTIONS
        private void keepAliveTimer_Tick(object sender, EventArgs e)
        {

            {
                if (cm != null)
                {
                    if (cm.getStatus())
                    {
                        if (Properties.Settings.Default.Secret != "")
                        {
                            byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                            byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                            cm.tunnelPaths(key, iv);

                        }
                        else
                        {
                            cm.tunnelPaths();
                        }

                        ArrayList remNBucket = new ArrayList();
                        foreach (ChatEndpoint n in cm.neighbours.Values)
                        {
                            n.online = (!((DateTime.Now - n.lastSeen).Seconds > offlineTimer));

                            if ((DateTime.Now - n.lastSeen).Minutes > timeoutTimer)
                            {
                                remNBucket.Add(n.hexCode);
                            }
                        }
                        foreach (string n in remNBucket)
                        {
                            cm.neighbours.Remove(n);
                        }
                    }
                    else
                    {
                        if (Properties.Settings.Default.Secret != "")
                        {
                            byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                            byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                            cm.keepAlive(key, iv);

                        }
                        else
                        {
                            cm.keepAlive();
                        }
                    }
                }
            }
        }
// Event
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            if (cm != null)
            {
                if (cm.getStatus())
                {
                    cm.inClient.Close();
                    cm.outClient.Close();
                }
            }
        }
// Event
        private void chatMsgTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage();
            }
        }
// Event
        private void recvQueueTimer_Tick(object sender, EventArgs e)
        {

            if (cm != null)
            {
                if (cm.getStatus())
                {
                    while (ConvoStack.Count > (Properties.Settings.Default.ChatHistory))
                    {
                        ConvoStack.RemoveAt(0);
                    }
                    processReceived();

                }
            }

        }
// Event
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            webBrowser1.Document.Window.ScrollTo(0, 5000);
        }
// Event
        private void connectToPeerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string s = Interaction.InputBox("Please enter the endpoint code of the other user:", "Connect to Endpoint");
                cm.connectToEndpoint(s);
                if (Properties.Settings.Default.Secret != "")
                {
                    byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                    byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                    cm.tunnelPaths(key, iv);

                }
                else
                {
                    cm.tunnelPaths();
                }
                listenSwitch = true;
                listBox1.Items.Add(cm.neighbours[s]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed!");
            }
            if (thread.ThreadState == ThreadState.Stopped)
            {
                thread = new Thread(new ThreadStart(listenLoop));
            }
            if (!(thread.ThreadState == ThreadState.Running))
            {
                thread.Start();
            };
        }
// Event
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserConfig uc = new UserConfig();
            uc.Show();
        }
// Event
        private void initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cm != null)
            {
                cm.closeAll();
            }
            cm = new MulticonMgr(int.Parse(Properties.Settings.Default.RecvPort), int.Parse(Properties.Settings.Default.SendPort));
            selfEndpointTb.Text = cm.self.hexCode;
        }
// Event
        private void sendQueueTimer_Tick(object sender, EventArgs e)
        {
            if (cm != null)
            {
                if (cm.getStatus())
                {
                    while (ConvoStack.Count > (Properties.Settings.Default.ChatHistory))
                    {
                        ConvoStack.RemoveAt(0);
                    }
                    processSend();
                    processConvo();
                }
            }
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {

            webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            processConvo();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sendChatMessage((ChatEndpoint)listBox1.SelectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
// END EVENT
    }
}
