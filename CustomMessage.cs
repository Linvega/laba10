using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba9
{
    public partial class CustomMessage : Form
    {
        string messege;
        public CustomMessage(string msg)
        {
            messege = msg;
            Program.f1.Enabled = false;
            InitializeComponent();
            this.label2.Text = msg;
            colorize();
        }
        public void colorize()
        {
            this.BackColor = Color.FromName(Program.f1.color_1);
            panel1.BackColor = Color.FromName(Program.f1.color_1);
            pictureBox1.BackColor = Color.FromName(Program.f1.color_1);

            button1.ForeColor = Color.FromName(Program.f1.color_4);
            button1.BackColor = Color.FromName(Program.f1.color_1);

            label1.ForeColor = Color.FromName(Program.f1.color_4);
            label2.ForeColor = Color.FromName(Program.f1.color_4);
        }
        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width - 1;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height - 4;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Program.f1.Enabled = true;
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(Program.f1.color_3);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(Program.f1.color_1);
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Program.f1.Enabled = true;
            this.Close();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromName(Program.f1.color_1);
            button1.BackColor = Color.FromName(Program.f1.color_4);
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromName(Program.f1.color_4);
            button1.BackColor = Color.FromName(Program.f1.color_1);
        }
    }
}
