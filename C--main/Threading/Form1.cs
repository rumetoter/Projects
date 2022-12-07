using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //Thread kullanabilmek için eklenmelidir

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Thread islem1, islem2, islem3, islem4, islem5, islem6; //Kullanılacak metot kadar thread tanımlanmalıdır
        int i = 100;
        int j = 100;
        int numara = 2020707001;
        void noyaz()
        {
            while (true)
            {
                listBox6.Items.Add(numara);
                numara += 1;
                Thread.Sleep(1000);
            }
        }
        void bolumata()
        {
            while (true)
            {
                string[] bolumler = { "Bilgisayar", "PC", "Yazılım", "Mimarlık", "İnşaat", "Elektrik", "Makine", "Sistem" };
                Random rnd = new Random();
                listBox5.Items.Add(bolumler[rnd.Next(0, bolumler.Length - 1)]);
                Thread.Sleep(1000);
            }
        }
        void deuyaz()
        {
            while (true)
            {
                listBox4.Items.Add("DEU IMYO");
                Thread.Sleep(1000);
            }
        }
        void metot1()
        {
            while (true)
            {
                listBox1.Items.Add(i);
                i += 1;
                Thread.Sleep(1000);
            }
        }
        void metot2()
        {
            while (true)
            {
                listBox2.Items.Add(15 * i++);
                Thread.Sleep(1000);
            }
        }
        void metot3()
        {
            while (true)
            {
                listBox3.Items.Add(DateTime.Now.ToLongTimeString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            islem4.Abort();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            islem5.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            islem6.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem1.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem2.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            islem3.Abort();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false; //Thread'ın çalışabilmesi için bu mutlaka eklenmelidir
            islem1 = new Thread(new ThreadStart(metot1));
            islem2 = new Thread(new ThreadStart(metot2));
            islem3 = new Thread(new ThreadStart(metot3));
            islem4 = new Thread(new ThreadStart(noyaz));
            islem5 = new Thread(new ThreadStart(bolumata));
            islem6 = new Thread(new ThreadStart(deuyaz));
            islem1.Start();
            islem2.Start();
            islem3.Start();
            islem4.Start();
            islem5.Start();
            islem6.Start();
        }
    }
}
