using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Random_name_gen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Divs");
            comboBox1.Items.Add("5ths 1");
            comboBox1.Items.Add("5ths 2");
            comboBox1.Items.Add("L6 1");
            comboBox1.Items.Add("L6 2");
            comboBox1.Items.Add("U6");
            label1.Hide();
            label3.Hide();

        }
        public string path;
        public Random rnd = new Random();
        public int gen;
        public bool next = true;
        public int lineCount;
        public int i = 0;
        public string name;
        public string first;
        public string second;
        public int ticks1 = 0;
        public int ticks2 = 0;
        public int add;
        public bool current = true;
        private void generate()
        {
            timer1.Start();
            switch (comboBox1.Text)
            {
                case "Divs":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\10-3-Co1-(D).txt";
                    break;
                case "5ths 1":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\11-3-Co1-(5).txt";
                    break;
                case "5ths 2":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\11-4-Co1-(5).txt";
                    break;
                case "L6 1":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\12-1-Co1-(L6).txt";
                    break;
                case "L6 2":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\12-2-Co1-(L6).txt";
                    break;
                case "U6":
                    path = @"D:\Users\Imran Zamin Ali\Documents\imran\A level\computing\timetables\13-1-Co1-(U6).txt";
                    break;
                default:
                    next = false;
                    break;

            }
            if (next)
            {
                lineCount = File.ReadLines(path).Count();
                gen = rnd.Next(3, lineCount - 2);
                var data = File.ReadLines(path).Skip(gen).Take(1).First();
                label3.Text = data.Split('\t')[1] + " " + data.Split('\t')[0];
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ticks1 = 0;
            ticks2 = 0;
            add = 20;
            timer1.Interval = 40;
            timer1.Start();
            label1.Show();
            label3.Show();
            comboBox1.Hide();
            button1.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ticks1 = 0;
            ticks2 = 0;
            add = 20;
            timer1.Interval = 40;
            timer1.Start();
            label1.Show();
            label3.Show();
            comboBox1.Hide();
            button1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks1++;
            timer1.Interval += add;
            add = add + add*1/8;
            generate();
            if (ticks1 == 18)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ticks2++;
            if (ticks2 <= 6)
            {
                if (current)
                {
                    label3.Hide();
                }
                else
                {
                    label3.Show();
                }
                current = !current;
            }
            else
            {
                timer2.Stop();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            comboBox1.Show();
            button1.Show();
            label1.Hide();
            label3.Hide();
        }
    }
}
