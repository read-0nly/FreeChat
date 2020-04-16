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

namespace FreeChat
{
    public partial class Form1 : Form
    {
        ConnectionManager cm;
        string msgHistory = "";
        bool listenSwitch = false;
        public Form1()
        {
            InitializeComponent();
        }

         //   textBox3.Text = "S:" + textBox2.Text + ":" +((int)(DateTime.Now.Ticks/100)).ToString("X8")+":"+ textBox1.Text;
   
        private void button1_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                cm = new ConnectionManager(int.Parse(receivePortTB.Text), int.Parse(sendPortTB.Text));
                selfEndpointTB.Text = cm.encodeEndpointAddress(cm.selfInPoint, cm.selfOutPoint);
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            cm.loadRemoteEndpointPair(cm.decodeEndpointAddress(remoteEndpointTB.Text));
            cm.tunnelPaths();
            listenSwitch = true;
            Thread thread = new Thread(new ThreadStart(listenLoop));
            thread.Start();  
        }
        private void listenLoop()
        {
            while (listenSwitch)
            {
                string msg = Encoding.ASCII.GetString(cm.receiveBytes(cm.inClient));
                lock (this)
                {
                    this.msgHistory = msg + "\r\n" +this.msgHistory;
                }
            }
        }

        private void chatSendBtn_Click(object sender, EventArgs e)
        {
            string msg = chatMsgTb.Text;
            cm.sendString(msg, cm.remoteInPoint, cm.outClient);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chatHistoryTb.Text = msgHistory;
        }

    }
}
