using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIVS_LR2
{
    public partial class Form1 : Form
    {
        DateTime PVU = new DateTime(0, 0);
        int count = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            listBox1.ScrollAlwaysVisible = false;
         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            Luna_2 Reflector = new Luna_2(textBox1.Text, textBox2.Text, textBox1, textBox2, textBox4, listBox1, listBox2, timer1, PVU);
            if (Reflector.Lunokhod())
            {
                count++;
                textBox4.Text += count.ToString() + "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n УСПЕШНО: \r\n";       // ЭТИ СТРОКИ
                textBox4.Text += "\r\n Значение параметра а = \r\n" + textBox1.Text + " \r\n";     // ВЫВОДЯТ В ЛОГ СООБЩЕНИЕ
                textBox4.Text += "\r\n Значение параметра b = \r\n" + textBox2.Text + " \r\n ";
                checkBox3.Checked = true;
                checkBox4.Checked = false;
            }
            else
            {
                count++;
                textBox4.Text += count.ToString() + "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n ОШИБКА \r\n";  
                checkBox4.Checked = true;
                checkBox3.Checked = false;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            count++;
            textBox4.Text += "\r\n" + count.ToString() + "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n Произошла выгрузка данных. Блоки очищены. \r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            count++;
            textBox4.Text += "\r\n" + count.ToString() + "\r\n" + PVU.ToString("mm:ss:ffff") + "\r\n Очистка журнала данных огнем и мечом. Аминь. \r\n";
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PVU = PVU.AddMilliseconds(1);
            if (textBox1.Text != "")
            {
                checkBox1.Checked = true;
            }
            else checkBox1.Checked = false;
            if (textBox2.Text != "")
            {
                checkBox2.Checked = true;
            }
            else checkBox2.Checked = false;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }
    }
    public class BorderedLB : ListBox
    {
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor { get; set; }

        [DefaultValue(1)]
        public int BorderWidth { get; set; }

        public BorderedLB()
        {
            BorderColor = Color.Yellow;
            BorderWidth = 1;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var d = BorderWidth / 2;
            using (var pen = new Pen(BorderColor, BorderWidth))
                e.Graphics.DrawRectangle(pen, d, d, Width - 2 * d - 1, Height - 2 * d - 1);
        }
    }
}

