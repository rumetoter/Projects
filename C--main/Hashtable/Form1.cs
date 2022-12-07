using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;

namespace Odev
{
    public partial class Form1 : Form
    {
        string ad, tc, soyad;
        Hashtable ogrenci = new Hashtable();
        public void listele()
        {
            ListViewItem item = new ListViewItem();
            ICollection kod = ogrenci.Keys;
            listView1.Clear();
            listView1.Columns.Add("Okul No", 120);
            listView1.Columns.Add("Ad ve Soyad", 120);
            listView1.View = View.Details;
            listView1.GridLines = true;
            foreach (String eleman in kod)
            {
                item = listView1.Items.Add(eleman);
                item.SubItems.Add(ogrenci[eleman].ToString());
            }
            listView1.Sorting = SortOrder.Ascending;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox1.MaxLength = 11;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox4.MaxLength = 11;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tc = "";
            if (textBox4.Text.Length == 11)
            {
                tc = textBox4.Text;
                ListBox kontrol = new ListBox();
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    kontrol.Items.Add(listView1.Items[i].Text);
                }
                if (kontrol.Items.Contains(tc) == true)
                {
                    ogrenci.Remove(tc);
                    listele();
                    textBox4.Clear();
                    MessageBox.Show("Silme İşlemi Başarılı");
                }
                else
                {
                    MessageBox.Show("Kayıtlı Olmayan Bir TC Kimlik Numarası Girdiniz");
                    textBox4.Clear();
                    textBox4.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen 11 Haneli TC Kimlik Numarası Giriniz");
                textBox4.Clear();
                textBox4.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tc = "";
            ad = "";
            soyad = "";
            string adsoyad = "";
            if (textBox1.Text.Length == 11)
            {
                tc = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Lütfen 11 Haneli TC Kimlik Numaranızı Giriniz");
                textBox1.Focus();
            }
            if (tc != "")
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen Adınızı Giriniz");
                    textBox2.Focus();
                }
                else
                {
                    ad = textBox2.Text;
                }
            }
            if (ad != "")
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen Soyadınızı Giriniz");
                    textBox3.Focus();
                }
                else
                {
                    soyad = textBox3.Text;
                }
            }
            if (tc != "" && ad != "" && soyad != "")
            {
                ListBox kontrol = new ListBox();
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    kontrol.Items.Add(listView1.Items[i].Text);
                }
                if (kontrol.Items.Contains(tc) == false)
                {
                    adsoyad = ad + " " + soyad;
                    ogrenci.Add(tc, adsoyad);
                    listele();
                    MessageBox.Show("Kayıt İşlemi Başarılı");
                }
                else
                {
                    MessageBox.Show("Daha Önce Girilmiş Bir TC Kimlik Numarası Girdiniz");
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            ogrenci.Add("14578945871", "Ahmet İlhami Kral");
            ogrenci.Add("24587984268", "Mehmet Ali Ateşli");
            ogrenci.Add("37845625819", "İsmail Düşmez");
            ogrenci.Add("44584678518", "Sumru Bayrak");
            ogrenci.Add("50214205489", "Güngör Özer");
            listele();
        }
    }
}
