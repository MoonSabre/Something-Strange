using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace MIVS_LR1
{
    public partial class Form1 : Form
    {
        private const int N = 1000; // ЧИСЛО РЕАЛИЗАЦИЙ.
        private const int n = 15; // ЧИСЛО ИНТЕРВАЛОВ.
        DateTime PVU = new DateTime(0, 0); // ТАЙМЕР ДЛЯ ЛОГА.
        private int count = 0; // СЧЕТЧИК СОБЫТИЙ ЛОГА.

        public Form1()
        {
            InitializeComponent();
            textBox1.Select(); // ВЫБОР ПЕРВОГО ТЕКСТОВОГО ПОЛЯ ДЛЯ ВВОДА ЗНАЧЕНИЯ.
            timer1.Start(); // ЗАПУСК ТАЙМЕРА.
        }



        private void button1_Click_1(object sender, EventArgs e) // ИСПОЛНИТЕЛЬНЫЙ КОД ПРОГРАММЫ.
        {
            count++;
            textBox4.Text += "\r\n" + count.ToString() + "\r\n"; // ВЫВОД ПОРЯДКОВОГО СОБЫТИЯ ЛОГА.
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                if (radioButton1.Checked) // ПРОВЕРКА ВЗВОДА ГРАФЫ.
                {
                    if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked)) // ПРОВЕРКА ВЗВОДА ТУМБЛЕРОВ.
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        try
                        {
                            // БП-1 (БЛОК ПРЕОБРАЗОВАНИЙ - ПЕРВЫЙ) - НАЧАЛО.
                            double a = double.Parse(textBox1.Text); // ПАРАМЕТР А.
                            double b = double.Parse(textBox2.Text); // ПАРАМЕТР В.
                                                                    // КОНЕЦ БП-1.

                            // БПЛ-1 (БЛОК ПЕЧАТИ ЛОГА - ПЕРВЫЙ) - НАЧАЛО.
                            textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n УСПЕШНО: \r\n";       // ЭТИ СТРОКИ
                            textBox4.Text += "\r\n Значение параметра а = \r\n" + textBox1.Text + " \r\n";     // ВЫВОДЯТ В ЛОГ СООБЩЕНИЕ
                            textBox4.Text += "\r\n Значение параметра b = \r\n" + textBox2.Text + " \r\n ";    // ОБ УСПЕШНОМ ВЫЧИСЛЕНИИ.
                            checkBox4.Checked = false;
                            checkBox5.Checked = false;
                            checkBox6.Checked = false;
                            checkBox7.Checked = false;
                            checkBox8.Checked = false;
                            checkBox9.Checked = false;                                                                                   // КОНЕЦ БПЛ-1.

                            // БВ-1 (БЛОК ВЫЧИСЛЕНИЙ - ПЕРВЫЙ) - НАЧАЛО.
                            Random Venera_RND = new Random();
                            double Venera_RSD;
                            double[] Venera_X = new double[N]; // МАССИВ РЕАЛИЗАЦИЙ.
                            for (int i = 0; i < N; i++) // ВЫЧИСЛЕНИЕ СЛУЧАЙНОЙ ВЕЛИЧИНЫ.
                            {
                                // F(x) = ri; F(x) = 1/2a * (x-b+a); ri = 1/2a * (x-b+a); x = a*(2*ri-1)+b;
                                Venera_RSD = Venera_RND.NextDouble();
                                Venera_X[i] = a * (2 * Venera_RSD - 1) + b; // ФОРМУЛА ВЫЧИСЛЕНИЯ СЛУЧАЙНОЙ ВЕЛИЧИНЫ.
                            }

                            //Array.Sort(Venera_X); // СОРТИРОВКА МАССИВА ПО ВОЗРАСТАНИЮ.
                            for (int i = 0; i < N; i++)
                            {
                                listBox1.Items.Add((i + 1) + ")  " + Venera_X[i]);
                            }
                            // КОНЕЦ БВ-1.

                            // БИГ-1 (БЛОК ИНИЦИАЛИЗАЦИИ ГИСТОГРАММЫ - ПЕРВЫЙ) - НАЧАЛО.
                            double Venera_APH = ((b + a) - (b - a)) / (double)n; // ДЛИНА ИНТЕРВАЛА.

                            // БОИ-1 (БЛОК ОПРЕДЕЛЕНИЯ ИНТЕРВАЛОВ - ПЕРВЫЙ) - НАЧАЛО.
                            double[] Venera_ORB = new double[n]; // ИНТЕРВАЛ.
                            Venera_ORB[0] = b - a; // СТАРТОВОЕ ЗНАЧЕНИЕ.
                            for (int i = 0; i + 1 < n; i++)
                            {
                                Venera_ORB[i + 1] = Venera_ORB[i] + Venera_APH; // НАЗНАЧЕНИЕ ДЛИН ИНТЕРВАЛА.
                            }
                            // КОНЕЦ БОИ-1.
                            // БВЧ-1 (БЛОК ВЫЧИСЛЕНИЯ ЧАСТОТ - ПЕРВЫЙ) - НАЧАЛО. 
                            int[] Venera_CTSS = new int[n]; // СЧЕТЧИКИ ИНТЕРВАЛОВ.
                            for (int co = 0; co < n; co++)
                            {
                                Venera_CTSS[co] = 0;
                                for (int j = co; j < n; j++)
                                {
                                    for (int i = 0; i < N; i++)
                                    {
                                        if ((Venera_X[i] >= Venera_ORB[j]) && (Venera_X[i] < Venera_ORB[j] + Venera_APH)) // ОПРЕДЕЛЕНИЕ ПОПАДАНИЯ СЛУЧАЙНОЙ ВЕЛИЧИНЫ В ИНТЕРВАЛ.
                                        {
                                            Venera_CTSS[j]++;
                                        }
                                    }
                                }
                                listBox2.Items.Add((co + 1) + ")" + Venera_CTSS[co]);
                            }
                            // КОНЕЦ БВЧ-1.

                            // БВВГ-1 (БЛОК ВЫЧИСЛЕНИЯ ВЫСОТЫ ГИСТОГРАММЫ - ПЕРВЫЙ) - НАЧАЛО.
                            double[] h = new double[n]; // ВЫСОТА.
                            for (int i = 0; i < n; i++)
                            {
                                h[i] = (double)Venera_CTSS[i] / (double)N;
                            }
                            // КОНЕЦ БВВГ - 1.

                            // БВКП-1 (БЛОК ВЫЧИСЛЕНИЯ КОЭФФИЦИЕНТА ПИРСОНА - ПЕРВЫЙ) - НАЧАЛО. 
                            double Venera_PRS1 = 0; // КОЭФФИЦИЕНТ ПИРСОНА.
                            for (int i = 0; i < n; i++)
                            {
                                Venera_PRS1 += Math.Pow(Venera_CTSS[i], 2);
                            }
                            double k = (double)n;
                            double k1 = (double)N;
                            double Venera_PRS2 = ((k / k1) * Venera_PRS1) - N;
                            chart1.Series.Clear();
                            Series series1 = chart1.Series.Add("Гистограмма частот");
                            Series series2 = chart1.Series.Add("Полигон частот");
                            chart1.Legends.Clear();
                            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                            series1.ChartType = SeriesChartType.Column;
                            series1.Points.DataBindXY(Venera_ORB, h);
                            series2.ChartType = SeriesChartType.FastPoint;
                            series2.Points.DataBindXY(Venera_ORB, h);
                            textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + " \r\n Значение коэффициента Пирсона равно \r\n" + Venera_PRS2 + " \r\n";
                            checkBox4.Checked = false;
                            checkBox5.Checked = false;
                            checkBox6.Checked = false;
                            checkBox7.Checked = false;
                            checkBox8.Checked = false;
                            checkBox9.Checked = true;
                        }
                        // КОНЕЦ БВКП-1.
                        // КОНЕЦ БИГ-1.

                        // БОО-1 (БЛОК ОБРАБОТКИ ОШИБОК - ПЕРВЫЙ) - НАЧАЛО.
                        catch (Exception)
                        {
                            // ОЧИСТКА ТЕКСТОВЫХ ПОЛЕЙ И СПИСКОВ.
                            listBox1.Items.Clear();
                            listBox2.Items.Clear();
                            textBox1.Clear();
                            textBox2.Clear();
                            // ВЫВЕДЕНИЕ В ЛОГ СООБЩЕНИЯ ОБ ОШИБКЕ.
                            textBox4.Text += "\r\n" + PVU.ToString("mm:ss:fff") + " \r\n  ОШИБКА: Не удалось выполнить расчет! \r\n  ";
                            textBox1.Select();
                            checkBox4.Checked = false;
                            checkBox5.Checked = true;
                            checkBox6.Checked = false;
                            checkBox7.Checked = false;
                            checkBox8.Checked = false;
                            checkBox9.Checked = false;
                        }
                        // КОНЕЦ БОО-1.
                    }
                    // ВЫВЕДЕНИЕ В ЛОГ СООБЩЕНИЯ ОБ ОШИБКЕ.
                    else
                    {
                        textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + " \r\n  ОШИБКА: Отсутствует готовность! \r\n  ";
                        checkBox4.Checked = false;
                        checkBox5.Checked = false;
                        checkBox6.Checked = true;
                        checkBox7.Checked = false;
                        checkBox8.Checked = false;
                        checkBox9.Checked = false;
                    }
                }
                else
                if (radioButton2.Checked)
                {
                    // ВЫВЕДЕНИЕ В ЛОГ СООБЩЕНИЯ ОБ ОШИБКЕ.
                    textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + " \r\n ОШИБКА: Неквалифицированный пользователь \r\n";
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = true;
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                }
                else // ВЫВЕДЕНИЕ В ЛОГ СООБЩЕНИЯ ОБ ОШИБКЕ.
                {
                    textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + " \r\n ОШИБКА: Не активирована кнопка! \r\n";
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = true;
                    checkBox9.Checked = false;
                }
            }
            else
            {
                textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + " \r\n ОШИБКА: Не заполнены поля! \r\n";
                checkBox4.Checked = true;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e) // ОЧИСТКА ДАННЫХ.
        {
            count++;
            textBox4.Text += "\r\n" + count.ToString() + "\r\n"; // ВЫВОД ПОРЯДКОВОГО СОБЫТИЯ ЛОГА. 
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
            // ВЫВЕДЕНИЕ В ЛОГ СООБЩЕНИЯ ОБ ОЧИСТКЕ.
            textBox4.Text += "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n Произошла выгрузка данных. Блоки очищены. \r\n";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // РАБОТА ТАЙМЕРА ПО МИЛЛИСЕКУНДАМ.
            PVU = PVU.AddMilliseconds(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count++;
            textBox4.Text = "\r\n" + count.ToString() + "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n Очистка журнала данных огнем и мечом. Аминь. \r\n";
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        // ПУСТЫЕ ФУНКЦИИ.
        private void Form1_Load(object sender, EventArgs e)
        { }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        { }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
