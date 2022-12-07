using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //Thread kullanmak için yazılmalıdır

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int sayi;
        Random rnd = new Random();
        Thread t1, t2;
        public void metot1()
        {
            while (true)
            {
                sayi += 1;
                progressBar1.Value = sayi;
                Thread.Sleep(1000);
            }
        }
        public void metot2()
        {
            while (true)
            {
                listBox1.Items.Add(rnd.Next(0, 401).ToString());
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            t1 = new Thread(new ThreadStart(metot1));
            t2 = new Thread(new ThreadStart(metot2));
            t1.Start();
            t2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Abort();
            t2.Abort();
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
