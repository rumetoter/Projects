Imports System.Xml
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Public Class Form1
    Dim dosya As New XmlDocument
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim sorgu As String = "select * from ogrenci"
    Dim baglanti As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\ogrenciler.accdb"
    Public Sub listele()
        ds.Clear()
        con = New OleDbConnection(baglanti)
        da = New OleDbDataAdapter(sorgu, con)
        da.Fill(ds, "xyz")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dosya.Load(Application.StartupPath + "\ogrenci.xml")
        listele()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dosya As New XmlDocument
        Dim adlar As New ArrayList()
        dosya.Load(Application.StartupPath + "\ogrenci.xml")

        Dim liste As XmlNodeList = dosya.GetElementsByTagName("ogrenci")
        Dim ogrenci2 As XmlNode
        For Each ogrenci2 In liste 'XML Dosyasında bulunan verilerin Ad değerlerini ArrayList içerisine aktarıyor
            Dim ad As String = ogrenci2("Ad").FirstChild.Value
            adlar.Add(ad)
        Next

        For i = 0 To DataGridView1.Rows.Count - 2
            'Boş satır olup olmadığını kontrol ediyor. Boş yakalarsa ekleme işlemi yapmıyor
            If (DataGridView1.Rows(i).Cells(0).Value.ToString() = "" Or DataGridView1.Rows(i).Cells(1).Value.ToString() = "" Or
                DataGridView1.Rows(i).Cells(2).Value.ToString() = "") Then
                MsgBox("Boş satır yakalandı")
            Else
                'Boş yakalanmadıysa eğer adlar ArrayList'ine aktarılan değerler ile aktarılacak ad değeri aynı mı diye kontrol ediyor
                'Eğer ad değeri aynıysa "Veri Tekrarı" yazdırıyor.
                If adlar.Contains(DataGridView1.Rows(i).Cells(0).Value.ToString()) Then
                    MsgBox("Veri Tekrarı")
                Else
                    'Aynı ad değeri yakalanmazsa xml dosyasına ekleme işlemini gerçekleştiriyor
                    Dim ogrenci As XmlElement = dosya.CreateElement("ogrenci")
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
                End If
            End If
        Next
        dosya.Save(Application.StartupPath + "\ogrenci.xml")
        MsgBox("Veriler XML Dosyasına Aktarıldı" + vbCrLf + Application.StartupPath.ToString() + "\ogrenci.xml")
    End Sub
End Class
