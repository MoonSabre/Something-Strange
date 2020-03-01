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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            label1.Text = ("Общие требования: в начале программы вывести задание, в процессе работы выводить подсказки пользователю \n (что ему нужно ввести, чтобы продолжить выполнение программы). В иерархии классов должен быть общий предок с \n чисто виртуальными функциями,  нужными по заданию, а также с процедурами вывода на экран состояния экземпляра \n класса (void Print()) и ввода полей класса с клавиатуры (void Read()). Для всех классов необходимо реализовать \n конструктор копирования.После работы программы вся динамически выделенная  память должна быть освобождена. \n Взаимодействие с пользователем организовать в виде простого меню, \n обеспечивающего возможность переопределения исходных данных и завершение работы программы. \n \n Вариант №17: Написать программу, в которой описана иерархия классов: геометрические фигуры(шар, цилиндр, пирамида). \n Реализовать методы вычисления объема и площади поверхности фигуры. Продемонстрировать работу всех методов \n классов, предоставив пользователю выбор типа фигуры для демонстрации. ");

        }

        private void button1_Click(object sender, EventArgs e)
        {}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void label5_Click(object sender, EventArgs e)
        { }

        private void button2_Click(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {}

        protected virtual void button1_Click_1(object sender, EventArgs e)
        {
            SphereForm Sphear = new SphereForm();
            Sphear.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PyramideForm Pyrra = new PyramideForm();
            Pyrra.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CylinderForm Cylin = new CylinderForm();
            Cylin.Show();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
           

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "Вы выбрали пирамиду.";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            toolStripStatusLabel1.Text = "Добро пожаловать. Пожалуйста, выберите одну из трех форм ниже:";
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "Вы выбрали цилиндр.";

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "Вы выбрали шар.";
        }
    }
}
