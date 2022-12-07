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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Hashtable ogr = new Hashtable();
        public void listele()
        {
            listView1.Items.Clear();
            ListViewItem item = new ListViewItem();
            ICollection col = ogr.Keys;
            foreach (object veri in col)
            {
                item = listView1.Items.Add(veri.ToString());
                item.SubItems.Add(ogr[veri].ToString());
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("TC", 120);
            listView1.Columns.Add("Ad - Soyad", 120);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox1.MaxLength = 11;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox2.MaxLength = 20;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox4.MaxLength = 11;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox5.MaxLength = 11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 11)
            {
                MessageBox.Show("Lütfen 11 Haneli TC Giriniz");
                textBox1.Focus();
            }
            if (textBox1.Text.Length == 11 && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Adınızı Giriniz");
                textBox2.Focus();
            }
            if (textBox1.Text.Length == 11 && textBox2.Text != "")
            {
                try
                {
                    ogr.Add(textBox1.Text, textBox2.Text);
                    listele();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kayıtlı Bir TC Numarası Girdiniz");
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 11)
            {
                Boolean var = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Text == textBox4.Text)
                        var = true;
                }
                if (var == true)
                    MessageBox.Show(textBox4.Text + " TC Numaralı Kişi : " + ogr[textBox4.Text].ToString());
                else
                    MessageBox.Show("Girmiş Olduğunuz TC Sistemde Kayıtlı Değil");
            }
            else
                MessageBox.Show("Lütfen Bulmak İstediğiniz Kişinin 11 Haneli TC Numarasını Giriniz");
            textBox4.Clear();
            textBox4.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 11)
            {
                Boolean var = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Text == textBox5.Text)
                        var = true;
                }
                if (var == true)
                {
                    MessageBox.Show(ogr[textBox5.Text] + " Adlı Kişi Silindi");
                    ogr.Remove(textBox5.Text);
                    listele();
                }
                else
                    MessageBox.Show("Girmiş Olduğunuz TC Sistemde Kayıtlı Değil");
            }
            else
                MessageBox.Show("Lütfen 11 Haneli TC Numarasını Giriniz");
            textBox5.Clear();
            textBox5.Focus();
        }
    }
}
