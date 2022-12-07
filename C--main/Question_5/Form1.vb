Imports Microsoft.Office.Interop
Public Class Form1
    Dim word_app As New Word.Application
    Dim new_doc As New Word.Document
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("TC", 150)
        ListView1.Columns.Add("Ad", 150)
        ListView1.Columns.Add("Soyad", 150)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tc, ad, soyad As String
        tc = TextBox1.Text
        ad = TextBox2.Text
        soyad = TextBox3.Text
        Dim sayac As Integer
        sayac = ListView1.Items.Count
        ListView1.Items.Add(tc)
        ListView1.Items(sayac).SubItems.Add(ad)
        ListView1.Items(sayac).SubItems.Add(soyad)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        word_app.Visible = True
        Dim sayac As Integer
        new_doc.Range().InsertBefore(ListView1.Columns(0).Text)
        new_doc.Range().InsertBefore(ListView1.Columns(1).Text)
        new_doc.Range().InsertBefore(ListView1.Columns(2).Text)
        'For i = 0 To ListView1.Items.Count - 1
        '    If (sayac = 0) Then
        '        new_doc.Range().InsertBefore(DataGridView1.Rows(i).Cells(0).Value)
        '        new_doc.Range().InsertBefore(ListView1.)
        '        new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
        '        new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value)
        '        sayac += 1
        '    Else
        '        new_doc.Paragraphs.Add()
        '        new_doc.Range().InsertAfter(DataGridView1.Rows(i).Cells(0).Value)
        '        new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(1).Value)
        '        new_doc.Range().InsertAfter(" " + DataGridView1.Rows(i).Cells(2).Value)
        '    End If
        'Next
    End Sub
End Class
