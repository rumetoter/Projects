Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Public Class Form1
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim sorgu As String = "select * from ogrenci"
    Dim baglanti As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\ogrenciler.accdb"
    Dim komut As New OleDbCommand
    Public Sub listele()
        ds.Clear()
        con = New OleDbConnection(baglanti)
        da = New OleDbDataAdapter(sorgu, con)
        da.Fill(ds, "xyz")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listele()
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.Columns.Add("Ad", 100)
        ListView1.Columns.Add("Görev", 100)
        ListView1.Columns.Add("Maaş", 100)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        komut.Connection = con
        komut.CommandType = CommandType.Text
        komut.CommandText = "insert into ogrenci (Ad,Soyad,Ders_Adi) VALUES (@Ad,@Soyad,@Ders_Adi)"
        komut.Parameters.AddWithValue("@Ad", TextBox1.Text)
        komut.Parameters.AddWithValue("@Soyad", TextBox2.Text)
        komut.Parameters.AddWithValue("@Ders_Adi", TextBox3.Text)
        komut.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Kayıt Başarılı")
        listele()
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text = "") Then
            MsgBox("Silmek İstediğiniz Öğrencinin Adını Giriniz")
        Else
            con.Open()
            komut.Connection = con
            komut.CommandType = CommandType.Text
            komut.CommandText = "delete from ogrenci where Ad=@Ad"
            komut.Parameters.AddWithValue("@Ad", TextBox1.Text)
            komut.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Silme İşlemi Başarılı")
            listele()
        End If
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dosya As New XmlDocument
        dosya.Load(Application.StartupPath + "\ogrenci.xml")
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim ogrenci As XmlElement = dosya.CreateElement("ogrenci")
            'ogrenci.SetAttribute("Numara", (i + 1).ToString())   // Bu işlem ile <ogrenci> tagı içerisine numara girişi yapmamış oluyoruz.
            ogrenci.SetAttribute("Numara", (i + 1).ToString())
            Dim Ad As XmlNode = dosya.CreateNode("element", "Ad", "")
            Ad.InnerText = DataGridView1.Rows(i).Cells(0).Value.ToString()
            ogrenci.AppendChild(Ad)
            Dim soyad As XmlNode = dosya.CreateNode("element", "Soyad", "")
            soyad.InnerText = DataGridView1.Rows(i).Cells(1).Value.ToString()
            ogrenci.AppendChild(soyad)
            Dim d_adi As XmlNode = dosya.CreateNode("element", "Ders_Adı", "")
            d_adi.InnerText = DataGridView1.Rows(i).Cells(2).Value.ToString()
            ogrenci.AppendChild(d_adi)
            dosya.DocumentElement.AppendChild(ogrenci)
        Next
        dosya.Save(Application.StartupPath + "\ogrenci.xml")
        MsgBox("Veriler XML Dosyasına Aktarıldı" + vbCrLf + Application.StartupPath.ToString() + "\ogrenci.xml")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        Dim i, j As Integer
        For i = 0 To DataGridView1.Rows.Count - 2
            For j = 0 To DataGridView1.Columns.Count - 1
                ListBox1.Items.Add(DataGridView1.Rows(i).Cells(j).Value.ToString())
            Next
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim dosya As XmlDocument
        Dim ds1 As DataSet = New DataSet()
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create("ogrenci.xml", New XmlReaderSettings())
        ds1.ReadXml(xmlFile)
        DataGridView2.DataSource = ds1.Tables(0)
        DataGridView2.ReadOnly = True
        xmlFile.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim dosya As New XmlDocument
        dosya.Load(Application.StartupPath + "\isci.xml")
        Dim liste As XmlNodeList = dosya.GetElementsByTagName("isci")
        Dim ogrenci As XmlNode
        Dim a As Integer
        For Each ogrenci In liste
            Dim sicil As String
            sicil = ogrenci.Attributes("sicil").Value
            Dim ad As String = ogrenci("ad").FirstChild.Value
            Dim gorev As String = ogrenci("görev").FirstChild.Value
            Dim ucret As String = ogrenci("ucret").FirstChild.Value
            ListView1.Items.Add(sicil)
            ListView1.Items(a).SubItems.Add(ad)
            ListView1.Items(a).SubItems.Add(gorev)
            ListView1.Items(a).SubItems.Add(ucret)
            a += 1
        Next
    End Sub
End Class
