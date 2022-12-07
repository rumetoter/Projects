using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // textBox'ta sadece rakam ve backspace(silme) tuşu aktif olsun
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            textBox1.MaxLength = 10; // Numara 10 haneli olacağı için 11. hane girişine izin verme
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 10)
                // Eğer textBox'a girilen numara 10 haneli değilse kullanıcıya uyarı verir
                MessageBox.Show("Lütfen 10 Haneli Okul Numaranızı Giriniz");
            else
            {
                // sameData değişkeni her 10 haneli yeni numara girildiğinde false olarak değer döndürecek
                // listBox'taki eleman sayısı kadar döngü dönecek. Numaraları 1 - 1234567890 şeklinde listbox'a aktardığım için ilk 4 haneyi siliyorum
                // 4 hane silindikten sonra elde ettiğim veri, textBox1'deki veriyle aynı mı diye kontrol ediyorum
                // eğer veri aynıysa sameData değişkenim True değer alıyor. değilse değişkenim false kalmaya devam ediyor
                // listBox'taki bütün elemanları gezmek için döngü listBox count kadar dönmeli
                bool sameData = false;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string data_i = listBox1.Items[i].ToString().Substring(4); //Substring(4) -> Baştan 4 haneyi sil kalanları kullan
                    if (data_i == textBox1.Text)
                        sameData = true;
                }
                // Burada kayıt ekleme işlemi yapıyorum
                // Eğer döngüden sonra sameData değişkenim true değer aldıysa (yani listboxtaki numarayı tekrar girdiysem)
                // Kullanıcıya msgbox ile uyarı veriyorum
                // sameData değişkenim false olarak kaldıysa tekrar eden veri olmadığını anlayıp listBox'a ekleme işlemi yapıyorum
                if (sameData == true)
                    MessageBox.Show("Kayıtlı Numara Girdiniz");
                else
                    listBox1.Items.Add((listBox1.Items.Count + 1).ToString() + " - " + textBox1.Text);
                textBox1.Clear();
            }            
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show((listBox1.Items.Count).ToString() + " Adet Kayıt Bulunmaktadır");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0) // Eğer listbox'ta seçilmiş eleman yoksa
                MessageBox.Show("Lütfen Silmek İstediğiniz Numaraları Seçiniz"); // Kullanıcıya seçim yapması için uyarı ver
            else // Seçilen veri varsa
            {
                int removedItems = 0; // Döngüye girmeden önce 0 a eşit bir değişken tanımlıyorum
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--) //Seçilen satır sayısı kadar for döngüsüne gir
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]); //Remove("string") şeklinde çalışır. listBox1.SelectedItems[i] ile seçili satırdaki veriyi alıyorum
                    removedItems++; //Döngü her döndüğünde değişkenim 1 er artıyor
                } 
                MessageBox.Show(removedItems.ToString() + " Kayıt Silindi"); //Döngünün kaç tur döndüğünü kullanıcıya bildirim verirken kullanıyorum
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended; //Kullanıcının listbox'ta çoklu seçim yapabilmesi için eklendi
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0) // Eğer listbox'ta seçilmiş eleman yoksa
                MessageBox.Show("Lütfen Silmek İstediğiniz Numaraları Seçiniz"); // Kullanıcıya seçim yapması için uyarı ver
            else // Seçilen veri varsa
            {
                int removedItems = 0; // Döngüye girmeden önce 0 a eşit bir değişken tanımlıyorum
                do // Seçili satır sayısı - 1 ifadesi 0'a eşit veya büyük olduğu sürece döngü döner
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[listBox1.SelectedItems.Count - 1]); //For döngüsündeki i değeri burda seçili eleman sayısı - 1 olarak kullanıldı
                    removedItems++;
                }
                while (listBox1.SelectedItems.Count - 1 >= 0); // Son kayıt silindiğinde seçili kayıt sayısı = 0 olacaktır
                // 0 - 1 >= 0 ifadesi false değer döndüreceği için döngü bitecektir
                MessageBox.Show(removedItems.ToString() + " Kayıt Silindi"); //Döngünün kaç tur döndüğünü kullanıcıya bildirim verirken kullanıyorum
            }
        }
    }
}
