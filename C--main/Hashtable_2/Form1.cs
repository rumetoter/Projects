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
using System.Collections;

namespace CSharp_Hafta6
{
    public partial class Form1 : Form
    {
        string ad, tc;
        Hashtable ogrenci = new Hashtable();
        Hashtable ogrenci1 = new Hashtable();
        public void listele()
        {
            ListViewItem item = new ListViewItem();
            ICollection kod = ogrenci.Keys;
            listView1.Clear();
            listView1.Columns.Add("Okul No", 120);
            listView1.Columns.Add("Adı ve Soyadı", 120);
            listView1.View = View.Details;
            listView1.GridLines = true;
            foreach (String eleman in kod)
            {
                item = listView1.Items.Add(eleman);
                item.SubItems.Add(ogrenci[eleman].ToString());
            }
            listView1.Sorting = SortOrder.Ascending;
        }
        public void listele2()
        {
            ListViewItem item = new ListViewItem();
            ICollection kod = ogrenci1.Keys;
            listView2.Clear();
            listView2.Columns.Add("TC No", 120);
            listView2.Columns.Add("Adı ve Soyadı", 120);
            listView2.View = View.Details;
            listView2.GridLines = true;
            foreach (String eleman in kod)
            {
                item = listView2.Items.Add(eleman);
                item.SubItems.Add(ogrenci1[eleman].ToString());
            }
            listView1.Sorting = SortOrder.Ascending;
        }
        static bool sayimi(string a)
        {
            bool sonuc = true;
            for (int i=0; i<a.Length; i++)
            {
                if (!char.IsDigit(a[i]))
                    sonuc = false;
            }
            return sonuc;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ogrenci.Add("1", "Ahmet İlhami Kral");
            ogrenci.Add("2", "Mehmet Ali Ateşli");
            ogrenci.Add("3", "İsmail Düşmez");
            ogrenci.Add("4", "Sumru Bayrak");
            ogrenci.Add("5", "Güngör Özer");
            ogrenci1.Add("1", "Ahmet İlhami Kral");
            ogrenci1.Add("2", "Mehmet Ali Ateşli");
            ogrenci1.Add("3", "İsmail Düşmez");
            ogrenci1.Add("4", "Sumru Bayrak");
            ogrenci1.Add("5", "Güngör Özer");
            listele();
            listele2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenci.Add(textBox1.Text, textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
            listele();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string anahtar = textBox3.Text;
            textBox4.Text = ogrenci[anahtar].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenci.Remove(textBox3.Text);
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Boolean bos = false;
            do
            {
                tc = Interaction.InputBox("Kaçıncı Elemanı Silmek İstiyorsunuz ?");
                if (tc == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız");
                }
                else if (sayimi(tc))
                {
                    bos = true;
                    ogrenci1.Remove(tc);
                    listele2();
                    MessageBox.Show("Silme İşlemi Başarılı");
                }
                else
                {
                    MessageBox.Show("Lütfen Sayısal Değer Giriniz");
                }
            } while (bos == false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boolean bos = false;
            do
            {
                tc = Interaction.InputBox("TC Numaranızı Giriniz");
                if (tc == "")
                    MessageBox.Show("Lütfen Boş Bırakmayınız");
                else
                    bos = true;
            } while (bos == false);
            bos = false;
            do
            {
                ad = Interaction.InputBox("Ad Soyad Giriniz");
                if (ad == "")
                    MessageBox.Show("Lütfen Boş Bırakmayınız");
                else
                    bos = true;
            } while (bos == false);
            ogrenci1.Add(tc, ad);
            listele2();
        }
    }
}
