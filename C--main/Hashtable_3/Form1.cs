using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; //Hashtable kullanabilmek için yazılmalıdır

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Hashtable ogrenciler = new Hashtable();
        Hashtable bilgiler = new Hashtable();
        public void listele2()
        {
            listView2.Items.Clear();
            ListViewItem item2 = new ListViewItem();
            ICollection gir = bilgiler.Keys;
            foreach (object veri in gir)
            {
                item2 = listView2.Items.Add(veri.ToString());
                item2.SubItems.Add(bilgiler[veri].ToString());
            }
        }
        public void listele()
        {
            ListViewItem item = new ListViewItem();
            ICollection collection = ogrenciler.Keys;
            listView1.Clear();
            listView1.Columns.Add("Okul No", 120);
            listView1.Columns.Add("Adı ve Soyadı", 120);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            foreach (object eleman in collection)
            {
                item = listView1.Items.Add(eleman.ToString());         //Key Değeri
                item.SubItems.Add(ogrenciler[eleman].ToString());     //Value Değeri
            }
            listView1.Sorting = SortOrder.Ascending; //A'dan Z'ye sıralamak için kullanıldı
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ogrenciler.Add("2370", "Doğukan Tekin");
            ogrenciler.Add("2222", "Yunus Çataklı");
            ogrenciler.Add("2246", "Dora Tekin");
            ogrenciler.Add("2652", "Anıl Maral");
            listele();

            bilgiler.Add("24547123008", "Doğukan Tekin");
            bilgiler.Add("23451234512", "Emre Seven");
            bilgiler.Add("52363214141", "Anıl Maral");
            bilgiler.Add("56236234142", "Yunus Çataklı");
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("TC", 120);
            listView2.Columns.Add("Ad - Soyad", 120);
            listele2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrenciler.Add(textBox1.Text, textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ogrenciler[textBox3.Text].ToString());
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenciler.Remove(textBox4.Text);
            listele();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox5.MaxLength = 11;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox8.MaxLength = 11;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int sayac = 0;
                if (textBox5.Text.Length != 11)
                {
                    MessageBox.Show("Lütfen 11 Haneli TC Numaranızı Giriniz");
                    textBox5.Focus();
                    sayac += 1;
                }
                if (textBox6.Text == "" && textBox5.Text.Length == 11)
                {
                    MessageBox.Show("Adınızı Giriniz");
                    textBox6.Focus();
                    sayac += 1;
                }
                if (textBox7.Text == "" && textBox5.Text.Length == 11 && textBox6.Text != "")
                {
                    MessageBox.Show("Soyadınızı Giriniz");
                    textBox7.Focus();
                    sayac += 1;
                }
                if (sayac == 0)
                {
                    bilgiler.Add(textBox5.Text, (textBox6.Text + " " + textBox7.Text));
                    listele2();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox5.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıtlı Olan Bir TC Girdiniz");
                textBox5.Clear();
                textBox5.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length != 11)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz 11 Haneli TC Numarasını Giriniz");
                textBox8.Focus();
            }
            else
            {
                Boolean ayni = false;
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Text == textBox8.Text)
                        ayni = true;
                }
                if (ayni == true)
                {
                    bilgiler.Remove(textBox8.Text);
                    listele2();
                    MessageBox.Show(textBox8.Text + " TC Numaralı Kişi Silindi");
                    textBox8.Clear();
                }
                else
                {
                    MessageBox.Show("Girmiş Olduğunuz TC Numarası Mevcut Değil");
                    textBox8.Clear();
                    textBox8.Focus();
                }
            }
        }
    }
}




