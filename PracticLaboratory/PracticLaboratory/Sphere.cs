using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLaboratory
{
    class Sphere : GeometricalFigures
    {
        private double radius;
        public double Radius  // объявление переменной радиуса сферы.
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

        public Sphere() //  конструктор начальной инициализации.
        {
            Radius = 1;
        }

        public Sphere(double rad) // конструктор
        {
            Radius = rad;
        }

        public Sphere(Sphere Soh) // конструктор копирования
        {
            Radius = Soh.Radius;
        }

        public override double Square() // Площадь поверхности шара.
        {
            return (4 * Math.PI * Math.Pow(Radius, 2));
        }

        public override double Volume() // Объем шара.
        {
            return (1.33 * Math.PI * Math.Pow(Radius, 3));
        }

        public void Read(double radius) // ввод полей класса. 
        {
            Radius = radius;
        }

        public void Print() // распечатка полей класса.
        {
            System.Windows.Forms.MessageBox.Show("Радиус сферы равен: " + Radius + ".");
        }
    }
}
