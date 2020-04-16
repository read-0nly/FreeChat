using System;
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

            }
        }
    }
}
