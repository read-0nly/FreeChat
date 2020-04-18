
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

namespace FreeChat
{
    public partial class ChatWindow : Form
    {
        MulticonMgr cm;
        string msgHistory = "";
        bool listenSwitch = false;
        Thread thread;
        ArrayList PacketStack = new ArrayList();
        ArrayList ConvoStack = new ArrayList();
        public ChatWindow()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(listenLoop));
        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed!");
            }
            if (!(thread.ThreadState == ThreadState.Running))
            {
                thread.Start();
            };
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserConfig uc = new UserConfig();
            uc.Show();
        }

        private void initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cm != null)
            {
                cm.closeAll();
            }
            cm = new MulticonMgr(int.Parse(Properties.Settings.Default.RecvPort), int.Parse(Properties.Settings.Default.SendPort));
            selfEndpointTb.Text = cm.self.hexCode;
        }

        private void sendChatMessage()
        {
            string msg = "" +
                cm.self.hexCode+":"+
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

        private void listenLoop()
        {
            while (listenSwitch)
            {
                string msg = "";
                if (Properties.Settings.Default.Secret != "")
                {
                    byte[] key = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[0]);
                    byte[] iv = Convert.FromBase64String(Properties.Settings.Default.Secret.Split(':')[1]);
                    msg = MulticonMgr.DecryptStringFromBytes(cm.receiveBytes(cm.inClient), key, iv);
                }
                else
                {
                    msg = Encoding.ASCII.GetString(cm.receiveBytes(cm.inClient));
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

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            if (cm != null)
            {
                if (cm.getStatus()) { 
                    cm.inClient.Close();
                    cm.outClient.Close();
                }
            }
        }

        private void processReceivedSendcode(string p)
        {

            //split packed messages and handle
            string[] msgArray = p.Substring(2, p.Length - 2).Split(';');
            foreach (string msg in msgArray)
            {
                ChatMessage msgMsg = new ChatMessage(msg);
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
                    if (ConvoStack.Count > 10)
                    {
                        ConvoStack.RemoveAt(10);
                    }
                    ConvoStack.Insert(0, msgMsg);
                }

            }
        }

        private void processReceivedSendcode(ChatMessage p)
        {
            ChatReceipt receipt = new ChatReceipt(cm.self.hexCode, p.owner, p.tickCode);
            bool isDup = false;
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
                if (ConvoStack.Count > 10)
                {
                    ConvoStack.RemoveAt(10);
                }
                ConvoStack.Insert(0, p);
            }
        }
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
                                                    if (hex!= "" && cm.neighbours[hex] == null && hex!=cm.self.hexCode)
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
                        if (ConvoStack.Count > 10)
                        {
                            ConvoStack.RemoveAt(10);
                        }
                        ConvoStack.Insert(0, Sending);
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

        private void chatMsgTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage();
            }
        }

        private void queueTimer_tick(object sender, EventArgs e)
        {

            if (cm != null)
            {
                if (cm.getStatus())
                {
                    while (ConvoStack.Count > 11)
                    {
                        ConvoStack.RemoveAt(11);
                    }
                    processReceived();
                    processSend();
                    chatHistoryTb.Text = msgHistory;

                    string pageCode = "<body style='background-color:black;color:white;font-family: 'Lucida Console', Courier, monospace;font-size:14pt'>";
                    foreach (ChatMessage cMsg in ConvoStack)
                    {
                        pageCode += "<p style='color:#" + cMsg.color + "'>" +
                            "<b>" + cMsg.owner + "</b>: " +
                            cMsg.message.Substring(0, cMsg.message.Length - 1) +
                            "</p>";
                    }
                    if (webBrowser1.DocumentText != pageCode)
                    {
                        webBrowser1.DocumentText = pageCode;
                    }

                }
            }

        }
    
        
    }
}


/*
I'm pretty much ripping off the original form so pasting the code here for easy bone picking.

         //   textBox3.Text = "S:" + textBox2.Text + ":" +((int)(DateTime.Now.Ticks/100)).ToString("X8")+":"+ textBox1.Text;
   
        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void chatMsgTb_KeyDown(object sender, KeyEventArgs e)
        {
        }
*/