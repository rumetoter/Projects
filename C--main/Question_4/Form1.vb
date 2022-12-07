Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Data
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uygulama As New Excel.Application
        Dim kitap As Excel.Workbook
        Dim sayfa As Excel.Worksheet
        uygulama.Workbooks.Open(Application.StartupPath + "\deneme.xlsx")
        kitap = uygulama.ActiveWorkbook
        sayfa = kitap.ActiveSheet

        Dim sayac, lokal, lokal2 As Integer
        sayac = 0
        lokal = 1
        lokal2 = Convert.ToInt16(InputBox("Kaç Satır Okunacak"))
        Do While lokal <= lokal2
            sayac = sayac + 1
            If sayfa.Cells(lokal + 1, 1).Value.ToString() = "" Then
                Exit Do
            End If
            lokal = lokal + 1
        Loop
        DataGridView1.Columns.Add("tc", "TC")
        DataGridView1.Columns.Add("ad", "Ad")
        DataGridView1.Columns.Add("soyad", "Soyad")
        For lokal = 1 To sayac
            DataGridView1.Rows.Add()
            DataGridView1.Rows(lokal - 1).Cells(0).Value = sayfa.Cells(lokal + 1, 1).Value
            DataGridView1.Rows(lokal - 1).Cells(1).Value = sayfa.Cells(lokal + 1, 2).Value
            DataGridView1.Rows(lokal - 1).Cells(2).Value = sayfa.Cells(lokal + 1, 3).Value
        Next
    End Sub
End Class
