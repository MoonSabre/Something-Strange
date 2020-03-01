using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLaboratory
{
    class Cylinder : GeometricalFigures
    {
        private double high;
        private double radius;
        public double High // объявление переменной высоты цилиндра.
        {
            get
            {
                return high;
            }
            set
            {
                high = value;
            }
        }

        public double Radius // объявление переменной радиуса цилиндра.
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public Cylinder() // конструктор начальной инициализации.
        {
            Radius = 1;
            High = 1;

        }

        public Cylinder(double high, double rad) // конструктор.
        {
            High = high;
            Radius = rad;
        }

        public Cylinder(Cylinder Cyl) // конструктор копирования.
        {
            High = Cyl.High;
            Radius = Cyl.Radius;
        }

        public override double Volume() // объем цилиндра.
        {
            return (Math.PI * Math.Pow(Radius, 2) * High);
        }

        public override double Square() // площадь цилиндра.
        {
            return (2 * Math.PI * Radius * High);
        }

        public void Read(double radius, double height) // ввод полей класса. 
        {
            this.Radius = radius;
            this.High = height;
        }

        public void Print() // распечатка полей класса.
        {
            System.Windows.Forms.MessageBox.Show("Радиус цилиндра равен: " + Radius + ". Высота цилиндра равна: " + High + ".");
        }
    }
}