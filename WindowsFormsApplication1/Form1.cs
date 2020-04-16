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

namespace FreeChat
{
    public partial class Form1 : Form
    {
        ConnectionManager cm;
        string msgHistory = "";
        bool listenSwitch = false;
        Thread thread;
        ArrayList PacketStack = new ArrayList();
        ArrayList ReceivedStack = new ArrayList();
        ArrayList MsgStack = new ArrayList();
        ArrayList ConvoStack = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(listenLoop));
        }

         //   textBox3.Text = "S:" + textBox2.Text + ":" +((int)(DateTime.Now.Ticks/100)).ToString("X8")+":"+ textBox1.Text;
   
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorBtn.BackColor = colorDialog1.Color;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if ((receivePortTB.Text == "") || (sendPortTB.Text == ""))
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("Set your ports!");
                }
                else if (receivePortTB.Text == sendPortTB.Text)
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("You need to pick two separate ports!");

                }
                else if (nameTB.Text == "")
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("Set your name!");

                }
                else if (colorBtn.BackColor == null)
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("How did you manage to break colors?");

                }
                else
                {
                    cm = new ConnectionManager(int.Parse(receivePortTB.Text), int.Parse(sendPortTB.Text));
                    selfEndpointTB.Text = cm.encodeEndpointAddress(cm.selfInPoint, cm.selfOutPoint);
                }
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cm.loadRemoteEndpointPair(cm.decodeEndpointAddress(remoteEndpointTB.Text));
                cm.tunnelPaths();
                listenSwitch = true;
            }
            catch (Exception ex){
                MessageBox.Show("Connection failed!");
            }
            if (!thread.IsAlive) { thread.Start(); };
            secretTb.Enabled = false;
        }
        private void listenLoop()
        {
            while (listenSwitch)
            {
                string msg = "";
                if(secretTb.Text !=""){
                    byte[] key = Convert.FromBase64String(secretTb.Text.Split(':')[0]);
                    byte[] iv = Convert.FromBase64String(secretTb.Text.Split(':')[1]);
                    msg = cm.DecryptStringFromBytes(cm.receiveBytes(cm.inClient), key, iv);
                }
                else{
                    msg=Encoding.ASCII.GetString(cm.receiveBytes(cm.inClient));
                }
                
                    this.msgHistory = msg + "\r\n" +this.msgHistory;
                    switch(msg.Substring(0,2))
                    {
                        case "S:":
                            {
                                lock (this)
                                {
                                    PacketStack.Add(msg);
                                    break;
                                }
                            }
                        case "R:":
                            {
                                lock (this)
                                {
                                    ReceivedStack.Add(msg);
                                    break;
                                }
                            }
                        case "!:":
                            {
                                lock (this)
                                {
                                    PacketStack.Insert(0,msg);
                                    break;
                                }
                            }

                    }
                
            }
        }

        private void chatSendBtn_Click(object sender, EventArgs e)
        {
            sendChatMessage();
        }
        private void sendChatMessage()
        {
            string colorcode = colorDialog1.Color.R.ToString("X2") + colorDialog1.Color.G.ToString("X2") + colorDialog1.Color.B.ToString("X2");
            string msg = "" +
                WebUtility.UrlEncode(nameTB.Text) + ":" +
                ((int)(DateTime.Now.Ticks / 100)).ToString("X8") + ":" +
                colorcode + ":" +
                WebUtility.UrlEncode(chatMsgTb.Text + ";");
            MsgStack.Add(msg);
            chatMsgTb.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cm != null)
            {
                if (cm.getStatus())
                {
                    while (ConvoStack.Count > 11)
                    {
                        ConvoStack.RemoveAt(11);
                    }
                    //handle Receive queue
                    ArrayList packetRemove = new ArrayList();
                    lock(this){
                        foreach (string packet in PacketStack)
                        {
                            switch (packet.Substring(0, 2))
                            {
                                case "S:":
                                    {
                                        //split packed messages and handle
                                        string[] msgArray = packet.Substring(2, packet.Length - 2).Split(';');
                                        foreach (string msg in msgArray)
                                        {
                                            ChatMessage msgMsg = new ChatMessage(msg);
                                            bool isDup = false;
                                            // adviseReceived

                                            if (secretTb.Text != "")
                                            {
                                                string message = ("R:" + msgMsg.owner + ":" + msgMsg.tickCode);
                                                byte[] key = Convert.FromBase64String(secretTb.Text.Split(':')[0]);
                                                byte[] iv = Convert.FromBase64String(secretTb.Text.Split(':')[1]);
                                                byte[] msgB = cm.EncryptStringToBytes(message, key, iv);
                                                cm.sendBytes(msgB, cm.remoteInPoint, cm.outClient);
                                            }
                                            else
                                            {
                                                cm.sendString(
                                                    ("R:" + msgMsg.owner + ":" + msgMsg.tickCode),
                                                    cm.remoteInPoint, cm.outClient);
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
                                        break;
                                    }
                                case "!:":
                                    {
                                        switch (packet.Split(':')[1])
                                        {
                                            case "PingPong":
                                                {
                                                    break;
                                                }

                                        }
                                        break;
                                    }

                            }
                            packetRemove.Add(packet);
                        }
                    }

                    foreach (string packet in packetRemove)
                    {
                        PacketStack.Remove(packet);
                    }


                    //remove already-received messages, pack message, send;
                    ArrayList RemoveBucket = new ArrayList();
                    foreach (string Sending in MsgStack)
                    {
                        lock (this)
                        {
                            foreach (string Received in ReceivedStack)
                            {
                                if (Sending.Split(':')[0] == Received.Split(':')[1] &&
                                    Sending.Split(':')[1] == Received.Split(':')[2])
                                {
                                    RemoveBucket.Add(Sending);
                                }
                            }
                        }
                    }
                    foreach (string RemMsg in RemoveBucket)
                    {
                        MsgStack.Remove(RemMsg);
                    }
                    if (MsgStack.Count > 0)
                    {
                        string message = "S:";
                        foreach (string Sending in MsgStack)
                        {
                            message += Sending;
                            ChatMessage cMsg = new ChatMessage(Sending);
                            if (ConvoStack.Count > 10)
                            {
                                ConvoStack.RemoveAt(10);
                            }
                            ConvoStack.Insert(0, cMsg);
                        }
                        message = message.Substring(0, message.Length);
                        if (secretTb.Text != "")
                        {
                            byte[] key = Convert.FromBase64String(secretTb.Text.Split(':')[0]);
                            byte[] iv = Convert.FromBase64String(secretTb.Text.Split(':')[1]);
                            byte[] msgB = cm.EncryptStringToBytes(message, key , iv );
                            cm.sendBytes(msgB, cm.remoteInPoint, cm.outClient);
                        }
                        else
                        {
                            cm.sendString(message, cm.remoteInPoint, cm.outClient);
                        }
                    }
                    chatHistoryTb.Text = msgHistory;
                    string pageCode = "<body style='background-color:black;color:white'>";
                    foreach (ChatMessage cMsg in ConvoStack)
                    {
                        pageCode += "<p style='color:#" + cMsg.color + "'>" +
                            "<b>" + WebUtility.UrlDecode(cMsg.owner) + "</b>: " +
                            "<i>" + WebUtility.UrlDecode(cMsg.message.Substring(0,cMsg.message.Length-1)) + "</i>" +
                            "</p>";
                    }
                    if (webBrowser1.DocumentText != pageCode) { 
                        webBrowser1.DocumentText = pageCode;
                    }

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cm != null)
            {
                if (cm.getStatus())
                {
                    if (secretTb.Text != "")
                    {
                        byte[] key = Convert.FromBase64String(secretTb.Text.Split(':')[0]);
                        byte[] iv = Convert.FromBase64String(secretTb.Text.Split(':')[1]);
                        cm.tunnelPaths(key, iv);

                    }
                    else
                    {
                        cm.tunnelPaths();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secretTb.Text = cm.generateKey();
        }

        private void chatMsgTb_Validating(object sender, CancelEventArgs e)
        {

        }

        private void chatMsgTb_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chatMsgTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage();
            }
        }

    }
}
