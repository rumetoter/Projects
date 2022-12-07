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

namespace WindowsFormsApp1
{
    //Form load edildikten sonra buton tıklamasıyla textboxtan alınan sayıyı eksilterek listbox içinde görüntüleyen program kodlarını yazınız
    //Koşul : Küçülebileceği en düşük sayı değeri 5, eksiltme değeri 1, döngü for ile
    //while döngüsü kur toplam = 1 olsun toplam <= 555 olsun label'in textine toplam yazılsın
    // iç içe 3 tane for döngüsü kullan. 3 er tur dönsünler
    //For, while, do while döngüleri işlendi

    //Soru : Klavyeden girilen başlangıç ve bitiş kolon sayılarına göre çarpım cetvelini listBox içinde görüntüleyen program kodunu yazınız
    //Koşul : For, while ve do while döngülerinin hepsini kullanınız
    //Koşul : Kolon değer girişleri inputbox ile alınacak
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int s1, s2;
        private void button1_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToInt16(Interaction.InputBox("1. Sayıyı Giriniz"));
            s2 = Convert.ToInt16(Interaction.InputBox("2. Sayıyı Giriniz"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            while (s1 <= s2)
            {
                listBox1.Items.Add(s1.ToString() + "*" + s2.ToString() + "=" + (s1 * s2).ToString());
                s1++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = s1; i <= s2; i++)
            {
                for (int j = s1; j <= s2; j++)
                {
                    listBox1.Items.Add(i.ToString() + "*" + j.ToString() + "=" + (i*j).ToString());
                }
            }
        }
    }
}
