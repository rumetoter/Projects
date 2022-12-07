using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32; //Registry işlemleri için kullanılması gerekiyor
using Microsoft.VisualBasic; //InputBox kullanmak için ekledim

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string olusansifrerakam, olusansifreharf; //Sezar Şifreleme Sorusu için 2 string veri ve 2 string dizi tanımladım. 2 Butonda kullanacağım için public olmalı
        string[] sifrerakam = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2" };
        string[] sifreharf = { "a", "b", "c", "ç", "d", "e", "f", "g", "ğ", "h", "ı", "i", "j", "k", "l", "m", "n", "o", "ö", "p", "r", "s", "ş", "t", "u", "ü", "v", "y", "z", "a", "b", "c" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.SetValue("Doğukan1", 1996);
            Registry.CurrentUser.SetValue("Hasan", "123A");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("Doğukan52").SetValue("deneme", "1996Ben");
            Registry.CurrentUser.CreateSubKey("Doğukan5252").CreateSubKey("Tekin5252").CreateSubKey("Ünye5252").SetValue("deneme", 1996);
            Registry.CurrentUser.CreateSubKey("DoğukanTekin");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Registry.CurrentUser.OpenSubKey("Doğukan5252").OpenSubKey("Tekin5252").OpenSubKey("Ünye5252").GetValue("deneme").ToString());
            MessageBox.Show(Registry.CurrentUser.OpenSubKey("Doğukan52").GetValue("deneme").ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.DeleteValue("Doğukan1"); //Buton1 ile oluşturup sonra silme işlemi yapılmalı
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.DeleteSubKey("DoğukanTekin"); //Button2 ile oluşturup sonra silme işlemi yapılmalı
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.DeleteSubKeyTree("Doğukan5252"); //Buton3 ile oluşturup sonra silme yapılmalı
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.SetValue(textBox1.Text, textBox2.Text);
            MessageBox.Show("Oluştu");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Registry.CurrentUser.GetValue(textBox1.Text).ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string id1, id2, id3, id4, psw, anahtar;
            id1 = Interaction.InputBox("1. Klasörün Adını Giriniz");
            id2 = Interaction.InputBox("2. Klasörün Adını Giriniz");
            id3 = Interaction.InputBox("3. Klasörün Adını Giriniz");
            id4 = Interaction.InputBox("4. Klasörün Adını Giriniz");
            anahtar = Interaction.InputBox("Anahtar Kelime Giriniz");
            psw = Interaction.InputBox("Object Değeri Giriniz");
            Registry.CurrentUser.CreateSubKey(id1).CreateSubKey(id2).CreateSubKey(id3).CreateSubKey(id4).SetValue(anahtar, psw);
            MessageBox.Show("Object Değer : " + Registry.CurrentUser.OpenSubKey(id1).OpenSubKey(id2).OpenSubKey(id3).OpenSubKey(id4).GetValue(anahtar).ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string cozumlenecek, cozumle;
            cozumle = "";
            string[] coz = { "9", "8", "7", "6", "5", "4", "3", "2", "1", "0", "9", "8", "7" };
            cozumlenecek = Registry.CurrentUser.GetValue(olusansifreharf).ToString();
            for (int i = 0; i < cozumlenecek.Length; i++)
            {
                for (int j = 0; j < coz.Length - 3; j++)
                {
                    if (cozumlenecek.Substring(i, 1).Equals(coz[j]))
                    {
                        cozumle += coz[j + 3];
                    }
                }
            }
            MessageBox.Show("Kayıtlı Şifre : " + olusansifrerakam + " Şifrenin Anlamı : " + cozumle);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string anahtar, obdeger;
            olusansifreharf = "";
            olusansifrerakam = "";
            anahtar = Interaction.InputBox("Anahtar Değer Giriniz");
            obdeger = Interaction.InputBox("Object Değer Giriniz");
            for (int i = 0; i < anahtar.Length; i++)
            {
                for (int j = 0; j < sifreharf.Length - 3; j++)
                {
                    if (anahtar.Substring(i, 1).Equals(sifreharf[j]))
                    {
                        olusansifreharf += sifreharf[j + 3];
                    }
                }
            }
            for (int i = 0; i < obdeger.Length; i++)
            {
                for (int j = 0;j < sifrerakam.Length - 3; j++)
                {
                    if (obdeger.Substring(i, 1).Equals((sifrerakam[j])))
                    {
                        olusansifrerakam += sifrerakam[j + 3];
                    }
                }
            }
            Registry.CurrentUser.SetValue(olusansifreharf, olusansifrerakam);
        }
    }
}
