using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DexSploit_V2
{
    public partial class DexSploit_V2_Logged_In : Form
    {
        EasyExploits.Module module = new EasyExploits.Module();
        public DexSploit_V2_Logged_In()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            module.ExecuteScript(fastColoredTextBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream s = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(s);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scripts.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(Scripts, "./Scripts", "*.txt");
            Functions.PopulateListBox(Scripts, "./Scripts", "*.lua");
        }

        private void Scripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{Scripts.SelectedItem}");
        }
    }
}
