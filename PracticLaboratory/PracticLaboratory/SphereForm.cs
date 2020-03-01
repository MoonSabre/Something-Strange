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
   
    public partial class SphereForm : Form
    {
        Sphere Sphe;
        public SphereForm()
        {
            Sphe = new Sphere();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) // Square
        {
            try
            {
                Sphe.Radius = Convert.ToDouble(textBox1.Text);
                label1.Text = Convert.ToString(Sphe.Square());
                toolStripLabel4.Text = textBox1.Text;
                textBox1.Clear();
                textBox1.Select();
                toolStripLabel3.Text = "Square";
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e) // Volume
        {
            try
            {
                Sphe.Radius = Convert.ToDouble(textBox1.Text);
                label2.Text = Convert.ToString(Sphe.Volume());
                toolStripLabel4.Text = textBox1.Text;
                textBox1.Clear();
                textBox1.Select();
                toolStripLabel3.Text = "Volume";
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e) // Print
        {
            Sphe.Print();
        }

        private void button4_Click(object sender, EventArgs e) // Read
        {
            try
            {
                Sphe.Read(Convert.ToDouble(textBox1.Text));
                toolStripLabel4.Text = textBox1.Text;
                if (toolStripLabel3.Text == "Volume")
                {
                    label2.Text = Convert.ToString(Sphe.Volume());

                }
                else if (toolStripLabel3.Text == "Square")
                {
                    label1.Text = Convert.ToString(Sphe.Square());
                }
            }
            catch
            { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Введите радиус для расчета объема и площади.";
        }

        private void SphereForm_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Эта форма демонстрирует методы для шара.";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Эта кнопка рассчитает площадь поверхности шара.";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Эта кнопка рассчитает объем шара.";
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Результат расчета площади поверхности шара.";
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Результат расчета объема шара.";
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Результат расчета площади поверхности шара.";
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Результат расчета объема шара.";
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Отображение последнего действия и параметра.";
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Мониторинг состояния экземпляра класса.";
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel5.Text = "Изменение параметров и рез-та последней операции.";
        }

      
        // дальше находится не особо нужный код.
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SphereForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
