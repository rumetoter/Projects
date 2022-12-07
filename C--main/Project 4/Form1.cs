using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;

namespace VizeSinavi
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\ogrenci.accdb");
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        void listele()
        {
            con.Open();
            OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from Kayit", con);
            OleDbDataAdapter da2 = new OleDbDataAdapter("Select * from sinav", con);
            da1.Fill(dt1);
            da2.Fill(dt2);
            bs1.DataSource = dt1;
            bs2.DataSource = dt2;
            dataGridView1.DataSource = bs1;
            dataGridView2.DataSource = bs2;
            con.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox17.Enabled = false;
            textBox18.Visible = false;
            listele();
            textBox1.DataBindings.Add("Text", bs1, "Okul_no");
            textBox2.DataBindings.Add("Text", bs1, "Adi");
            textBox3.DataBindings.Add("Text", bs1, "Soyadi");
            textBox4.DataBindings.Add("Text", bs1, "Sinifi");
            textBox5.DataBindings.Add("Text", bs1, "Subesi");
            textBox6.DataBindings.Add("Text", bs1, "Telefon_no");
            textBox7.DataBindings.Add("Text", bs1, "Adresi");
            textBox8.DataBindings.Add("Text", bs2, "C_Sharp");
            textBox9.DataBindings.Add("Text", bs2, "V_Basic");
            textBox10.DataBindings.Add("Text", bs2, "Veri_taban");
            textBox11.DataBindings.Add("Text", bs2, "Mob_uyg");
            textBox12.DataBindings.Add("Text", bs2, "Ac_kaynak");
            textBox13.DataBindings.Add("Text", bs2, "Sis_analiz");
            textBox18.DataBindings.Add("Text", bs2, "Okul_no");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from Kayit", con);
            OleDbDataAdapter da2 = new OleDbDataAdapter("Select * from sinav", con);
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            da1.Fill(dt3);
            da2.Fill(dt4);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt3);
            ds.Tables.Add(dt4);
            DataRelation dr = new DataRelation("Öğrencinin Ders Notları", dt3.Columns["Okul_no"], dt4.Columns["Okul_no"]);
            ds.Relations.Add(dr);
            dataGrid1.DataSource = ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            bs1.AddNew();
            bs2.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs1.EndEdit();
            bs2.EndEdit();
            bs1.AddNew();
            bs2.AddNew();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBox17.Text = ((Convert.ToInt32(textBox14.Text) * 0.25) + (Convert.ToInt32(textBox15.Text) * 0.25) + (Convert.ToInt32(textBox16.Text) * 0.5)).ToString();
            textBox8.Text = textBox17.Text;
            textBox9.Text = textBox17.Text;
            textBox10.Text = textBox17.Text;
            textBox11.Text = textBox17.Text;
            textBox12.Text = textBox17.Text;
            textBox13.Text = textBox17.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox18.Text = textBox1.Text;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.SetValue("ismail", 1959);
        }
    }
}
