using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio;

namespace Fiahrette_3
{
    public partial class Form1 : Form
    {
        DateTime Phoshoros = new DateTime(0, 0); // ТАЙМЕР ДЛЯ ЛОГА.
        DateTime Hesperos = new DateTime(0, 0);
        DateTime Prometey = new DateTime(0, 0);
        DateTime Sigura = new DateTime(0, 0);


        private NAudio.Wave.WaveFileReader Rachmaninov = null;
        private NAudio.Wave.WaveFileReader Chaikovsky = null;
        private NAudio.Wave.DirectSoundOut Borodin = new NAudio.Wave.DirectSoundOut();

        private Amaranthus AtLaunch = new Amaranthus();
        private Amaranthus DeLaunch = new Amaranthus();
        private Random Service = new Random();

        private bool WarFlag = false;
        private bool Hit = false;
        private bool MissileCounter = false;
        private int MissileCount = 0;
        private int HitMis = 0;
        private int MisMis = 0;
        private int CheckCount = 0;
        private int DefCount = 0;

        public Form1()
        {

            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Interval = 300;
            timer3.Interval = 300;
            timer4.Interval = 4000;
            if (timer1.Enabled)
            {
                timer1.Stop();
                checkBox5.Checked = checkBox6.Checked = true;

            }
            else { timer1.Start(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllTimersShutDown();
            AtLaunch.DelList();
            DeLaunch.DelList();
            StopMusic();
            MissileCount = 0;
            HitMis = 0;
            MisMis = 0;
            CheckCount = 0;
            DefCount = 0;
            WarFlag = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Phoshoros = Phoshoros.AddMilliseconds(1);
            CheckCount++;
            double a = DefconCalculating();
            label1.Text = label16.Text = a.ToString();
            label2.Text = MissileCount.ToString();
            label3.Text = CheckCount.ToString();
            if (WarFlag) checkBox1.Checked = true;
            else checkBox1.Checked = false;
            if (MissileCount >= 4)
            {
                timer1.Stop();
                checkBox2.Checked = true;
                AllTimersGoes();
                Musice1();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Hesperos = Hesperos.AddSeconds(1);
            AttackLaunch();
            double a = DefconCalculating();
            label15.Text = DefCount.ToString();
            label18.Text = label14.Text = "АТАКА";
            checkBox4.Checked = checkBox5.Checked = true;
            label8.Text = AtLaunch.ListLength().ToString();

            if (DefCount >= 4)
            {
                AllTimersShutDown();
                timer4.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Hesperos = Hesperos.AddSeconds(1);
            DefensiveLaunch();
            label9.Text = DeLaunch.ListLength().ToString();
            checkBox6.Checked = true;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Hesperos = Hesperos.AddSeconds(100);

            if (AtLaunch == null)
            {
                checkBox7.Checked = true;
            }
            if ((AtLaunch != null) && (DeLaunch == null))
            {
                checkBox9.Checked = true;
            }
            if (HitProbability(AtLaunch, DeLaunch))
            {
                label21.Text += HitMis.ToString();
                label22.Text += MisMis.ToString();
                label20.Text = MisMis.ToString();
                if (MisMis == AtLaunch.ListLength())
                {
                    checkBox10.Checked = true;
                }
                timer4.Stop();
            }
        }

        private void AllTimersShutDown()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

        }

        private void AllTimersGoes()
        {
            timer2.Start();
            timer3.Start();
        }

        private double DefconCalculating()
        {
            Random Rete = new Random();
            double a = 4;
            double b = 5;
            double r = Rete.NextDouble();
            double Fed = a * ((2 * r) - 1) + b;
            if (Fed <= 5)
            {
                WarFlag = true;
                MissileCount++;
                DefCount = 0;
            }
            else
            {
                MissileCount = 0;
                WarFlag = false;
                DefCount++;
            }
            return Fed;
        }

        private int TimeOfFly()
        {
            Random TimeOfFly = new Random();
            return TimeOfFly.Next(10, 50);
        }

        private void AttackLaunch()
        {
            if (checkBox2.Checked)
            {
                AtLaunch.AddLast(TimeOfFly(), 'A');
            }
        }

        private void DefensiveLaunch()
        {
            if (AtLaunch != null)
            {
                DeLaunch.AddLast(TimeOfFly(), 'D');
                DeLaunch.AddLast(TimeOfFly(), 'D');
            }
        }
        private bool HitProbability(Amaranthus List1, Amaranthus List2)
        {
            if ((List1 != null) && (List2 != null))
            {
                for (int i = 0; i < List1.ListLength(); i++)
                {
                    double a = List1.CountedNode(i).Info;
                    double at = a * ((2 * Service.NextDouble()) - 1) + (a + 5);
                    double de = a * ((2 * Service.NextDouble()) - 1) + (a + 5);
                    double de1 = a * ((2 * Service.NextDouble()) - 1) + (a + 5);
                    if (at > de)
                    {
                        if (at > de1)
                        {
                            Hit = true;
                            checkBox8.Checked = true;
                            textBox1.Text += "\r\n Ракета №" + (i + 1) + " попала в цель! \r\n";
                            Musice2();
                            HitMis++;
                        }
                        else
                        {
                            Hit = false;
                            textBox1.Text += "\r\n Ракета №" + (i + 1) + " сбита ракетой №" + (i + 2) + "!\r\n";
                            MisMis++;
                        }
                    }
                    else
                    {
                        Hit = false;
                        textBox1.Text += "\r\n Ракета №" + (i + 1) + " сбита ракетой №" + (i + 1) + "!\r\n";
                        MisMis++;
                    }
                }
            }
            return true;
        }


        //private double GoverLoyalityCalculating(int Loya)
        //{
        //    Random Health = new Random();
        //    double a = Health.Next(0,5);
        //    double b = Health.Next(0,(int)a);
        //    double x = Health.Next((int)b, (int)a);
        //    double sum = (x - a) / (b - a);
        //    if (sum <=1)
        //    {
        //        GovFlag = true;
        //    }
        //    return sum;
        //}

        //private bool DefConIndex(int Def, int Gov)
        // {
        //    Random Effication = new Random();
        //    double Sigura = (Effication.Next())
        //  }

        private void Musice1()
        {
            Chaikovsky = new NAudio.Wave.WaveFileReader("Тревога.wav");
            Borodin = new NAudio.Wave.DirectSoundOut();
            Borodin.Init(new NAudio.Wave.WaveChannel32(Chaikovsky));
            Borodin.Play();
        }
        private void Musice2()
        {
            Chaikovsky = new NAudio.Wave.WaveFileReader("BOOM.wav");
            Borodin = new NAudio.Wave.DirectSoundOut();
            Borodin.Init(new NAudio.Wave.WaveChannel32(Chaikovsky));
            Borodin.Play();
        }

        private void StopMusic()
        {
           if (Borodin.PlaybackState == NAudio.Wave.PlaybackState.Playing) Borodin.Stop();

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}

