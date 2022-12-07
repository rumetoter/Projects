Imports Microsoft.Office.Interop
Public Class Form1
    Dim excel_app As Excel.Application
    Dim yeni_kitap As Excel.Workbook
    Dim tablo As Excel.Worksheet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        excel_app = CreateObject("Excel.Application")
        excel_app.Visible = True
        yeni_kitap = excel_app.Workbooks.Add
        tablo = excel_app.ActiveWorkbook.ActiveSheet()
        tablo.Cells(1, 2) = "Adı"
        tablo.Cells(2, 2) = "ismail"
        tablo.Cells(3, 2) = "doğukan"
        tablo.Cells(4, 2) = "tekin"
    End Sub
End Class
