using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        String ad, soyad, dogumyeri, anneadi, babaadi, cinsiyet, tc, okulno;

        private void button4_Click(object sender, EventArgs e)
        {
            ListViewItem deneme = new ListViewItem("24547123008");
            deneme.SubItems.Add("2020707046");
            deneme.SubItems.Add("Doğukan");
            deneme.SubItems.Add("Tekin");
            deneme.SubItems.Add("Ordu");
            deneme.SubItems.Add("Özlem");
            deneme.SubItems.Add("Erhan");
            deneme.SubItems.Add("Erkek");
            listView1.Items.Add(deneme);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewItem ogrenci = new ListViewItem(Interaction.InputBox(""));
            if (checkBox1.Checked == true)
            {
                cinsiyet = checkBox1.Text;
            }
            else
            {
                cinsiyet = checkBox2.Text;
            }
            String[] ogrencibilgi = { tc, okulno, ad, soyad, dogumyeri, anneadi, babaadi, cinsiyet };
            listView1.Items.Add(new ListViewItem(ogrencibilgi));
            MessageBox.Show("Kayıt Başarılı");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
            label11.Text = (Convert.ToInt32(label11.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ArrayList ogrenci = new ArrayList();
            //int kayit_sayisi = Convert.ToInt32(Interaction.InputBox("Kayıt Sayısını Giriniz"));
            //for (int i = 1; i <= kayit_sayisi; i++)
            //{
            //    String[] ogrenciler = new string[8];
            //    ogrenciler[0] = Interaction.InputBox("TC Giriniz");
            //    ogrenciler[1] = Interaction.InputBox("Okul No Giriniz");
            //    ogrenciler[2] = Interaction.InputBox("Ad Giriniz");
            //    ogrenciler[3] = Interaction.InputBox("Soyad Giriniz");
            //    ogrenciler[4] = Interaction.InputBox("Doğum Yeri Giriniz");
            //    ogrenciler[5] = Interaction.InputBox("Anne Adı Giriniz");
            //    ogrenciler[6] = Interaction.InputBox("Baba Adı Giriniz");
            //    ogrenciler[7] = Interaction.InputBox("Cinsiyet Giriniz");
            //    ogrenci.Add(ogrenciler);
            //}
            //foreach (string eleman in ogrenci)
            //{
            //    listView1.Items.Add(new ListViewItem(eleman));
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilisatirlar = listView1.SelectedItems.Count;
            foreach (ListViewItem satir in listView1.SelectedItems)
            {
                satir.Remove();
                label11.Text = (Convert.ToInt32(label11.Text) - 1).ToString();
            }
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            checkBox1.Checked = true;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("TC Numarası", 150);
            listView1.Columns.Add("Okul Numarası", 150);
            listView1.Columns.Add("Öğrenci Ad", 150);
            listView1.Columns.Add("Öğrenci Soyad", 150);
            listView1.Columns.Add("Doğum Yeri", 150);
            listView1.Columns.Add("Anne Adı", 150);
            listView1.Columns.Add("Baba Adı", 150);
            listView1.Columns.Add("Cinsiyet", 150);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tc = textBox1.Text;
            okulno = textBox2.Text;
            ad = textBox3.Text;
            soyad = textBox4.Text;
            dogumyeri = textBox5.Text;
            anneadi = textBox6.Text;
            babaadi = textBox7.Text;
            if (checkBox1.Checked == true)
            {
                cinsiyet = checkBox1.Text;
            }
            else
            {
                cinsiyet = checkBox2.Text;
            }
            String[] ogrencibilgi = { tc, okulno, ad, soyad, dogumyeri, anneadi, babaadi, cinsiyet };
            listView1.Items.Add(new ListViewItem(ogrencibilgi));
            MessageBox.Show("Kayıt Başarılı");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
            label11.Text = (Convert.ToInt32(label11.Text) + 1).ToString();
        }
    }
}
