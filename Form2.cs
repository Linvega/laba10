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
    public partial class Form2 : Form
    {
        /*
         * моя личная форма
         * для настройки
         * окна приложения
         * находится в разработке
         * думаю к след работе
         * доделаю основной функционал
         * */
        public Form2()
        {
            InitializeComponent();
            colorize();
            img_update();
        }
        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width + 3;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height + 3;
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(Program.f1.color_2);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(Program.f1.color_1);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Program.f1.color_1 = "White";
            Program.f1.color_2 = "LightGray";
            Program.f1.color_3 = "Salmon";
            Program.f1.color_4 = "Black";
            Program.f1.colorize();
            Program.f1.img_close = "close_rev.png";
            Program.f1.img_skip = "skip_rev.png";
            Program.f1.img_config = "config_rev.png";
            Program.f1.img_update();
            colorize();
            img_update();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Program.f1.color_1 = "Black";
            Program.f1.color_2 = "DimGray";
            Program.f1.color_3 = "Red";
            Program.f1.color_4 = "White";
            Program.f1.colorize();
            Program.f1.img_close = "close.png";
            Program.f1.img_skip = "skip.png";
            Program.f1.img_config = "config.png";
            Program.f1.img_update();
            colorize();
            img_update();
        }
        public void img_update()
        {
            pictureBox1.Image = Image.FromFile(Program.f1.img_close);
            pictureBox2.Image = Image.FromFile(Program.f1.img_skip);
        }
        public void colorize()
        {
            this.BackColor = Color.FromName(Program.f1.color_1);
            panel1.BackColor = Color.FromName(Program.f1.color_1);
            panel2.BackColor = Color.FromName(Program.f1.color_4);
            panel3.BackColor = Color.FromName(Program.f1.color_4);
            panel4.BackColor = Color.FromName(Program.f1.color_4);
            panel5.BackColor = Color.FromName(Program.f1.color_4);
            flowLayoutPanel1.BackColor = Color.FromName(Program.f1.color_4);
            pictureBox1.BackColor = Color.FromName(Program.f1.color_1);
            pictureBox2.BackColor = Color.FromName(Program.f1.color_1);

            button1.ForeColor = Color.FromName(Program.f1.color_4);
            button1.BackColor = Color.FromName(Program.f1.color_1);
            button2.ForeColor = Color.FromName(Program.f1.color_4);
            button2.BackColor = Color.FromName(Program.f1.color_1);
            button3.ForeColor = Color.FromName(Program.f1.color_4);
            button3.BackColor = Color.FromName(Program.f1.color_1);

            label1.ForeColor = Color.FromName(Program.f1.color_4);
            label2.ForeColor = Color.FromName(Program.f1.color_4);
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

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromName(Program.f1.color_1);
            button2.BackColor = Color.FromName(Program.f1.color_4);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromName(Program.f1.color_4);
            button2.BackColor = Color.FromName(Program.f1.color_1);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            Program.f1.color_1 = "PaleTurquoise";
            Program.f1.color_2 = "DarkCyan";
            Program.f1.color_3 = "Salmon";
            Program.f1.color_4 = "Black";
            Program.f1.colorize();
            Program.f1.img_close = "close_rev.png";
            Program.f1.img_skip = "skip_rev.png";
            Program.f1.img_config = "config_rev.png";
            Program.f1.img_update();
            colorize();
            img_update();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromName(Program.f1.color_1);
            button3.BackColor = Color.FromName(Program.f1.color_4);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromName(Program.f1.color_4);
            button3.BackColor = Color.FromName(Program.f1.color_1);
        }
    }
}
