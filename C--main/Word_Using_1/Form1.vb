Imports Microsoft.Office.Interop
Public Class Form1
    Dim word_app As New Word.Application
    Dim new_doc As New Word.Document
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        new_doc.Range().InsertBefore("Doğukan")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        new_doc = word_app.Documents.Add
        word_app.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        new_doc.Range().InsertAfter(" TEKİN")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        new_doc.Paragraphs.Add()
        new_doc.Range().InsertAfter("deu/imyo/Bilgisayar Programcılığı")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        new_doc.Range.InsertBefore(TextBox1.Text + " ")
        new_doc.Range.InsertAfter(TextBox2.Text)
        new_doc.Paragraphs.Add()
        new_doc.Range().InsertAfter(TextBox3.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        new_doc.Range.InsertBefore(TextBox1.Text)
        new_doc.Range.InsertAfter(Space(InputBox("Kaç Karakter Boşluk Bırakılacak ?")) + TextBox2.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.Text = new_doc.Range().Text
        word_app.Quit()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Seçili olanları almak için
        RichTextBox2.Text = new_doc.StoryRanges.Application.Selection.Text
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Dosya çağırır
        new_doc = word_app.Documents.Open(Application.StartupPath + TextBox1.Text)
        RichTextBox1.Text = new_doc.Range().Text
    End Sub
End Class
