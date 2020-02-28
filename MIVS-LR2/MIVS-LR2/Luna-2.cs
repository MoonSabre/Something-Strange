using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIVS_LR2
{
    class Luna_2
    {
        TextBox textBox1, textBox2, textBox4;
        ListBox listBox1, listBox2;
        Timer Luna_Timer = new Timer();
        DateTime Luna_Calend = new DateTime(0, 0);
        public double T0
        {
            get;
            set;
        }
        public double T1
        {
            get;
            set;
        }

        public Luna_2(string t0, string t1, TextBox txt1, TextBox txt2, TextBox txt4, ListBox lbx1, ListBox lbx2, Timer tmr, DateTime DTR)
        {
            try
            {
                T0 = double.Parse(t0);
                T1 = double.Parse(t1);
            }
            catch (Exception)
            { }
            textBox1 = txt1;
            textBox2 = txt2;
            textBox4 = txt4;
            listBox1 = lbx1;
            listBox2 = lbx2;
            Luna_Timer = tmr;
            Luna_Calend = DTR;
        }

        public bool Lunokhod()
        {
            bool Lunar_Flag = false;
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                try
                {
                    Random Luna_RND = new Random();
                    double Luna_RND2, Luna_Time = 0;
                    double[] Luna_Tau = new double[200]; // МАССИВ ИНТЕРВАЛОВ ВРЕМЕНИ.
                    for (int i = 0; i < 200; i++)
                    {
                        Luna_RND2 = Luna_RND.NextDouble();
                        Luna_Tau[i] = T0 + ((T1 - T0) * Luna_RND2);
                        Luna_Time += Luna_Tau[i];
                        listBox1.Items.Add((i + 1) + ")" + Luna_Tau[i]);
                        if ((i + 1) % 10 == 0)
                        {
                            listBox2.Items.Add(((i + 1) / 10) + ") " + Luna_Time);
                        }
                    }
                    Lunar_Flag = true;
                }
                catch (Exception)
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            return Lunar_Flag;
        }
    }
}

