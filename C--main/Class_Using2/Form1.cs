using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; //InputBox için ekledim

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deneme nesne = new deneme();
            MessageBox.Show(nesne.kare(Convert.ToInt32(textBox1.Text)).ToString());
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deneme nesne = new deneme();
            MessageBox.Show(nesne.pisayisi(Convert.ToInt32(textBox2.Text)).ToString());
            textBox2.Clear();
            textBox2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deneme nesne = new deneme();
            MessageBox.Show(nesne.ortalama(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)).ToString());
            textBox3.Clear();
            textBox4.Clear();
            textBox3.Focus();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            deneme nesne = new deneme();
            MessageBox.Show("Alan : " + nesne.ucgen(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)).ToString());
            textBox5.Clear();
            textBox6.Clear();
            textBox5.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sayi1, sayi2;
            sayi1 = Convert.ToInt32(Interaction.InputBox("1. Kenarı Giriniz"));
            sayi2 = Convert.ToInt32(Interaction.InputBox("2. Kenarı Giriniz"));
            deneme nesne = new deneme();
            MessageBox.Show("Alan : " + nesne.kare(sayi1, sayi2).ToString());
        }
    }
}
