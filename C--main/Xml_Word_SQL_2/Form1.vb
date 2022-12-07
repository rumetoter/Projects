Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.Xml
Public Class Form1
    Dim con As New SqlConnection("Data Source=DESKTOP-M7RU5CO\SQLEXPRESS;Initial Catalog=personel;Integrated Security=True")
    Dim tablo As New DataTable()
    Dim bs As New BindingSource()
    Dim xmlDosya As New XmlDocument
    Dim word_app As New Word.Application
    Dim new_doc As New Word.Document
    Public Sub ShowDatas()
        con.Open()
        Dim adapter As New SqlDataAdapter("select * from veriler", con)
        tablo.Clear()
        adapter.Fill(tablo)
        bs.DataSource = tablo
        DataGridView1.DataSource = bs
        DataGridView1.ReadOnly = True
        con.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowDatas()
        new_doc = word_app.Documents.Add
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        xmlDosya.Load(Application.StartupPath + "\deneme2.xml")
        Dim liste As XmlNodeList = xmlDosya.GetElementsByTagName("Personel")
        Dim personel As XmlNode
        For Each personel In liste
            Dim ad, soyad, maas As String
            ad = personel.Attributes("Ad").Value
            soyad = personel("Soyad").FirstChild.Value
            maas = personel("Maas").FirstChild.Value
            Dim dr As DataRow
            dr = tablo.NewRow()
            dr(0) = ad
            dr(1) = soyad
            dr(2) = maas
            tablo.Rows.Add(dr)
            Dim command As New SqlCommand("insert into veriler (Ad,Soyad,Maas) VALUES (@Ad,@Soyad,@Maas)", con)
            command.Parameters.AddWithValue("@Ad", ad)
            command.Parameters.AddWithValue("@Soyad", soyad)
            command.Parameters.AddWithValue("@Maas", CInt(maas))
            con.Open()
            command.ExecuteNonQuery()
            con.Close()
        Next
        DataGridView1.DataSource = tablo
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        word_app.Visible = True
        Dim sayac As Integer
        For i = 0 To DataGridView1.Rows.Count - 2
            If (sayac = 0) Then
                new_doc.Range().InsertBefore(DataGridView1.Rows(i).Cells(0).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value.ToString())
                sayac += 1
            Else
                new_doc.Paragraphs.Add()
                new_doc.Range().InsertAfter(DataGridView1.Rows(i).Cells(0).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value.ToString())
            End If
        Next
    End Sub
End Class
