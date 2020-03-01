using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticLaboratory
{
    public partial class PyramideForm : Form
    {
        Pyramide Pyrr;
        public PyramideForm()
        {
            Pyrr = new Pyramide();
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pyrr.High = Convert.ToDouble(textBox1.Text);
                Pyrr.BaseSide = Convert.ToDouble(textBox2.Text);
                label1.Text = Convert.ToString(Pyrr.Square());
                toolStripLabel2.Text = textBox1.Text;
                toolStripLabel4.Text = textBox2.Text;
                toolStripLabel6.Text = "Square";
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pyrr.High = Convert.ToDouble(textBox1.Text);
                Pyrr.BaseSide = Convert.ToDouble(textBox2.Text);
                label2.Text = Convert.ToString(Pyrr.Volume());
                toolStripLabel2.Text = textBox1.Text;
                toolStripLabel4.Text = textBox2.Text;
                toolStripLabel6.Text = "Volume";
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pyrr.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pyrr.High = Convert.ToDouble(textBox1.Text);
            Pyrr.BaseSide = Convert.ToDouble(textBox2.Text);
            Pyrr.Read(Pyrr.High, Pyrr.BaseSide);
            toolStripLabel2.Text = textBox1.Text;
            toolStripLabel4.Text = textBox2.Text;
            if (toolStripLabel6.Text == "Volume")
            {
                Pyrr.Volume();
                label2.Text = Convert.ToString(Pyrr.Volume());
            }
            else if (toolStripLabel6.Text == "Square")
            {
                Pyrr.Square();
                label1.Text = Convert.ToString(Pyrr.Square());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

       

        private void PyramideForm_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Эта форма демонстрирует методы для работы с пирамидой.";
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Введите высоту для дальнейших действий.";
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Введите сторону основания для дальнейших действий.";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Вычисление площади пирамиды.";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Вычисление объема пирамиды.";
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Отображение последнего действия и параметров.";
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления площади пирамиды.";
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления площади пирамиды.";
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления объема пирамиды.";
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления объема пирамиды.";
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Мониторинг состояния экземпляра класса.";
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Изменение параметров и рез-та последней операции.";
        }
        // не особо нужный материал.
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void PyramideForm_Load(object sender, EventArgs e)
        {

        }
    }
}
