using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hesaplama nesne = new hesaplama();
            int vize1, vize2, final;
            vize1 = Convert.ToInt32(Interaction.InputBox("Vize 1 Giriniz"));
            vize2 = Convert.ToInt32(Interaction.InputBox("Vize 2 Giriniz"));
            final = Convert.ToInt32(Interaction.InputBox("Vize 3 Giriniz"));
            label1.Text = "Ortalamanız : " + nesne.ortalama(vize1, vize2, final).ToString();
        }
    }
}
