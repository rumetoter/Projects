Imports System.Data.SqlClient
Imports System.Xml
Imports Microsoft.Office.Interop
Public Class Form1
    Dim con As New SqlConnection("Data Source=DESKTOP-M7RU5CO\SQLEXPRESS;Initial Catalog=personel;Integrated Security=True")
    Dim tablo As New DataTable()
    Dim bs As New BindingSource()
    Dim xmlDosya As New XmlDocument
    Dim word_app As New Word.Application
    Dim new_doc As New Word.Document
    Public Sub XmlOlustur(node As XmlNode, ad As String, tb As TextBox, element As XmlElement)
        node = xmlDosya.CreateNode("element", ad, "")
        node.InnerText = tb.Text
        element.AppendChild(node)
    End Sub
    Public Sub ShowDatas()
        con.Open()
        Dim adapter As New SqlDataAdapter("select * from pers", con)
        tablo.Clear()
        adapter.Fill(tablo)
        bs.DataSource = tablo
        DataGridView1.DataSource = bs
        con.Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowDatas()
        TextBox1.DataBindings.Add("Text", bs, "TC")
        TextBox2.DataBindings.Add("Text", bs, "Ad")
        TextBox3.DataBindings.Add("Text", bs, "Soyad")
        new_doc = word_app.Documents.Add
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("insert into pers (TC,Ad,Soyad) VALUES (@TC,@Ad,@Soyad)", con)
        command.Parameters.AddWithValue("@TC", TextBox1.Text)
        command.Parameters.AddWithValue("@Ad", TextBox2.Text)
        command.Parameters.AddWithValue("@Soyad", TextBox3.Text)
        con.Open()
        command.ExecuteNonQuery()
        con.Close()
        ShowDatas()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 5
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        TextBox2.MaxLength = 10
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        TextBox3.MaxLength = 10
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim command As New SqlCommand("update pers set Ad=@Ad, Soyad=@Soyad where TC=@TC", con)
        command.Parameters.AddWithValue("@TC", TextBox1.Text)
        command.Parameters.AddWithValue("@Ad", TextBox2.Text)
        command.Parameters.AddWithValue("@Soyad", TextBox3.Text)
        con.Open()
        command.ExecuteNonQuery()
        con.Close()
        ShowDatas()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim command As New SqlCommand("delete from pers where TC=@TC", con)
        command.Parameters.AddWithValue("@TC", Convert.ToInt64(TextBox1.Text))
        con.Open()
        command.ExecuteNonQuery()
        con.Close()
        ShowDatas()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        xmlDosya.Load(Application.StartupPath + "\deneme1.xml")
        Dim ad, soyad As XmlNode
        bs.MoveFirst()
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim pers As XmlElement = xmlDosya.CreateElement("Personel")
            pers.SetAttribute("TC", TextBox1.Text)
            XmlOlustur(ad, "Ad", TextBox2, pers)
            XmlOlustur(soyad, "Soyad", TextBox3, pers)
            xmlDosya.DocumentElement.AppendChild(pers)
            bs.MoveNext()
        Next
        xmlDosya.Save(Application.StartupPath + "\deneme1.xml")
        bs.MoveFirst()
        MsgBox("Veriler XML Dosyasına Aktarıldı")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        xmlDosya.Load(Application.StartupPath + "\deneme2.xml")
        Dim liste As XmlNodeList = xmlDosya.GetElementsByTagName("Personel")
        Dim personel As XmlNode
        Dim kayitNo As Integer
        For Each personel In liste
            Dim tc, ad, soyad As String
            tc = personel.Attributes("TC").Value
            ad = personel("Ad").FirstChild.Value
            soyad = personel("Soyad").FirstChild.Value
            Dim dr As DataRow
            dr = tablo.NewRow()
            dr(0) = tc
            dr(1) = ad
            dr(2) = soyad
            tablo.Rows.Add(dr)
            kayitNo += 1
            Dim command As New SqlCommand("insert into pers (TC,Ad,Soyad) VALUES (@TC,@Ad,@Soyad)", con)
            command.Parameters.AddWithValue("@TC", tc)
            command.Parameters.AddWithValue("@Ad", ad)
            command.Parameters.AddWithValue("@Soyad", soyad)
            con.Open()
            command.ExecuteNonQuery()
            con.Close()
        Next
        DataGridView1.DataSource = tablo
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        word_app.Visible = True
        Dim sayac As Integer
        For i = 0 To DataGridView1.Rows.Count - 2
            If (sayac = 0) Then
                new_doc.Range().InsertBefore(DataGridView1.Rows(i).Cells(0).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value)
                sayac += 1
            Else
                new_doc.Paragraphs.Add()
                new_doc.Range().InsertAfter(DataGridView1.Rows(i).Cells(0).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
                new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value)
            End If
        Next
    End Sub
End Class
