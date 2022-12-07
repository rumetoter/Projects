using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int s1, s2;

        private void button1_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToInt16(Interaction.InputBox("Başlangıç değeri giriniz"));
            s2 = Convert.ToInt16(Interaction.InputBox("Bitiş değeri giriniz"));
            listBox1.Items.Clear();
            for (int i = s1; i <= s2; i++)
            {
                listBox1.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToInt16(Interaction.InputBox("Başlangıç değeri giriniz"));
            s2 = Convert.ToInt16(Interaction.InputBox("Bitiş değeri giriniz"));
            listBox1.Items.Clear();
            while (s1 <= s2)
            {
                listBox1.Items.Add(s1.ToString());
                s1++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x;
            listBox1.Items.Clear();
            for (x=0; x<=8; x++)
            {
                if (x!=4)
                {
                    // MessageBox.Show("X = " + x.ToString());
                    listBox1.Items.Add(x.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 1;
            while (count <= 3)
            {
                MessageBox.Show("Sayı Değeri : " + count.ToString());
                label1.Text = ("Sayı Değeri : ") + count.ToString();
                count++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cumle = textBox1.Text;
            label2.Text = "";
            for (int i=0; i<=10; i++)
            {
                label2.Text += i.ToString() + " . " + cumle + "\n";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox2.Text.Substring(0, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string kelime = "ismail";
            listBox2.Items.Clear();
            for (int i = 0; i < kelime.Length; i++)
            {
                listBox2.Items.Add(kelime.Substring(0, i + 1));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string kelime = "ismail";
            listBox2.Items.Clear();
            int i = 0;
            while (i < kelime.Length)
            {
                listBox2.Items.Add(kelime.Substring(0, i + 1));
                i++;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string kelime = "ismail";
            listBox2.Items.Clear();
            int i = 0;
            do
            {
                listBox2.Items.Add(kelime.Substring(0, i + 1));
                i++;
            } while (i < kelime.Length);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sayi = "12345";
            listBox2.Items.Clear();
            for (int i = sayi.Length; i > 0;i--)
            {
                listBox2.Items.Add(sayi.Substring(0, i));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sayi = "12345";
            listBox2.Items.Clear();
            int i = sayi.Length;
            while (i > 0)
            {
                listBox2.Items.Add(sayi.Substring(0, i));
                i--;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
