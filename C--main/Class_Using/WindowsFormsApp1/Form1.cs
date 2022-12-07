using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using basari;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int n, vize1, vize2, final, ortalama;
            n = Convert.ToInt32(Interaction.InputBox("Kaç Öğrenci Girilecek ?"));
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Vize11", 100);
            listView1.Columns.Add("Vize2", 100);
            listView1.Columns.Add("Final", 100);
            listView1.Columns.Add("Ortalama", 100);
            for (int i = 0; i < n; i++)
            {
                ogrenci nesne = new ogrenci();
                string a;
                vize1 = Convert.ToInt32(Interaction.InputBox("Vize 1 Giriniz"));
                vize2 = Convert.ToInt32(Interaction.InputBox("Vize 2 Giriniz"));
                final = Convert.ToInt32(Interaction.InputBox("Final Giriniz"));
                ListViewItem veri = new ListViewItem();
                veri = new ListViewItem(vize1.ToString());
                veri.SubItems.Add(vize2.ToString());
                veri.SubItems.Add(final.ToString());
                veri.SubItems.Add(nesne.ortalama(vize1, vize2, final));
                listView1.Items.Add(veri);
            }
        }
    }
}
