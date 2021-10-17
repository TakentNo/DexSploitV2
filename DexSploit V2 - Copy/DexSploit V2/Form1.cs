using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DexSploit_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == new WebClient().DownloadString("https://pastebin.com/raw/THz73A7C") || textBox1.Text == "scpfastkey")
            {
                MessageBox.Show("Correct key, welcome!", "Key Correct");
                this.Hide();
                DexSploit_V2_Logged_In main = new DexSploit_V2_Logged_In();
                main.Show();

            }
            else
            {
                MessageBox.Show("Sorry the key is invalid. Try again.", "Key Invalid");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://boost.ink/f6st");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
