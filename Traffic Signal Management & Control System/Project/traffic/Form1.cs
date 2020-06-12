using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace traffic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        System.Windows.Forms.Timer count = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer sleep = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer y1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer y2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer y3 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer y4 = new System.Windows.Forms.Timer();

        private void button1_Click(object sender, EventArgs e)
        {
            Start.Visible = false;



            No1.Text = Car1.Text;
            No2.Text = Car2.Text;
            No3.Text = Car3.Text;
            No4.Text = Car4.Text;

            T1.BackColor = System.Drawing.Color.Transparent;
            T2.BackColor = System.Drawing.Color.Transparent;
            T3.BackColor = System.Drawing.Color.Transparent;
            T4.BackColor = System.Drawing.Color.Transparent;

            T1.Image = Properties.Resources.R1;
            T2.Image = Properties.Resources.R2;
            T3.Image = Properties.Resources.R3;
            T4.Image = Properties.Resources.R4;

            Set1.Visible = true;
            Set2.Visible = true;
            Set3.Visible = true;
            Set4.Visible = true;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            count.Tick += new EventHandler(count_Tick); // Everytime timer ticks, timer_Tick will be called
            count.Interval = (4000) * (5);              // Timer will tick evert second
            count.Enabled = true;                       // Enable the timer
            count.Start();

            sleep.Tick += new EventHandler(sleep_Tick); // Everytime timer ticks, timer_Tick will be called
            sleep.Interval = (2000) * (5);              // Timer will tick evert second
            sleep.Enabled = true;                       // Enable the timer

            y1.Tick += new EventHandler(y1_Tick); // Everytime timer ticks, timer_Tick will be called
            y1.Interval = (2000) * (5);              // Timer will tick evert second
            y1.Enabled = false;

            y2.Tick += new EventHandler(y2_Tick); // Everytime timer ticks, timer_Tick will be called
            y2.Interval = (2000) * (5);              // Timer will tick evert second
            y2.Enabled = false;
        
            y3.Tick += new EventHandler(y3_Tick); // Everytime timer ticks, timer_Tick will be called
            y3.Interval = (2000) * (5);              // Timer will tick evert second
            y3.Enabled = false;

            y4.Tick += new EventHandler(y4_Tick); // Everytime timer ticks, timer_Tick will be called
            y4.Interval = (2000) * (5);              // Timer will tick evert second
            y4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            No1.Text = Car1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            No2.Text = Car2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            No3.Text = Car3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            No4.Text = Car4.Text;
        }

        void sleep_Tick(object sender, EventArgs e)
        {
            sleep.Stop();
            sleep.Dispose();
        }

        void y1_Tick(object sender, EventArgs e)
        {
            T1.Image = Properties.Resources.Y1;
            y1.Stop();
            y1.Dispose();
        }


        void y2_Tick(object sender, EventArgs e)
        {
            T2.Image = Properties.Resources.Y2;
            y2.Stop();
            y2.Dispose();
        }


        void y3_Tick(object sender, EventArgs e)
        {
            T3.Image = Properties.Resources.Y3;
            y3.Stop();
            y3.Dispose();
        }


        void y4_Tick(object sender, EventArgs e)
        {
            T4.Image = Properties.Resources.Y4;
            y4.Stop();
            y4.Dispose();
        }


        void count_Tick(object sender, EventArgs e)
        {
            int[] path = new int[4];
            path[0] = Convert.ToInt32(No1.Text);
            path[1] = Convert.ToInt32(No2.Text);
            path[2] = Convert.ToInt32(No3.Text);
            path[3] = Convert.ToInt32(No4.Text);

            int max = path.Max();
            int min = path.Min();
            string max1 = "";
            string min1 = "";

            if (max == path[0])
            {
                max1 = "1";
            }
            else if (max == path[1])
            {
                max1 = "2";
            }
            else if (max == path[2])
            {
                max1 = "3";
            }
            else if (max == path[3])
            {
                max1 = "4";
            }


            if (min == path[0])
            {
                min1 = "1";
            }
            else if (min == path[1])
            {
                min1 = "2";
            }
            else if (min == path[2])
            {
                min1 = "3";
            }
            else if (min == path[3])
            {
                min1 = "4";
            }

            if (max1 == min1)
            {
                Get(max1);
            }
            else
            {
                int dif = max - min;
                Get(max1,dif);
            }

        }

        public void Get(string t,int i=5)
        {
            int dif = i;

            if (Emg1.Text == "Yes")
            {
                Emg1.Text = "No";
                t = "1";
                dif = 5;
            }
            else if (Emg2.Text == "Yes")
            {
                Emg2.Text = "No";
                t = "2";
                dif = 5;
            }
            else if (Emg3.Text == "Yes")
            {
                Emg3.Text = "No";
                t = "3";
                dif = 5;
            }
            else if (Emg4.Text == "Yes")
            {
                Emg4.Text = "No";
                t = "4";
                dif = 5;
            }

            if (t == "1")
            {
                Limit1.Text = dif.ToString();
                
                T1.Image = Properties.Resources.G1;
                T2.Image = Properties.Resources.R2;
                T3.Image = Properties.Resources.R3;
                T4.Image = Properties.Resources.R4;
                //Thread.Sleep(2000);
                sleep.Start();
                int co = (Convert.ToInt32(Car1.Text) - dif);
                S11.Text =(dif / 2).ToString() + " sec";

                S1.Visible = true;
                S2.Visible = false;
                S3.Visible = false;
                S4.Visible = false;
                S11.Visible = true;
                S22.Visible = false;
                S33.Visible = false;
                S44.Visible = false;
                sleep.Start();
                
                Car1.Text = co.ToString();
                No1.Text = Car1.Text;
                y1.Enabled = true;
                y1.Start();

            }
            else if (t == "2")
            {
                Limit1.Text = dif.ToString();

                T1.Image = Properties.Resources.R1;
                T2.Image = Properties.Resources.G2;
                T3.Image = Properties.Resources.R3;
                T4.Image = Properties.Resources.R4;
                //Thread.Sleep(2000);
                sleep.Start();
                int co = (Convert.ToInt32(Car2.Text) - dif);
                
                S22.Text = (dif / 2).ToString() + " sec";
                
                S1.Visible = false;
                S2.Visible = true;
                S3.Visible = false;
                S4.Visible = false;
                S11.Visible = false;
                S22.Visible = true;
                S33.Visible = false;
                S44.Visible = false;
                
                sleep.Start();
                Car2.Text = co.ToString();
                No2.Text = Car2.Text;
                y2.Enabled = true;
                y2.Start();
            }
            else if (t == "3")
            {
                Limit3.Text = dif.ToString();

                T1.Image = Properties.Resources.R1;
                T2.Image = Properties.Resources.R2;
                T3.Image = Properties.Resources.G3;
                T4.Image = Properties.Resources.R4;
                //Thread.Sleep(2000);
                sleep.Start();
                int co = (Convert.ToInt32(Car3.Text) - dif);
                S33.Text = (dif / 2).ToString() + " sec";
                
                S1.Visible = false;
                S2.Visible = false;
                S3.Visible = true;
                S4.Visible = false;
                S11.Visible = false;
                S22.Visible = false;
                S33.Visible = true;
                S44.Visible = false;
                
                sleep.Start();
                Car3.Text = co.ToString();
                No3.Text = Car3.Text;
                y3.Enabled = true;
                y3.Start();
            }
            else if (t == "4")
            {
                Limit4.Text = dif.ToString();

                T1.Image = Properties.Resources.R1;
                T2.Image = Properties.Resources.R2;
                T3.Image = Properties.Resources.R3;
                T4.Image = Properties.Resources.G4;
                //Thread.Sleep(2000);
                sleep.Start();
                int co = (Convert.ToInt32(Car4.Text) - dif);
                
                S44.Text =(dif / 2).ToString() + " sec";
                
                S1.Visible = false;
                S2.Visible = false;
                S3.Visible = false;
                S4.Visible = true;
                S11.Visible = false;
                S22.Visible = false;
                S33.Visible = false;
                S44.Visible = true;
                
                sleep.Start();
                Car4.Text = co.ToString();
                No4.Text = Car4.Text;
                y4.Enabled = true;
                y4.Start();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Emg1.Text = "Yes";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Emg2.Text = "Yes";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Emg3.Text = "Yes";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Emg4.Text = "Yes";
        }

    }
}
