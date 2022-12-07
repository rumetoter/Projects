using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; //ArrayList kullanabilmek için eklenmesi zorunludur
using Microsoft.VisualBasic; //InputBox için tanımladım

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ArrayList dizi = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                dizi.Add(Interaction.InputBox("Okul No Giriniz"));
                dizi.Add(Interaction.InputBox("TC No Giriniz"));
                dizi.Add(Interaction.InputBox("Ad Giriniz"));
                dizi.Add(Interaction.InputBox("Soyad Giriniz"));
                dizi.Add(Interaction.InputBox("Doğum Yeri Giriniz"));
                dizi.Add(Interaction.InputBox("Anne Adı Giriniz"));
                dizi.Add(Interaction.InputBox("Baba Adı Giriniz"));
                dizi.Add(Interaction.InputBox("Cinsiyet Giriniz"));
            foreach (object eleman in dizi)
            {
                listBox1.Items.Add(eleman);
            }
        }
    }
}
