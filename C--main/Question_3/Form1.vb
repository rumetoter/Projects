Imports Microsoft.Office.Interop
Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim excel_app As Excel.Application
    Dim yeni_kitap As Excel.Workbook
    Dim tablo As Excel.Worksheet

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
        listele()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        excel_app = CreateObject("Excel.Application")
        excel_app.Visible = True
        yeni_kitap = excel_app.Workbooks.Add
        tablo = excel_app.ActiveWorkbook.ActiveSheet()
        For i = 0 To DataGridView1.Columns.Count - 1
            tablo.Cells(1, i + 1) = DataGridView1.Columns(i).Name
        Next
        For i = 0 To DataGridView1.Rows.Count - 1
            For j = 0 To DataGridView1.Columns.Count - 1
                tablo.Cells((i + 2), (j + 1)) = DataGridView1.Rows(i).Cells(j).Value
            Next
        Next
        excel_app.Visible = True
    End Sub
End Class
