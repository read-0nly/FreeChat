using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeChat
{
    public partial class UserConfig : Form
    {
        public UserConfig()
        {
            InitializeComponent();
        }

        private void UserConfig_Load(object sender, EventArgs e)
        {

            sendPortTB.Text = Properties.Settings.Default.SendPort;
            receivePortTB.Text = Properties.Settings.Default.RecvPort;
            nameTB.Text = Properties.Settings.Default.Name;
            colorBtn.BackColor = Color.FromArgb(
                Int32.Parse(Properties.Settings.Default.Color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                Int32.Parse(Properties.Settings.Default.Color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                Int32.Parse(Properties.Settings.Default.Color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
            );
            secretTb.Text = Properties.Settings.Default.Secret;
            thWinForeBtn.BackColor = Properties.Settings.Default.ThemeFore;
            thWinBackBtn.BackColor = Properties.Settings.Default.ThemeBack;
            thTbForeBtn.BackColor = Properties.Settings.Default.ThemeTBFore;
            thTbBackBtn.BackColor = Properties.Settings.Default.ThemeTBBack;
            thTbBorderBtn.BackColor = Properties.Settings.Default.ThemeTBBorder;
            thBtnForeBtn.BackColor = Properties.Settings.Default.ThemeBtnFore;
            thBtnBackBtn.BackColor = Properties.Settings.Default.ThemeBtnBack;
            thBtnBorderBtn.BackColor = Properties.Settings.Default.ThemeBtnBorder;
            thBtnHoverBtn.BackColor = Properties.Settings.Default.ThemeBtnHover;


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SendPort = sendPortTB.Text ;
            Properties.Settings.Default.RecvPort = receivePortTB.Text;
            Properties.Settings.Default.Name = nameTB.Text;
            Properties.Settings.Default.Color =
              colorBtn.BackColor.R.ToString("X2") +
              colorBtn.BackColor.G.ToString("X2") +
              colorBtn.BackColor.B.ToString("X2");
            Properties.Settings.Default.Secret = secretTb.Text;
            Properties.Settings.Default.ThemeFore = thWinForeBtn.BackColor;
            Properties.Settings.Default.ThemeBack = thWinBackBtn.BackColor;
            Properties.Settings.Default.ThemeTBFore = thTbForeBtn.BackColor;
            Properties.Settings.Default.ThemeTBBack = thTbBackBtn.BackColor;
            Properties.Settings.Default.ThemeTBBorder=thTbBorderBtn.BackColor;
            Properties.Settings.Default.ThemeBtnFore = thBtnForeBtn.BackColor;
            Properties.Settings.Default.ThemeBtnBack = thBtnBackBtn.BackColor;
            Properties.Settings.Default.ThemeBtnBorder = thBtnBorderBtn.BackColor;
            Properties.Settings.Default.ThemeBtnHover = thBtnHoverBtn.BackColor;
            this.Close();
        }

        private void setColor_Click(object sender, EventArgs e)
        {
            colorPick.ShowDialog();
            ((Button)sender).BackColor = colorPick.Color;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void secretGenBtn_Click(object sender, EventArgs e)
        {
            secretTb.Text = MulticonMgr.generateKey();
        }

    }
}
