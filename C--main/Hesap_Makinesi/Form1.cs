using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {
        double sayi1, sonuc;
        int islem;

        private void button1_Click(object sender, EventArgs e)
        {
            islem = 1;
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen Sayı Giriniz");
            else
            {
                sayi1 = Convert.ToDouble(textBox1.Text);
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Sayı Giriniz");
                textBox1.Focus();
            }
            else
            {
                if (islem == 1)
                {
                    sonuc = sayi1 + Convert.ToDouble(textBox1.Text);
                    textBox1.Text = sonuc.ToString();
                }

                else if (islem == 2)
                {
                    sonuc = sayi1 - Convert.ToDouble(textBox1.Text);
                    textBox1.Text = sonuc.ToString();
                }

                else if (islem == 3)
                {
                    sonuc = sayi1 * Convert.ToDouble(textBox1.Text);
                    textBox1.Text = sonuc.ToString();
                }

                else if (islem == 4)
                {
                    if (textBox1.Text == "0")
                    {
                        MessageBox.Show("0'a Bölünme Yapılamaz");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        sonuc = sayi1 / Convert.ToDouble(textBox1.Text);
                        textBox1.Text = sonuc.ToString();
                    }
                }
                else
                    textBox1.Focus();
            }            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem = 2;
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen Sayı Giriniz");
            else
            {
                sayi1 = Convert.ToDouble(textBox1.Text);
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            islem = 3;
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen Sayı Giriniz");
            else
            {
                sayi1 = Convert.ToDouble(textBox1.Text);
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            islem = 4;
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen Sayı Giriniz");
            else
            {
                sayi1 = Convert.ToDouble(textBox1.Text);
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                    e.Handled = true;
        }
    }
}
