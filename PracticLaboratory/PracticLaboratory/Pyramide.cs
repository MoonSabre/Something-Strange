using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLaboratory
{
    class Pyramide : GeometricalFigures
    {
        private double high;
        private double baseside;
        public double High // объявление высоты пирамиды. 
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
        public double BaseSide // объявление стороны основания пирамиды.
        {
            get
            {
                return baseside;
            }
            set
            {
                baseside = value;
            }
        }

        public Pyramide() // конструктор начальной инициализации.
        {
            High = 1;
            BaseSide = 1;
        }
        public Pyramide(double high, double baseside) // конструктор.
        {
            High = high;
            BaseSide = baseside;
        }

        public Pyramide(Pyramide Pyrr) // конструктор копирования.
        {
            High = Pyrr.High;
            BaseSide = Pyrr.BaseSide;
        }

        public override double Volume() // объем пирамиды.
        {
            return (0.33 * High * ((Math.Pow(BaseSide, 2) * 0.85)));
        }


        public override double Square() // площадь пирамиды.
        {
            return 4 * ((Math.Pow(BaseSide, 2) * Math.Sqrt(3)) / 4);
        }

        public void Read(double heigh, double basiside) //ввод полей класса. 
        {
            this.High = heigh;
            this.BaseSide = basiside;
        }

        public void Print() // распечатка полей класса. 
        {
            System.Windows.Forms.MessageBox.Show("Высота пирамиды равна: " + High + ". Сторона основания пирамиды равна: " + BaseSide + ".");
        }
    }
}
