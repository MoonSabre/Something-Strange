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
    public partial class CylinderForm : Form
    {
        Cylinder Cyl;
        public CylinderForm()
        {
            Cyl = new Cylinder();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cyl.Radius = Convert.ToDouble(textBox1.Text);
                Cyl.High = Convert.ToDouble(textBox2.Text);
                
                label1.Text = Convert.ToString(Cyl.Square());
                toolStripLabel2.Text = textBox1.Text;
                toolStripLabel4.Text =  textBox2.Text;
                toolStripLabel6.Text = "Square";
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cyl.Radius = Convert.ToDouble(textBox1.Text);
                Cyl.High = Convert.ToDouble(textBox2.Text);
                label2.Text = Convert.ToString(Cyl.Volume());
                toolStripLabel2.Text = textBox1.Text;
                toolStripLabel4.Text = textBox2.Text;
                toolStripLabel6.Text = "Volume";
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
            catch
            {  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cyl.Print();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cyl.Read(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            toolStripLabel2.Text = textBox1.Text;
            toolStripLabel4.Text = textBox2.Text;
            if (toolStripLabel6.Text == "Volume")
            {
                Cyl.Volume();
                label2.Text = Convert.ToString(Cyl.Volume());
            }
            else if (toolStripLabel6.Text == "Square")
            {
                Cyl.Square();
                label1.Text = Convert.ToString(Cyl.Square());
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

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Введите радиус для дальнейших вычислений.";
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Введите высоту для дальнейших вычислений.";
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Отображение последнего действия и параметров.";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Вычисление площади цилиндра.";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Вычисление объема цилиндра.";
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления площади цилиндра.";
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления площади цилиндра.";
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления объема цилиндра.";
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Результат вычисления объема цилиндра.";
        }

        private void CylinderForm_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Эта форма демонстрирует методы для цилиндра.";
        }

        
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Мониторинг состояния экземпляра класса.";
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel7.Text = "Изменение параметров экземпляра и последнец операции.";
        }

        // дальше находится мусор
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Move(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CylinderForm_Load(object sender, EventArgs e)
        {

        }

       
    }
}
