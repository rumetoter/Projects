Imports System.Data.OleDb
Imports System.Data
Imports System
Public Class Form1
    Dim baglan As OleDbConnection
    Dim verial As OleDbDataAdapter
    Dim al As DataSet = New DataSet()
    Dim sorgu As String = "select * from ogrenci"
    Dim baglanti As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\bilgisayar.accdb"
    Dim komut As New OleDbCommand
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        baglan = New OleDbConnection(baglanti)
        verial = New OleDbDataAdapter(sorgu, baglan)
        verial.Fill(al, "abcd")
        DataGridView1.DataSource = al.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        baglan.Open()
        komut.Connection = baglan
        komut.CommandType = CommandType.Text
        komut.CommandText = "Insert INTO ogrenci (Ad,Soyad,Adres,D_Yeri,D_Tarihi) VALUES (@Ad,@Soyad,@Adres,@D_Yeri,@D_Tarihi)"
        komut.Parameters.AddWithValue("@Ad", TextBox1.Text)
        komut.Parameters.AddWithValue("@Soyad", TextBox2.Text)
        komut.Parameters.AddWithValue("@Adres", TextBox3.Text)
        komut.Parameters.AddWithValue("@Doğum Yeri", TextBox4.Text)
        komut.Parameters.AddWithValue("@Doğum Tarihi", TextBox5.Text)
        komut.ExecuteNonQuery()
        baglan.Close()
        MsgBox("Kayıt Başarılı, VT Kontrol Ediniz")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        baglan.Open()
        komut.Connection = baglan
        komut.CommandType = CommandType.Text
        komut.CommandText = "Update ogrenci SET Ad=@Ad, Soyad=@Soyad, Adres=@Adres, D_Tarihi=@D_Tarihi, D_Yeri=@D_Yeri where Numara=@Numara"
    End Sub
End Class
