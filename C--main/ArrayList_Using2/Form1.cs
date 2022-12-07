using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;

namespace Hafta5
{
    public partial class Form1 : Form
    {
        ArrayList sayilar = new ArrayList(3);
        ArrayList deneme = new ArrayList();
        ArrayList ogrenci = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Random rnd = new Random();
            ArrayList liste = new ArrayList();
            int adet = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Kaç Adet Sayı Girilecek"));
            for (int i = 0; i<=adet - 1; i++)
            {
                liste.Add(rnd.Next(0, 300));
            }
            liste.Sort();
            liste.Reverse();
            foreach (int eleman in liste)
            {
                listBox1.Items.Add(eleman);
            }
            MessageBox.Show(liste.Count.ToString());
            MessageBox.Show(liste.Capacity.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sayilar.Add(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int eleman in sayilar)
            {
                listBox2.Items.Add(eleman.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sayilar.Insert(int.Parse(textBox3.Text), textBox4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deneme.Add(textBox5.Text);
            //Hafızaya eleman aktarmak için kullanılıyor
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deneme.Insert(Convert.ToInt32(textBox6.Text), textBox7.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = deneme.Capacity.ToString();
            // Dizinin o anki boyutunu göstermek için kullanılır
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ogrenci.RemoveAt(Convert.ToInt32(Interaction.InputBox("Kaçıncı Elemanı Silmek İstiyorsunuz")) - 1);
            listBox4.Items.Clear();
            foreach (object eleman in ogrenci)
            {
                listBox4.Items.Add(eleman);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ogrenci.Count.ToString() + " Eleman Mevcut");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = deneme.Count.ToString();
            // Dizinin içindeki eleman sayısını gösterir. Boyutunu göstermez
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (string i in deneme)
            {
                listBox3.Items.Add(i);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deneme.Remove(textBox5.Text); // Belirli elemanı silmek için kullanılır.
        }

        private void button11_Click(object sender, EventArgs e)
        {
            deneme.RemoveAt(int.Parse(textBox5.Text)); // İndis numarası girilen elemanı silmek için kullanılır
        }

        private void button12_Click(object sender, EventArgs e)
        {
            deneme.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int kac_tane = Convert.ToInt16(Interaction.InputBox("Kaç Öğrenci Girilecek"));
            for (int i = 1; i <= kac_tane; i++)
            {
                ogrenci.Add(Convert.ToDouble(Interaction.InputBox("TC Giriniz")));
                ogrenci.Add(Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Okul No Giriniz")));
                ogrenci.Add(Interaction.InputBox("Ad Giriniz"));
                ogrenci.Add(Interaction.InputBox("Soyad Giriniz"));
                ogrenci.Add(Interaction.InputBox("Doğum Yeri Giriniz"));
                ogrenci.Add(Interaction.InputBox("Anne Adı Giriniz"));
                ogrenci.Add(Interaction.InputBox("Baba Adı Giriniz"));
                ogrenci.Add(Interaction.InputBox("Cinsiyet Giriniz"));
            }
            foreach (object eleman in ogrenci)
            {
                listBox4.Items.Add(eleman);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
