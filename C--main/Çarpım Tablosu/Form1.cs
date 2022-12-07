using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;    //InputBox kullanabilmek için referans eklendikten sonra using satırından çağırmalıyız

namespace Odev
{
    public partial class Form1 : Form
    {
        int sayi1, sayi2;   //Değişkenleri farklı buttonlar içerisinde çağırabilmek için public altına tanımlamalarını yaptım
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = sayi1; i <= sayi2; i++)
            {
                for (int j = sayi1; j <= sayi2; j++)
                {
                    listBox1.Items.Add(i.ToString() + "*" + j.ToString() + "=" + (i * j).ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int y = sayi1;
            while (sayi1 <= sayi2)
            {
                int x = y;
                while (x <= sayi2)
                {
                    listBox1.Items.Add(sayi1.ToString() + "*" + x.ToString() + "=" + (x * sayi2).ToString());
                    x++;
                }
                sayi1++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int y = sayi1;
            do
            {
                int x = y;
                do
                {
                    listBox1.Items.Add(sayi1.ToString() + "*" + x.ToString() + "=" + (x * sayi2).ToString());
                    x++;
                } while (x <= sayi2);
                sayi1++;
            } while (sayi1 <= sayi2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayi1 = Convert.ToInt16(Interaction.InputBox("1. Sayıyı Giriniz")); //1. Sayıyı inputbox ile alma
            sayi2 = Convert.ToInt16(Interaction.InputBox("2. Sayıyı Giriniz")); //2. Sayıyı inputbox ile alma
        }
    }
}
