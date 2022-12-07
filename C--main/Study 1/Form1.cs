using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int sayi, sayi1, sayi2;
        double s1, s2; // virgüllü sayı gelebileceğini düşündüğüm yerler için double kullanıyorum
        string ad, soyad;

        private void button4_Click(object sender, EventArgs e)
        {
            sayi1 = Convert.ToInt16(textBox8.Text);
            sayi2 = Convert.ToInt16(textBox9.Text);
            textBox5.Text = (sayi1 - sayi2).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sayi1 = Convert.ToInt16(textBox8.Text);
            sayi2 = Convert.ToInt16(textBox9.Text);
            textBox6.Text = (sayi1 * sayi2).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToDouble(textBox8.Text);
            s2 = Convert.ToDouble(textBox9.Text);
            textBox7.Text = (s1 / s2).ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text, soyad = textBox2.Text;
            textBox3.Text = textBox1.Text + " " + textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sayi1 = Convert.ToInt16(textBox8.Text);
            sayi2 = Convert.ToInt16(textBox9.Text);
            textBox4.Text = (sayi1 + sayi2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayi = 72;
            ad = "Doğukan";
            soyad = "TEKİN";
            MessageBox.Show(ad + " " + soyad + " " + sayi.ToString());            
        }
    }
}
