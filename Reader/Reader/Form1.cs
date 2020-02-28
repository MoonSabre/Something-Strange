using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;

namespace Reader
{
    public partial class Form1 : Form
    {
        private NAudio.Wave.WaveFileReader Clock = null;
        private NAudio.Wave.DirectSoundOut Play1 = new NAudio.Wave.DirectSoundOut();

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(DateTime.Now);
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(TimerClock);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "—————————————————")
            {
                label5.Text = Convert.ToString(DateTime.Now);
                label6.Text = TimeCalc();
                if (label6.Text != "———————")
                {
                    listBox2.Items.Add(textBox1.Text + " " + DateTime.Today.ToShortDateString() + " " + label6.Text);
                }
            }
        }
        private string TimeCalc()
        {
            if ((label2.Text != "—————————————————") && (label5.Text != "—————————————————"))
            {
                return Convert.ToString(Convert.ToDateTime(label5.Text) - Convert.ToDateTime(label2.Text));
            }
            else return "———————";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string[] textArray = System.IO.File.ReadAllLines(filename);
            for (int i = 0; i<textArray.Length; i++)
            {
                listBox1.Items.Add(textArray[i]);
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            if ((label6.Text != "———————") && (saveFileDialog1.FileName != ""))
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox1.Items.Add(listBox2.Items[i]);
                    System.IO.File.AppendAllText(filename, "\n" + listBox2.Items[i].ToString());
                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        void TimerClock(object sender, EventArgs e)
        {
            if (label2.Text != "—————————————————")
            {

                TimeSpan calc = (DateTime.Now - Convert.ToDateTime(label2.Text));
                var calc1 = Math.Round(calc.TotalSeconds, 0); 
                TimeSpan halfhour = new TimeSpan(0, 30, 0);
                var half = halfhour.TotalSeconds;
                if ((calc1 % half) == 0)
                {
                    Clock = new NAudio.Wave.WaveFileReader("Beep.wav");
                    Play1 = new NAudio.Wave.DirectSoundOut();
                    Play1.Init(new NAudio.Wave.WaveChannel32(Clock));
                    Play1.Play();
                    
                }
            }
    }
        #region
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
      
        private void Label7_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void Button6_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "—————————————————";
            label6.Text = "———————";
        }
    }
}
