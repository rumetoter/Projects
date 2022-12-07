Imports System.Xml
Public Class Form1
    Dim dosya As New XmlDocument
    Dim liste As XmlNodeList
    Dim ogrenci As XmlNode
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        dosya.Load(Application.StartupPath + "\soru1.xml")
        ListView1.Columns.Add("TC", 150)
        ListView1.Columns.Add("Ad", 150)
        ListView1.Columns.Add("Soyad", 150)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Integer
        liste = dosya.GetElementsByTagName("Personel")
        For Each ogrenci In liste
            Dim tc As String
            tc = ogrenci.Attributes("TC").Value
            Dim ad As String = ogrenci("Ad").FirstChild.Value
            Dim soyad As String = ogrenci("Soyad").FirstChild.Value
            ListView1.Items.Add(tc)
            ListView1.Items(a).SubItems.Add(ad)
            ListView1.Items(a).SubItems.Add(soyad)
            a += 1
        Next
    End Sub
End Class
