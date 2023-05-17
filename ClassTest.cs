using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba9
{
    class ClassTest //основной класс
    {
   
        // поля класса
        double[,] mass; // массив с отложенной инициализацией
        double min,max;
        double[] mass_str;// диапазон случ. числа
        double[] mass_post_summ;
        int n_leg, m_leg;
        int under,check_double;

        double[,] mass_trans;

        public ClassTest(int n, int m, double mn, double mx, int prov, int dob) // конструктор с 6-ю параметрами
        {
            check_double = dob; //инициализация переменных в конструкторе
            under = prov;
            min = mn;
            max = mx;
            n_leg = n;
            m_leg = m;
            mass = new double[n,m]; // инициализация массива
            mass_trans = new double[m_leg, n_leg];
            mass_ini();
            // вызвать закрытый метод заполнения массива случ. числами
        }
        void mass_ini() //метод генерации рандомных значений
        {
            Random Rand = new Random(); // объявить объект класса (типа) Random
            if (check_double == 0) //проверка на генерацию вещественных или целых чисел
            {
                Random Rand2 = new Random();
                int min_need = 0, max_need = 99;//мин. и макс. дробной части
                int min_need1 = 0, max_need1 = 99;//мин. и макс. дробной части для первого и последнего числа
                int n1, n2;//n1 - целая часть     n2 - дробная часть
                int min_int, max_int;//мин. и макс. для целой части
                if (Convert.ToString(min).Contains(',')) //проверяем есть ли разделитель целой и дробной части
                {
                    min_int = (int)min;//берём целое для мин.
                    min_need1 = Convert.ToInt32((min - min_int) * 100);//берём дробное. для мин.
                }
                else
                {
                    min_int = Convert.ToInt32(min); //берём всё число если оно и так целое
                }

                if (Convert.ToString(max).Contains(','))//проверяем есть ли разделитель целой и дробной части
                {
                    max_int = (int)max;//берём целое для макс.
                    max_need1 = Convert.ToInt32((max - max_int) * 100);//берём дробное для макс.
                }
                else
                {
                    max_int = Convert.ToInt32(max);//берём всё число если оно и так целое
                }

                for (int j = 0; j < n_leg; j++)
                {
                    for (int i = 0; i < m_leg; i++)//цикл для заполнения числами с запятой
                    {
                        n1 = Rand.Next(min_int, max_int);//рандомная целая часть
                        n2 = Rand2.Next(min_need, max_need);//рандомная дробная часть
                        if (n1 == min_int && n2 < min_need) //проверяем не получилось ли число меньше мин. по дробной части
                        {
                            n2 = Rand2.Next(min_need1, max_need); //если число меньше генерируем снова на основе дробной части мин. числа
                        }
                        if (n1 == max_int && n2 > max_need) //проверяем не получилось ли число больше макс. по дробной части
                        {
                            n2 = Rand2.Next(min_need, max_need1); //если число больше генерируем снова на основе дробной части макс. числа
                        }
                        mass[j, i] = Convert.ToDouble(Convert.ToString(n1) + "," + Convert.ToString(n2)); //заполняем массив склеивавя целую и дробную часть
                    }

                }
            }
            else
            {
                for (int j = 0; j < n_leg; j++) //цикл для целых чисел
                {
                    for (int i = 0; i < m_leg; i++)
                    {
                        mass[j, i] = Rand.Next(Convert.ToInt32(min), Convert.ToInt32(max));
                    }
                }
            }
        }

        public string mass_get() //метод получения основного массива в виде строки
        {
            string ret = "";
            for (int j = 0; j < n_leg; j++)//цикл заполнения строки
            {
                for (int i = 0; i < m_leg; i++)
                {
                    if (under == 1)//проверяем на режим "ячеек"
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass[j, i])+"   ";
                    }
                }
                ret += "\n";
            }
            return ret;//возвращение строки
        }
        public string mass_get_trans() //метод получения транспонированного массива в виде строки
        {
            string ret = "";
            for (int i = 0; i < m_leg; i++)//массив заполнения строки
            {
                for (int j = 0; j < n_leg; j++)
                {
                    if (under == 1)
                    {
                        mass_trans[i, j] = mass[j, i];//переписываем основной массив в доп.
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        mass_trans[i, j] = mass[j, i];//переписываем основной массив в доп.
                        ret += String.Format("{0,7:f}", mass[j, i]) + "   ";
                    }
                }
                ret += "\n";
            }
                return ret;
        }
        public string mass_get_str_max() //метод получения максимума по строчкам в обычном массиве
        {
            string ret = "";
            mass_str = new double[m_leg];//массив для заполнения его значениями строки
            for (int j = 0; j < n_leg; j++)
            {
                for (int i = 0; i < m_leg; i++)
                {
                    mass_str[i] = mass[j, i];//заносим данные из двумерного в одномерный
                    if (under == 1)
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "   ";
                    }
                }
                ret += " Max: " + String.Format("{0:f2}",mass_str.Max()) + " \n";//в каждой строке выводим максимум
            }
            return ret;
        }
        public string mass_get_post_summ() //метод получения суммы в обычном массиве
        {
            string ret = "";
            for (int k = 0; k < m_leg*10; k++)//небольшой цикл для строчки "Суммы столбцов"
            {     
                ret += "-";
            }
            ret += "\nСумма столбцов\n" + ret + "\n" ;
            mass_post_summ = new double[m_leg];//инициализация массива
            for (int j = 0; j < m_leg; j++)//цикл подсчёта суммы по столбцам
            {
                mass_post_summ[j] = 0;
                for (int i = 0; i < n_leg; i++)
                {
                    mass_post_summ[j] += mass[i,j]; //считаем сумму столбца
                }
                if (under == 1)
                {
                    ret += String.Format("{0,7:f}", mass_post_summ[j]) + "  |";
                }
                else
                {
                    ret += String.Format("{0,7:f}", mass_post_summ[j]) + "   ";
                }
            }
            return ret;
        }
        public string mass_get_str_max_trans() //метод получения максимума по строчкам в транспонированном массиве
        {
            string ret = "";
            mass_str = new double[m_leg]; //массив для заполнения его значениями строки
            for (int j = 0; j < m_leg; j++)
            {
                for (int i = 0; i < n_leg; i++)
                {
                    mass_str[i] = mass_trans[j, i];//заносим данные из двумерного в одномерный
                    if (under == 1)
                    {
                        ret += String.Format("{0,7:f}", mass_trans[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass_trans[j, i]) + "   ";
                    }
                }
                ret += " Max: " + String.Format("{0:f2}", mass_str.Max()) + " \n";//в каждой строке выводим максимум
            }
            return ret;
        }
        public string mass_get_post_summ_trans() //метод получения суммы столбцов в транспонированном массиве
        {
            string ret = "";
            for (int k = 0; k < m_leg * 10; k++)//небольшой цикл для строчки "Суммы столбцов"
            {
                ret += "-";
            }
            ret += "\nСумма столбцов\n" + ret + "\n";
            mass_post_summ = new double[m_leg];//инициализация массива
            for (int j = 0; j < n_leg; j++)//цикл подсчёта суммы по столбцам
            {
                mass_post_summ[j] = 0;
                for (int i = 0; i < m_leg; i++)
                {
                    mass_post_summ[j] += mass_trans[i, j];//считаем сумму столбца
                }
                if (under == 1)
                {
                    ret += String.Format("{0,7:f}", mass_post_summ[j]) + "  |";
                }
                else
                {
                    ret += String.Format("{0,7:f}", mass_post_summ[j]) + "   ";
                }
            }
            return ret;
        }
    }
}
