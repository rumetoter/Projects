using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GenelTekrar1
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\geneltekrar1.accdb");
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        void listele()
        {
            da = new OleDbDataAdapter("Select * from personel", con);
            con.Open();
            da.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            con.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            textBox1.DataBindings.Add("Text", bs, "TC");
            textBox2.DataBindings.Add("Text", bs, "Ad");
            textBox3.DataBindings.Add("Text", bs, "Soyad");
            textBox4.DataBindings.Add("Text", bs, "Dogum_Yeri");
            textBox5.DataBindings.Add("Text", bs, "Dogum_Tarihi");
            textBox6.DataBindings.Add("Text", bs, "Adres");
            textBox7.DataBindings.Add("Text", bs, "Cinsiyet");
            textBox8.DataBindings.Add("Text", bs, "MedeniDurum");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            bs.AddNew();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            bs.AddNew();
            textBox1.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            con.Open();
            OleDbCommand ekle = new OleDbCommand("Insert INTO personel (TC,Ad,Soyad,Dogum_Yeri,Dogum_Tarihi,Adres,Cinsiyet,MedeniDurum) VALUES (@TC,@Ad,@Soyad,@Dogum_Yeri,@Dogum_Tarihi,@Adres,@Cinsiyet,@MedeniDurum)", con);
            ekle.Parameters.AddWithValue("@TC", (textBox1.Text));
            ekle.Parameters.AddWithValue("@Ad", textBox2.Text);
            ekle.Parameters.AddWithValue("@Soyad", textBox3.Text);
            ekle.Parameters.AddWithValue("@Dogum_Yeri", textBox4.Text);
            ekle.Parameters.AddWithValue("@Dogum_Tarihi", textBox5.Text);
            ekle.Parameters.AddWithValue("@Adres", textBox6.Text);
            ekle.Parameters.AddWithValue("@Cinsiyet", textBox7.Text);
            ekle.Parameters.AddWithValue("@MedeniDurum", textBox8.Text);
            ekle.ExecuteNonQuery();
            con.Close();
            listele();

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            con.Open();
            OleDbCommand guncel = new OleDbCommand("Update personel Set Ad=@Ad,Soyad=@Soyad,Dogum_Yeri=@Doğum Yeri,Dogum_Tarihi=@Doğum Tarihi,Adres=@Adres,Cinsiyet=@Cinsiyet,MedeniDurum=@MedeniDurum Where TC=@TC", con);
            guncel.Parameters.AddWithValue("Ad", textBox2.Text);
            guncel.Parameters.AddWithValue("Soyad", textBox3.Text);
            guncel.Parameters.AddWithValue("Dogum_Yeri", textBox4.Text);
            guncel.Parameters.AddWithValue("Dogum_Tarihi", textBox5.Text);
            guncel.Parameters.AddWithValue("Adres", textBox6.Text);
            guncel.Parameters.AddWithValue("Cinsiyet", textBox7.Text);
            guncel.Parameters.AddWithValue("MedeniDurum", textBox8.Text);
            guncel.Parameters.AddWithValue("TC", Convert.ToInt64(textBox1.Text));
            guncel.ExecuteNonQuery();
            con.Close();
            listele();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OleDbCommand sil = new OleDbCommand("Delete From personel Where TC=@TC", con);
            sil.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();
            sil.ExecuteNonQuery();
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Find("Ad", textBox9.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
