using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Volleyballene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            checkBox1.Parent = pictureBox1;
            checkBox1.BackColor = Color.Transparent;
            timer1.Start();
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int color1 = rand.Next(0, 255);
            int color2 = rand.Next(0, 255);
            int color3 = rand.Next(0, 255);
            int color4 = rand.Next(0, 255);
            label1.ForeColor = Color.FromArgb(color1, color2, color3, color4);
            label2.ForeColor = Color.FromArgb(color1, color2, color3, color4);
            checkBox1.ForeColor = Color.FromArgb(color1, color2, color3, color4);
            button2.ForeColor = Color.FromArgb(color1, color2, color3, color4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (MessageBox.Show("Are you sure?", "Volleyballene.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Program.Destrution.Start();
            }
        }
    }
}
