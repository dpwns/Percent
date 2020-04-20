using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int cnt, cnt2, cnt3;
        public int C, need, c;
        public Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        void Show()
        {
            textBox4.Text = ((double)cnt3 / (double)c).ToString();
            button1.Enabled = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            cnt2 = 0;
            cnt3 = 0;
            c = Int32.Parse(textBox2.Text.ToString());
            C = Int32.Parse(textBox3.Text.ToString());
            need = Int32.Parse(textBox5.Text.ToString());
            int max = Int32.Parse(textBox3.Text.ToString());
            progressBar1.Maximum = c;
            progressBar1.Value = 0;
            for (cnt = 0; cnt < c; cnt++)
            {
                Calculate();
                //new Thread(new ThreadStart(Calculate)).Start();
            }
        }
        void Calculate()
        {
            double temp, temp2;
            int temp3, temp4 = 0;
            temp2 = (double)(1000f / (double)C);
            temp2 /= 1000f;
            int check = 0;
            int[] Counter = new int[C];
            for (int i = 0; i < C; i++) Counter[i] = 0;
            while (check < C)
            {
                temp4++;
                check = 0;
                temp3 = 0;
                temp = rand.NextDouble();
                temp -= temp2;
                while (temp > 0)
                {
                    temp -= temp2;
                    temp3++;
                }
                Counter[temp3]++;
                for (int i = 0; i < C; i++)
                {
                    if (Counter[i] >= need) check++;
                }
            }
            cnt2++;
            cnt3 += temp4;
            progressBar1.Value++;
            if (cnt2 >= c)
            {
                Show();
            }
        }
    }
}
