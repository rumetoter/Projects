using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VizeOncesiSon
{
    public partial class Form1 : Form
    {
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");
        OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\personel.accdb");
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        BindingSource bs4 = new BindingSource();
        OleDbDataAdapter da1;
        OleDbDataAdapter da2;
        OleDbDataAdapter da3;
        OleDbDataAdapter da4;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        void listele_ogrenci()
        {
            da1 = new OleDbDataAdapter("Select * from ogrenci", con1);
            con1.Open();
            da1.Fill(dt1);
            bs1.DataSource = dt1;
            dataGridView1.DataSource = bs1;
            con1.Close();
        }
        void listele_personel()
        {
            con2.Open();
            da2 = new OleDbDataAdapter("Select * from personel", con2);
            da3 = new OleDbDataAdapter("Select * from bolum", con2);
            da4 = new OleDbDataAdapter("Select * from maas", con2);
            da2.Fill(dt2);
            da3.Fill(dt3);
            da4.Fill(dt4);
            bs2.DataSource = dt2;
            bs3.DataSource = dt3;
            bs4.DataSource = dt4;
            dataGridView2.DataSource = bs2;
            dataGridView3.DataSource = bs3;
            dataGridView4.DataSource = bs4;
            con2.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox15.Visible = false;
            textBox16.Visible = false;
            listele_ogrenci();
            listele_personel();
            textBox1.DataBindings.Add("Text", bs1, "Numara");
            textBox2.DataBindings.Add("Text", bs1, "Ad");
            textBox3.DataBindings.Add("Text", bs1, "Soyad");
            textBox4.DataBindings.Add("Text", bs1, "Dogum_Tarihi");
            textBox5.DataBindings.Add("Text", bs1, "Adres");
            textBox6.DataBindings.Add("Text", bs1, "Vize");
            textBox7.DataBindings.Add("Text", bs1, "Final");
            textBox9.DataBindings.Add("Text", bs2, "Numara");
            textBox10.DataBindings.Add("Text", bs2, "Ad");
            textBox11.DataBindings.Add("Text", bs2, "Soyad");
            textBox12.DataBindings.Add("Text", bs2, "Baslangic_Tarihi");
            textBox13.DataBindings.Add("Text", bs3, "Bölüm");
            textBox14.DataBindings.Add("Text", bs4, "Maaş");
            textBox15.DataBindings.Add("Text", bs3, "Numara");
            textBox16.DataBindings.Add("Text", bs4, "Numara");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs1.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs1.MoveNext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs1.MovePrevious();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs1.MoveLast();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs1.Position = bs1.Find("Ad", textBox8.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            bs1.AddNew();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs1.CancelEdit();
            bs1.MoveFirst();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs1.EndEdit();
            bs1.AddNew();
            textBox1.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bs1.RemoveCurrent();
            bs1.MoveFirst();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OleDbCommand ekle = new OleDbCommand("Insert INTO ogrenci (Numara,Ad,Soyad,Dogum_Tarihi,Adres,Vize,Final) VALUES (@Numara,@Ad,@Soyad,@Dogum_Tarihi,@Adres,@Vize,@Final)", con1);
            con1.Open();
            ekle.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox1.Text));
            ekle.Parameters.AddWithValue("@Ad", textBox2.Text);
            ekle.Parameters.AddWithValue("@Soyad", textBox3.Text);
            ekle.Parameters.AddWithValue("@Dogum_Tarihi", Convert.ToDateTime(textBox4.Text));
            ekle.Parameters.AddWithValue("@Adres", textBox5.Text);
            ekle.Parameters.AddWithValue("@Vize", Convert.ToInt32(textBox6.Text));
            ekle.Parameters.AddWithValue("@Final", Convert.ToInt32(textBox7.Text));
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            con1.Close();
            listele_ogrenci();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OleDbCommand sil = new OleDbCommand("Delete FROM ogrenci where Numara=@Numara", con1);
            con1.Open();
            sil.Parameters.AddWithValue("@Numara", dataGridView1.CurrentRow.Cells[0].Value);
            sil.ExecuteNonQuery();
            con1.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
            bs1.RemoveCurrent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OleDbCommand guncelle = new OleDbCommand("Update ogrenci SET Ad=@Ad, Soyad=@Soyad, Dogum_Tarihi=@Dogum_Tarihi, Adres=@Adres, Vize=@Vize, Final=@Final where Numara=@Numara", con1);
            con1.Open();
            guncelle.Parameters.AddWithValue("Ad", textBox2.Text);
            guncelle.Parameters.AddWithValue("Soyad", textBox3.Text);
            guncelle.Parameters.AddWithValue("Dogum_Tarihi", Convert.ToDateTime(textBox4.Text));
            guncelle.Parameters.AddWithValue("Adres", textBox5.Text);
            guncelle.Parameters.AddWithValue("Vize", Convert.ToInt32(textBox6.Text));
            guncelle.Parameters.AddWithValue("Final", Convert.ToInt32(textBox7.Text));
            guncelle.Parameters.AddWithValue("Numara", Convert.ToInt32(textBox1.Text));
            guncelle.ExecuteNonQuery();
            con1.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            bs2.MoveFirst();
            bs3.MoveFirst();
            bs4.MoveFirst();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bs2.MoveNext();
            bs3.MoveNext();
            bs4.MoveNext();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bs2.MovePrevious();
            bs3.MovePrevious();
            bs4.MovePrevious();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bs2.MoveLast();
            bs3.MoveLast();
            bs4.MoveLast();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox9.Focus();
            bs2.AddNew();
            bs3.AddNew();
            bs4.AddNew();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox9.Focus();
            bs2.CancelEdit();
            bs3.CancelEdit();
            bs4.CancelEdit();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox9.Focus();
            bs2.EndEdit();
            bs3.EndEdit();
            bs4.EndEdit();
            bs2.AddNew();
            bs3.AddNew();
            bs4.AddNew();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = textBox9.Text;
            textBox16.Text = textBox9.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            con2.Open();
            OleDbCommand ekle1 = new OleDbCommand("Insert INTO personel (Numara,Ad,Soyad,Baslangic_Tarihi) VALUES (@Numara,@Ad,@Soyad,@Baslangic_Tarihi)", con2);
            OleDbCommand ekle2 = new OleDbCommand("Insert INTO bolum (Numara,Bölüm) VALUES (@Numara,@Bölüm)", con2);
            OleDbCommand ekle3 = new OleDbCommand("Insert INTO maas (Numara,Maaş) VALUES (@Numara,@Maaş)", con2);
            ekle1.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox9.Text));
            ekle1.Parameters.AddWithValue("Ad", textBox10.Text);
            ekle1.Parameters.AddWithValue("Soyad", textBox11.Text);
            ekle1.Parameters.AddWithValue("Baslangic_Tarihi", Convert.ToDateTime(textBox12.Text));
            ekle2.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox9.Text));
            ekle2.Parameters.AddWithValue("@Bölüm", textBox13.Text);
            ekle3.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox9.Text));
            ekle3.Parameters.AddWithValue("@Maaş", Convert.ToInt32(textBox14.Text));
            ekle1.ExecuteNonQuery();
            ekle2.ExecuteNonQuery();
            ekle3.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            con2.Open();
            OleDbCommand guncelle1 = new OleDbCommand("Update personel set Ad=@Ad, Soyad=@Soyad, Baslangic_Tarihi=@Baslangic_Tarihi where Numara=@Numara", con2);
            guncelle1.Parameters.AddWithValue("@Ad", textBox10.Text);
            guncelle1.Parameters.AddWithValue("@Soyad", textBox11.Text);
            guncelle1.Parameters.AddWithValue("@Baslangic_Tarihi", Convert.ToDateTime(textBox12.Text));
            guncelle1.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox9.Text));
            guncelle1.ExecuteNonQuery();
            OleDbCommand guncelle2 = new OleDbCommand("Update bolum set Bölüm=@Bölüm where Numara=@Numara", con2);
            guncelle2.Parameters.AddWithValue("@Bölüm", textBox13.Text);
            guncelle2.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox15.Text));
            guncelle2.ExecuteNonQuery();
            OleDbCommand guncelle3 = new OleDbCommand("Update maas set Maaş=@Maaş where Numara=@Numara", con2);
            guncelle3.Parameters.AddWithValue("@Maaş", Convert.ToInt32(textBox14.Text));
            guncelle3.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox16.Text));
            guncelle3.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            con2.Open();
            OleDbCommand sil1 = new OleDbCommand("Delete from personel where Numara=@Numara", con2);
            OleDbCommand sil2 = new OleDbCommand("Delete from bolum where Numara=@Numara", con2);
            OleDbCommand sil3 = new OleDbCommand("Delete from maas where Numara=@Numara", con2);
            sil1.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox9.Text));
            sil2.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox15.Text));
            sil3.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox16.Text));
            sil1.ExecuteNonQuery();
            sil2.ExecuteNonQuery();
            sil3.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
