using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace laba9
{
    public partial class Form1 : Form
    {

        ClassTest obj_1; //инициализация объекта
        public string color_1 = "White", color_2 = "LightGray", color_3 = "Salmon", color_4 = "Black"; //цвета оболочки
        public Form1() //конструктор формы
        {
            Program.f1 = this;
            InitializeComponent();
            colorize();
            img_update();
        }

        public string img_close = "close_rev.png", img_skip = "skip_rev.png", img_config = "Config_rev.png";//изображения оболочки
        public void img_update() //загрузка иконок
        {
            pictureBox1.Image = Image.FromFile(img_close);
            pictureBox2.Image = Image.FromFile(img_skip);
            pictureBox3.Image = Image.FromFile(img_config);
        }
        public void colorize() //специальный метод перекашивания(вся оболочка в разработке)
        {
            this.BackColor = Color.FromName(color_1);

            panel1.BackColor = Color.FromName(color_1);
            panel2.BackColor = Color.FromName(color_4);
            panel3.BackColor = Color.FromName(color_4);
            panel4.BackColor = Color.FromName(color_4);
            panel5.BackColor = Color.FromName(color_4);
            panel6.BackColor = Color.FromName(color_4);
            panel7.BackColor = Color.FromName(color_4);

            flowLayoutPanel1.BackColor = Color.FromName(color_4);
            pictureBox1.BackColor = Color.FromName(color_1);
            pictureBox2.BackColor = Color.FromName(color_1);
            pictureBox3.BackColor = Color.FromName(color_1);
            label1.ForeColor = Color.FromName(color_4);
            richTextBox1.ForeColor = Color.FromName(color_4);
            richTextBox1.BackColor = Color.FromName(color_1);

            numericUpDown1.BackColor = Color.FromName(color_1);
            numericUpDown1.ForeColor = Color.FromName(color_4);
            numericUpDown2.BackColor = Color.FromName(color_1);
            numericUpDown2.ForeColor = Color.FromName(color_4);

            label2.ForeColor = Color.FromName(color_4);
            label3.ForeColor = Color.FromName(color_4);
            label4.ForeColor = Color.FromName(color_4);
            label5.ForeColor = Color.FromName(color_4);
            label6.ForeColor = Color.FromName(color_4);
            label7.ForeColor = Color.FromName(color_4);
            label8.ForeColor = Color.FromName(color_4);
            label9.ForeColor = Color.FromName(color_4);
            label10.ForeColor = Color.FromName(color_4);
            label11.ForeColor = Color.FromName(color_4);

            textBox1.BackColor = Color.FromName(color_1);
            textBox1.ForeColor = Color.FromName(color_4);
            textBox2.BackColor = Color.FromName(color_1);
            textBox2.ForeColor = Color.FromName(color_4);

            button1.ForeColor = Color.FromName(color_4);
            button1.BackColor = Color.FromName(color_1);
            button2.ForeColor = Color.FromName(color_4);
            button2.BackColor = Color.FromName(color_1);
            button3.ForeColor = Color.FromName(color_4);
            button3.BackColor = Color.FromName(color_1);
            button4.ForeColor = Color.FromName(color_4);
            button4.BackColor = Color.FromName(color_1);

            checkBox1.ForeColor = Color.FromName(color_4);
            checkBox1.BackColor = Color.FromName(color_1);
            checkBox2.ForeColor = Color.FromName(color_4);
            checkBox2.BackColor = Color.FromName(color_1);
        }
        

      /*дальше идёт код не по теме
      * это личная работа
      * над своей собственной оболочкой
      * программы
      * всё что помечено "Дизайн" напрямую
      * к работе не относится
      * */

        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e) 
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width+3;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height+3;
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
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(color_3);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName(color_1);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(color_2);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName(color_1);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width-1;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height-4;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }

        }
        int chek1, chek2,chek; //здесь начинается обработка нажатий клавиш
        private void button1_MouseClick(object sender, MouseEventArgs e) //обработка кнопки создать массив
        {
            nn = 0;

            button5.Text = "Не транспанированный"; //переключает значение другой кнопки
            button5.ForeColor = Color.FromName(color_1);
            button5.BackColor = Color.FromName(color_4);
            chek = 1;
            if (checkBox1.Checked == true) //проверяем чекбоксы
            {
                chek1 = 1;

                FontStyle style = FontStyle.Underline; //стили для создания ячеек
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 10, style);
            }
            else
            {
                chek1 = 0;
                //стили для создания ячеек
                FontStyle style = FontStyle.Regular; 
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 10, style);
            }
            if (checkBox2.Checked == true)
            {
                chek2 = 1;
            }
            else
            {
                chek2 = 0;
            }
            obj_1 = new ClassTest(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), chek1,chek2);//создание объекта
            richTextBox1.Text = obj_1.mass_get();//вывод массива в ричбокс
        }
        private void button1_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            button1.ForeColor = Color.FromName(color_1);
            button1.BackColor = Color.FromName(color_4);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)//обработка нажатия"Максимум из строчек"
        {
            if (chek == 1) //проверяем можно ли нажать
            {
                if (nn == 0) //выводим максимум обычного либо транспанированного массива(по выбору)
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = obj_1.mass_get_str_max();
                }
                else
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = obj_1.mass_get_str_max_trans();
                }
            }
            else
            {
                CustomMessage error = new CustomMessage("Сначала создайте массив.");
                error.Show();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)//дизайн кнопок
        {
            button1.ForeColor = Color.FromName(color_4);
            button1.BackColor = Color.FromName(color_1);
        }

        private void button3_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout; 
                button3.Font = new Font(button3.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button3.Font = new Font(button3.Font.FontFamily, 10, style);
            }
            button3.ForeColor = Color.FromName(color_1);
            button3.BackColor = Color.FromName(color_4);
        }

        private void button3_MouseLeave(object sender, EventArgs e)//дизайн кнопок
        {
            FontStyle style = FontStyle.Regular;
            button3.Font = new Font(button3.Font.FontFamily, 10, style);
            button3.ForeColor = Color.FromName(color_4);
            button3.BackColor = Color.FromName(color_1);
        }
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (chek == 1) //доступность нажатия
            {
                if (nn == 0)//выводим сумму столбцов обычного либо транспанированного массива(по выбору)
                {
                    richTextBox1.Text += obj_1.mass_get_post_summ();
                }
                else
                {
                    richTextBox1.Text += obj_1.mass_get_post_summ_trans();
                }
            }
            else
            {
                CustomMessage error = new CustomMessage("Сначала создайте массив.");
                error.Show();
            }
        }
        private void button2_MouseEnter(object sender, EventArgs e)//дизайн кнопок
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout; 
                button2.Font = new Font(button2.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button2.Font = new Font(button2.Font.FontFamily, 10, style);
            }
            button2.ForeColor = Color.FromName(color_1);
            button2.BackColor = Color.FromName(color_4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)//дизайн кнопок
        {
            FontStyle style = FontStyle.Regular;
            button4.Font = new Font(button4.Font.FontFamily, 10, style);
            button4.ForeColor = Color.FromName(color_4);
            button4.BackColor = Color.FromName(color_1);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //обработка ввода "Начало" плохо обработаны исключения
        {
            var tb = (TextBox)sender;
            if (e.KeyChar != '\b')                      //ограничение на ввод
            {                                           //недопустимых значений
                e.Handled = !Char.IsDigit(e.KeyChar);
            }
            if (e.KeyChar.ToString().Equals("-"))
            {
                
                e.Handled = tb.SelectionStart != 0 || tb.Text.IndexOf("-") != -1; //ввод минуса только первым знаком
                if (!e.Handled)
                {
                    return;
                }
            }
            if (textBox1.Text.Length != 0)              //запрет ввода нескольких нулей в начале
            {
                if (textBox1.Text[0] == '0')
                {
                    textBox1.Text = textBox1.Text.Substring(1);
                }
            }

        }
        int nn = 1;
        private void button5_MouseClick(object sender, MouseEventArgs e) //обработка нажатия клавиши "Транспонировать"
        {
            /*
             * в данном случае кнопка
             * имеет два режима работы
             * если режим "транспонированный"
             * то все клавиши взаимодействуют с
             * транспонированным массивом
             * если "не транспонированный"
             * то всё работает в обычном режиме
             * */
            nn++;//проверка нажата ли клавиша
            if (nn > 1)
            {
                nn = 0;
            }
            if (nn == 0)
            {
                if (chek == 1) //вариации состтояний
                {//неактивный режим
                    button5.Text = "Не транспанированный";
                button5.ForeColor = Color.FromName(color_1);//дизайн кнопки
                button5.BackColor = Color.FromName(color_4);
                richTextBox1.Text = obj_1.mass_get();//вывод обычного массива
                }
                else//обработчик ошибок
                {
                    CustomMessage error = new CustomMessage("Сначала создайте массив.");
                    error.Show();
                }
            } 
            else if (nn == 1)//кнопка активна
            {
                if (chek == 1)
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = obj_1.mass_get_trans();//вывод транспанированного массива
                }
                else
                {
                    CustomMessage error = new CustomMessage("Сначала создайте массив.");
                    error.Show();
                }

                button5.Text = "Транспанированный";
                button5.ForeColor = Color.FromName(color_4);//дизайн кнопки
                button5.BackColor = Color.FromName(color_1);

            }

        }

        private void button4_MouseClick(object sender, MouseEventArgs e)//обработка нажатия клавиши "Вывести всё"
        {
            /*
             * выполняет сразу две функции на сумму и макс. число и сразу выводит всё
             * */
            if (chek == 1)
            {
                if (nn == 0)//проверяем на активность транспанирования
                {
                    richTextBox1.Clear();
                richTextBox1.Text += obj_1.mass_get_str_max();
                richTextBox1.Text += obj_1.mass_get_post_summ();
                }
                else
                {
                    richTextBox1.Clear();
                    richTextBox1.Text += obj_1.mass_get_str_max_trans();
                    richTextBox1.Text += obj_1.mass_get_post_summ_trans();
                }
            }
            else//отчёт об ошибке
            {
                CustomMessage error = new CustomMessage("Сначала создайте массив.");
                error.Show();
            }
        }
        private void button5_MouseEnter(object sender, EventArgs e)//дизайн кнопки
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout; 
                button5.Font = new Font(button5.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button5.Font = new Font(button5.Font.FontFamily, 10, style);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) //обработка второго ввода "Конец"
        {
            var tb = (TextBox)sender;
            if (e.KeyChar != '\b')                      //ограничение на ввод
            {                                           //недопустимых значений
                e.Handled = !Char.IsDigit(e.KeyChar);
            }
            if (e.KeyChar.ToString().Equals("-"))
            {
                e.Handled = tb.SelectionStart != 0 || tb.Text.IndexOf("-") != -1;//разрешить писать минус только в начале
                if (!e.Handled)
                {
                    return;
                }
            }
            if (textBox1.Text.Length != 0)              //запрет ввода нескольких нулей в начале
            {
                if (textBox1.Text[0] == '0')
                {
                    textBox1.Text = textBox1.Text.Substring(1);
                }
            }

        }

        private void button5_MouseLeave(object sender, EventArgs e)//дизайн кнопки
        {
            FontStyle style = FontStyle.Regular;
            button5.Font = new Font(button5.Font.FontFamily, 10, style);
        }
        private void button4_MouseEnter(object sender, EventArgs e)//дизайн кнопки
        {
            if (chek == 0)
            {
                FontStyle style = FontStyle.Strikeout; 
                button4.Font = new Font(button4.Font.FontFamily, 10, style);
            }
            else
            {
                FontStyle style = FontStyle.Regular;
                button4.Font = new Font(button4.Font.FontFamily, 10, style);
            }
            button4.ForeColor = Color.FromName(color_1);
            button4.BackColor = Color.FromName(color_4);
        }

        private void button2_MouseLeave(object sender, EventArgs e)//дизайн кнопки
        {
            FontStyle style = FontStyle.Regular;
            button2.Font = new Font(button2.Font.FontFamily, 10, style);
            button2.ForeColor = Color.FromName(color_4);
            button2.BackColor = Color.FromName(color_1);
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)//кнопка свернуть
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)//дизайн кнопки
        {
            pictureBox3.BackColor = Color.FromName(color_1);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)//дизайн кнопки
        {
            pictureBox3.BackColor = Color.FromName(color_2);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)//кнопка настройки
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }


        
    }
}
