using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyzer_TF_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Analyzer_T.Check(textBox1.Text, textBox2, listBox1, listBox2))
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                textBox2.Text = "\r\n Анализ синтаксиса проведен успешно! \r\n";
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Select();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random Rex = new Random();
            if (Rex.Next(1, 5) == 1) textBox1.Text = "VAR name : file of  char;";
            else if (Rex.Next(1, 5) == 2) textBox1.Text = "VAR _A_B : file of  mytype;";
            else if (Rex.Next(1, 5) == 3) textBox1.Text = "VAR _A_C : TEXT;";
            else if (Rex.Next(1, 5) == 4) textBox1.Text = "VAR C12 : file of  STRING[10];";
            else if (Rex.Next(1, 5) == 5) textBox1.Text = "VAR D : myfile;";
        }
    }
}
