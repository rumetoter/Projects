using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        XmlDocument dosya = new XmlDocument();
        XmlDocument dosya_isci = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dosya.Load(Application.StartupPath + "\\personel.xml");
            XmlElement calisan = dosya.CreateElement("Çalışan");
            calisan.SetAttribute("Ad", textBox1.Text);
            XmlNode soyad = dosya.CreateNode("element", "Soyad", "");
            soyad.InnerText = textBox2.Text;
            calisan.AppendChild(soyad);
            XmlNode dyeri = dosya.CreateNode("element", "DoğumYeri", "");
            dyeri.InnerText = textBox3.Text;
            calisan.AppendChild(dyeri);
            XmlNode dtarihi = dosya.CreateNode("element", "DoğumTarihi", "");
            dtarihi.InnerText = textBox4.Text;
            calisan.AppendChild(dtarihi);
            XmlNode cinsiyet = dosya.CreateNode("element", "Cinsiyet", "");
            cinsiyet.InnerText = textBox5.Text;
            calisan.AppendChild(cinsiyet);
            XmlNode milliyet = dosya.CreateNode("element", "Milliyet", "");
            milliyet.InnerText = textBox6.Text;
            calisan.AppendChild(milliyet);
            XmlNode adres = dosya.CreateNode("element", "Adres", "");
            adres.InnerText = textBox7.Text;
            calisan.AppendChild(adres);
            dosya.DocumentElement.AppendChild(calisan);
            dosya.Save(Application.StartupPath + "\\personel.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dosya_isci.Load(Application.StartupPath + "\\isci.xml");
            XmlNodeList liste = dosya_isci.GetElementsByTagName("isci");           
            int a = 0;
            foreach (XmlNode ogrenci in liste)
            {
                string sicil, ad, gorev, ucret;
                sicil = ogrenci.Attributes["sicil"].Value;
                ad = ogrenci["ad"].FirstChild.Value;
                gorev = ogrenci["görev"].FirstChild.Value;
                ucret = ogrenci["ucret"].FirstChild.Value;
                listView1.Items.Add(sicil);
                listView1.Items[a].SubItems.Add(ad);
                listView1.Items[a].SubItems.Add(gorev);
                listView1.Items[a].SubItems.Add(ucret);
                a += 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ad", 150);
            listView1.Columns.Add("Görev", 150);
            listView1.Columns.Add("Maaş", 150);
        }
    }
}
