Imports System.Data.SqlClient 'SQL Database sınıfı eklendi
Imports ortHesapla_DLL        'Oluşturmuş olduğum ortalama hesaplayan DLL sınıfı eklendi
Imports System.Xml
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Dim con As New SqlConnection("Data Source=DESKTOP-M7RU5CO\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True")
    Dim tablo As New DataTable()
    Dim bs As New BindingSource()
    Dim ort As New Hesaplama()
    Dim ortValue As Double
    Dim tc_liste, ogr_no_liste As New ArrayList()
    Dim kayitliTC, kayitliOkulNo As Boolean
    Dim xmlDosya As New XmlDocument()
    Public Sub ortalamaHesapla()
        ' Ortalama alma işlemini vize1, vize2, final textboxlarının textchangelerinden döndüreceğim için publicte metot tanımladım.
        ' Hataya düşmemesi için textchange sonrası değer tamamen silinmiş ise işlem yapılmasına izin vermedim
        ortValue = ort.OrtHesapla(CInt(txtVize1.Text), CInt(txtVize2.Text), CInt(txtFinal.Text))
        txtOrt.Text = ortValue.ToString()
    End Sub

    Public Sub ShowDatas()
        'Verileri datagridView1'e aktarmak için kullandığım metot
        con.Open()
        Dim adapter As New SqlDataAdapter("select * from ogrenci", con)
        'tablo.Clear komutu ekleme-çıkarma gibi işlemler sonrasında DataGridView'de üst üste veri binmemesi için eklendi
        tablo.Clear()
        adapter.Fill(tablo)
        bs.DataSource = tablo
        DataGridView1.DataSource = bs
        con.Close()
    End Sub

    Public Sub onlyNumbers(e)
        'onlyNumbers metodu ile ilgili textboxların keypresslerine sadece rakam ve backspace tuşuna izin verdim
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub onlyLetters(e)
        'onlyLetters metodu ile ilgili textboxların keypresslerine sadece harf, backspace ve boşluk tuşuna izin verdim
        If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub disable(tb As TextBox, secim As Integer)
        'Tek tek TextBox1.Enabled = False yazmak yerine metot tanımlıyorum
        If (secim = 1) Then
            tb.Enabled = False
        Else
            tb.Enabled = True
        End If
    End Sub

    Public Sub disableAll()
        disable(TextBox1, 1)
        disable(TextBox2, 1)
        disable(txtAd, 1)
        disable(txtSoyad, 1)
        disable(txtCinsiyet, 1)
        disable(txtMilliyet, 1)
        disable(txtDersAdi, 1)
        disable(txtVize1, 1)
        disable(txtVize2, 1)
        disable(txtFinal, 1)
        disable(txtOrt, 1) 'txtOrt DLL üzerinden değer döndürecek. Kullanıcı buraya not girmemeli
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowDatas()
        txtTC.DataBindings.Add("Text", bs, "TC")
        txtOkulNo.DataBindings.Add("Text", bs, "OkulNo")
        txtAd.DataBindings.Add("Text", bs, "Ad")
        txtSoyad.DataBindings.Add("Text", bs, "Soyad")
        txtDersAdi.DataBindings.Add("Text", bs, "DersAdi")
        txtCinsiyet.DataBindings.Add("Text", bs, "Cinsiyet")
        txtMilliyet.DataBindings.Add("Text", bs, "Milliyet")
        txtVize1.DataBindings.Add("Text", bs, "Vize1")
        txtVize2.DataBindings.Add("Text", bs, "Vize2")
        txtFinal.DataBindings.Add("Text", bs, "Final")
        txtOrt.DataBindings.Add("Text", bs, "Ortalama")
        'TextBox1.Visible = False
        'TextBox2.Visible = False
        DataGridView1.ReadOnly = True
        btnAddData.Enabled = False
        Button1.Enabled = False
        disableAll()
        '-------------------------------
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("TC", 80)
        ListView1.Columns.Add("OkulNo", 80)
        ListView1.Columns.Add("Ad", 80)
        ListView1.Columns.Add("Soyad", 80)
        ListView1.Columns.Add("Cinsiyet", 80)
        ListView1.Columns.Add("Milliyet", 80)
        ListView1.Columns.Add("Ders Adı", 80)
        ListView1.Columns.Add("Vize 1", 60)
        ListView1.Columns.Add("Vize 2", 60)
        ListView1.Columns.Add("Final", 60)
        ListView1.Columns.Add("Ortalama", 60)
        xmlDosya.Load(Application.StartupPath + "\ogrenci.xml")
    End Sub


    Private Sub btnFirstData_Click(sender As Object, e As EventArgs) Handles btnFirstData.Click
        bs.MoveFirst() 'DataGridView üzerindeki ilk kayda gitme butonu
    End Sub

    Private Sub btnNextData_Click(sender As Object, e As EventArgs) Handles btnNextData.Click
        bs.MoveNext() 'DataGridView üzerindeki bir sonraki kayda gitme butonu
    End Sub

    Private Sub btnPrevData_Click(sender As Object, e As EventArgs) Handles btnPrevData.Click
        bs.MovePrevious() 'DataGridView üzerindeki bir önceki kayda gitme butonu
    End Sub

    Private Sub btnLastData_Click(sender As Object, e As EventArgs) Handles btnLastData.Click
        bs.MoveLast() 'DataGridView üzerindeki en son kayda gitme butonu
    End Sub

    Public Sub add_update_database(islem As String)

    End Sub
    Private Sub btnAddData_Click(sender As Object, e As EventArgs) Handles btnAddData.Click
        kayitliOkulNo = False
        kayitliTC = False
        If (TextBox1.TextLength <> 11) Then 'TC Numarası 11 Hane mi ?
            MsgBox("11 Haneli TC Numarası Giriniz")
            TextBox1.Focus()
        Else 'TC Numarası 11 Haneli ise girilen tc VT'de kayıtlı mı kontrol et
            For i = 0 To DataGridView1.Rows.Count - 2 'TC 11 Hane girildiyse eğer girilen TC VT'de kayıtlı mı ?
                If (DataGridView1.Rows(i).Cells(0).Value.ToString().Equals(TextBox1.Text)) Then
                    kayitliTC = True
                    MsgBox("Kayıtlı TC Kimlik Numarası Girdiniz")
                    i = DataGridView1.Rows.Count - 2
                    TextBox1.Focus()
                End If
            Next
            If (kayitliTC = False) Then 'TC Kontrollerini geçtiyse Okul No kontrollerine girmesi lazım
                'TC Kontrollerini geçemeden okul no kontrolüne girmemesi için kayitliTC = False ile kontrole sokuyorum
                If (TextBox2.TextLength <> 10) Then 'Girilen Okul No 10 Haneli mi ?
                    MsgBox("10 Haneli Okul Numarası Giriniz")
                    TextBox2.Focus()
                Else 'Okul No 10 haneli girildiyse girilen no VT'de kayıtlı mı kontrol et
                    For i = 0 To DataGridView1.Rows.Count - 2 'Girilen okul no VT'de kayıtlı mı?
                        If (DataGridView1.Rows(i).Cells(1).Value.ToString().Equals(TextBox2.Text)) Then
                            kayitliOkulNo = True
                            MsgBox("Kayıtlı Okul No Girdiniz")
                            i = DataGridView1.Rows.Count - 1
                            TextBox2.Focus()
                        End If
                    Next
                    If (kayitliOkulNo = False) Then 'Okul No kontrollerini Ad kontrollerine gir
                        If (txtAd.Text = "" Or txtAd.Text = " ") Then 'Ad girilmiş mi ?
                            MsgBox("Ad Giriniz")
                            txtAd.Focus()
                        Else 'Ad Girilmişse Soyad kontrollerine gir
                            If (txtSoyad.Text = "" Or txtSoyad.Text = " ") Then 'Soyad girilmiş mi ?
                                MsgBox("Soyad Giriniz")
                                txtSoyad.Focus()
                            Else 'Soyad girilmişse eğer cinsiyet kontrolü yap
                                If (txtCinsiyet.Text.ToLower() <> "erkek" And txtCinsiyet.Text.ToLower() <> "kadın") Then
                                    'Girilen cinsiyet erkek veya kadın olarak mı girilmiş ?
                                    'ToLower'in amacı Erkek ERKEK erKEk vs vs vs gibi girişlerde de doğru kabul edilmesi için
                                    MsgBox("Cinsiyet Giriniz. (Erkek/Kadın)")
                                    txtCinsiyet.Focus()
                                Else 'Cinsiyet girilmişse eğer milliyet kontrolü yap
                                    If (txtMilliyet.Text.ToLower() <> "türk" And txtMilliyet.Text.ToLower() <> "yabancı") Then
                                        'Girilen milliyet türk veya yabancı dışındaysa eğer hata ver
                                        MsgBox("Milliyet Giriniz. (Türk/Yabancı)")
                                        txtMilliyet.Focus()
                                    Else 'Milliyet doğru girilmişse eğer ders adını kontrol et
                                        If (txtDersAdi.Text = "" Or txtDersAdi.Text = " ") Then
                                            MsgBox("Ders Adı Giriniz")
                                            txtDersAdi.Focus()
                                        Else
                                            Dim command As New SqlCommand("insert into ogrenci (TC,OkulNo,Ad,Soyad,Cinsiyet,Milliyet,DersAdi,Vize1,Vize2,Final,Ortalama) VALUES (@TC,@OkulNo,@Ad,@Soyad,@Cinsiyet,@Milliyet,@DersAdi,@Vize1,@Vize2,@Final,@Ortalama)", con)
                                            command.Parameters.AddWithValue("@TC", Convert.ToInt64(TextBox1.Text))
                                            command.Parameters.AddWithValue("@OkulNo", Convert.ToInt64(TextBox2.Text))
                                            command.Parameters.AddWithValue("@Ad", txtAd.Text)
                                            command.Parameters.AddWithValue("@Soyad", txtSoyad.Text)
                                            command.Parameters.AddWithValue("@Cinsiyet", txtCinsiyet.Text)
                                            command.Parameters.AddWithValue("@Milliyet", txtMilliyet.Text)
                                            command.Parameters.AddWithValue("@DersAdi", txtDersAdi.Text)
                                            command.Parameters.AddWithValue("@Vize1", Convert.ToInt16(txtVize1.Text))
                                            command.Parameters.AddWithValue("@Vize2", Convert.ToInt16(txtVize2.Text))
                                            command.Parameters.AddWithValue("@Final", Convert.ToInt16(txtFinal.Text))
                                            command.Parameters.AddWithValue("@Ortalama", Convert.ToDouble(txtOrt.Text))
                                            con.Open()
                                            command.ExecuteNonQuery()
                                            con.Close()
                                            ShowDatas()
                                            btnAddData.Enabled = False
                                            TextBox1.Clear()
                                            TextBox2.Clear()
                                            txtAd.Clear()
                                            txtSoyad.Clear()
                                            txtCinsiyet.Clear()
                                            txtMilliyet.Clear()
                                            txtDersAdi.Clear()
                                            txtVize1.Clear()
                                            txtVize2.Clear()
                                            txtFinal.Clear()
                                            txtOrt.Clear()
                                            TextBox1.Focus()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnDelData_Click(sender As Object, e As EventArgs) Handles btnDelData.Click
        Dim command As New SqlCommand("delete from ogrenci where TC=@TC", con)
        command.Parameters.AddWithValue("@TC", Convert.ToInt64(TextBox1.Text))
        con.Open()
        command.ExecuteNonQuery()
        con.Close()
        ShowDatas()
        bs.MoveFirst()
    End Sub

    Private Sub txtAd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAd.KeyPress
        onlyLetters(e)
        txtAd.MaxLength = 20
    End Sub

    Private Sub txtSoyad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSoyad.KeyPress
        onlyLetters(e)
        txtSoyad.MaxLength = 20
    End Sub

    Private Sub txtDersAdi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDersAdi.KeyPress
        onlyLetters(e)
        txtDersAdi.MaxLength = 30
    End Sub

    Private Sub txtVize1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVize1.KeyPress
        onlyNumbers(e)
        txtVize1.MaxLength = 3
    End Sub

    Private Sub txtVize2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVize2.KeyPress
        onlyNumbers(e)
        txtVize2.MaxLength = 3
    End Sub

    Private Sub txtFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFinal.KeyPress
        onlyNumbers(e)
        txtFinal.MaxLength = 3
    End Sub

    Private Sub txtCinsiyet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCinsiyet.KeyPress
        onlyLetters(e)
        txtCinsiyet.MaxLength = 5
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtVize1.TextLength <> 0) Then
            If (CInt(txtVize1.Text) > 100) Then
                MsgBox("Vize 1 Notu 100'den büyük olamaz")
                txtVize1.Clear()
                txtVize1.Focus()
            Else
                If (txtVize2.TextLength <> 0) Then
                    If (CInt(txtVize2.TextLength > 100)) Then
                        MsgBox("Vize 2 Notu 100'den büyük olamaz")
                        txtVize2.Clear()
                        txtVize2.Focus()
                    Else
                        If (txtFinal.TextLength <> 0) Then
                            If (CInt(txtFinal.Text) > 100) Then
                                MsgBox("Final Notu 100'den büyük olamaz")
                                txtFinal.Clear()
                                txtFinal.Focus()
                            Else
                                ortalamaHesapla()
                                If (TextBox1.Enabled = True) Then
                                    btnAddData.Enabled = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtTC_TextChanged(sender As Object, e As EventArgs) Handles txtTC.TextChanged
        TextBox1.Text = txtTC.Text
    End Sub

    Private Sub txtOkulNo_TextChanged(sender As Object, e As EventArgs) Handles txtOkulNo.TextChanged
        TextBox2.Text = txtOkulNo.Text
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        onlyNumbers(e)
        TextBox1.MaxLength = 11 'TC Numarasını max = 11 hane
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumbers(e)
        TextBox2.MaxLength = 10
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = True
        disable(TextBox1, 0)
        disable(TextBox2, 0)
        disable(txtAd, 0)
        disable(txtSoyad, 0)
        disable(txtCinsiyet, 0)
        disable(txtMilliyet, 0)
        disable(txtDersAdi, 0)
        disable(txtVize1, 0)
        disable(txtVize2, 0)
        disable(txtFinal, 0)
        disable(txtOrt, 0)
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        disableAll()
    End Sub

    Private Sub btnFirstData_MouseClick(sender As Object, e As MouseEventArgs) Handles btnFirstData.MouseClick
        disableAll()
    End Sub

    Private Sub btnNextData_MouseClick(sender As Object, e As MouseEventArgs) Handles btnNextData.MouseClick
        disableAll()
    End Sub

    Private Sub btnPrevData_MouseClick(sender As Object, e As MouseEventArgs) Handles btnPrevData.MouseClick
        disableAll()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        kayitliOkulNo = False
        If (kayitliTC = False) Then
            If (TextBox2.TextLength <> 10) Then
                MsgBox("10 Haneli Okul Numarası Giriniz")
                TextBox2.Focus()
            Else
                For i = 0 To DataGridView1.Rows.Count - 2
                    If (DataGridView1.Rows(i).Cells(1).Value.ToString().Equals(TextBox2.Text)) Then
                        kayitliOkulNo = True
                        MsgBox("Kayıtlı Okul No Girdiniz")
                        i = DataGridView1.Rows.Count - 1
                        TextBox2.Focus()
                    End If
                Next
                If (kayitliOkulNo = False) Then
                    If (txtAd.Text = "" Or txtAd.Text = " ") Then
                        MsgBox("Ad Giriniz")
                        txtAd.Focus()
                    Else
                        If (txtSoyad.Text = "" Or txtSoyad.Text = " ") Then
                            MsgBox("Soyad Giriniz")
                            txtSoyad.Focus()
                        Else
                            If (txtCinsiyet.Text.ToLower() <> "erkek" And txtCinsiyet.Text.ToLower() <> "kadın") Then
                                MsgBox("Cinsiyet Giriniz. (Erkek/Kadın)")
                                txtCinsiyet.Focus()
                            Else
                                If (txtMilliyet.Text.ToLower() <> "türk" And txtMilliyet.Text.ToLower() <> "yabancı") Then
                                    'Girilen milliyet türk veya yabancı dışındaysa eğer hata ver
                                    MsgBox("Milliyet Giriniz. (Türk/Yabancı)")
                                    txtMilliyet.Focus()
                                Else 'Milliyet doğru girilmişse eğer ders adını kontrol et
                                    If (txtDersAdi.Text = "" Or txtDersAdi.Text = " ") Then
                                        MsgBox("Ders Adı Giriniz")
                                        txtDersAdi.Focus()
                                    Else
                                        Dim command As New SqlCommand("update ogrenci set OkulNo=@OkulNo, Ad=@Ad, Soyad=@Soyad, Cinsiyet=@Cinsiyet, Milliyet=@Milliyet, DersAdi=@DersAdi, Vize1=@Vize1, Vize2=@Vize2, Final=@Final, Ortalama=@Ortalama where TC=@TC", con)
                                        command.Parameters.AddWithValue("@TC", Convert.ToInt64(TextBox1.Text))
                                        command.Parameters.AddWithValue("@OkulNo", Convert.ToInt64(TextBox2.Text))
                                        command.Parameters.AddWithValue("@Ad", txtAd.Text)
                                        command.Parameters.AddWithValue("@Soyad", txtSoyad.Text)
                                        command.Parameters.AddWithValue("@Cinsiyet", txtCinsiyet.Text)
                                        command.Parameters.AddWithValue("@Milliyet", txtMilliyet.Text)
                                        command.Parameters.AddWithValue("@DersAdi", txtDersAdi.Text)
                                        command.Parameters.AddWithValue("@Vize1", Convert.ToInt16(txtVize1.Text))
                                        command.Parameters.AddWithValue("@Vize2", Convert.ToInt16(txtVize2.Text))
                                        command.Parameters.AddWithValue("@Final", Convert.ToInt16(txtFinal.Text))
                                        command.Parameters.AddWithValue("@Ortalama", Convert.ToDouble(txtOrt.Text))
                                        con.Open()
                                        command.ExecuteNonQuery()
                                        con.Close()
                                        ShowDatas()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        disable(TextBox2, 0)
        disable(txtAd, 0)
        disable(txtSoyad, 0)
        disable(txtCinsiyet, 0)
        disable(txtMilliyet, 0)
        disable(txtDersAdi, 0)
        disable(txtVize1, 0)
        disable(txtVize2, 0)
        disable(txtFinal, 0)
        disable(txtOrt, 0)
        Button1.Enabled = True
    End Sub

    Public Sub XmlOlustur(node As XmlNode, ad As String, tb As TextBox, element As XmlElement)
        node = xmlDosya.CreateNode("element", ad, "")
        node.InnerText = tb.Text
        element.AppendChild(node)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim okulNo, ad, soyad, cinsiyet, milliyet, dersadi, vize1, vize2, final, ortalama As XmlNode
        bs.MoveFirst()
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim ogrenci As XmlElement = xmlDosya.CreateElement("Öğrenci")
            ogrenci.SetAttribute("TC", TextBox1.Text)
            XmlOlustur(okulNo, "OkulNo", TextBox1, ogrenci)
            XmlOlustur(ad, "Ad", txtAd, ogrenci)
            XmlOlustur(soyad, "Soyad", txtSoyad, ogrenci)
            XmlOlustur(cinsiyet, "Cinsiyet", txtCinsiyet, ogrenci)
            XmlOlustur(milliyet, "Milliyet", txtMilliyet, ogrenci)
            XmlOlustur(dersadi, "Ders_Adi", txtDersAdi, ogrenci)
            XmlOlustur(vize1, "Vize_1", txtVize1, ogrenci)
            XmlOlustur(vize2, "Vize_2", txtVize2, ogrenci)
            XmlOlustur(final, "Final", txtFinal, ogrenci)
            XmlOlustur(ortalama, "Ortalama", txtOrt, ogrenci)
            xmlDosya.DocumentElement.AppendChild(ogrenci)
            bs.MoveNext()
        Next
        xmlDosya.Save(Application.StartupPath + "\ogrenci.xml")
        MsgBox("Veriler XML Dosyasına Aktarıldı")
    End Sub

    Public Sub lvAdd(lv As ListView, kayitno As Integer, str As String)
        lv.Items(kayitno).SubItems.Add(str)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim liste As XmlNodeList = xmlDosya.GetElementsByTagName("Öğrenci")
        Dim ogrenci As XmlNode
        Dim kayitNo As Integer
        For Each ogrenci In liste
            Dim tc, okulno, ad, soyad, cinsiyet, milliyet, dersadi, vize1, vize2, final, ort As String
            tc = ogrenci.Attributes("TC").Value
            okulno = ogrenci("OkulNo").FirstChild.Value
            ad = ogrenci("Ad").FirstChild.Value
            soyad = ogrenci("Soyad").FirstChild.Value
            cinsiyet = ogrenci("Cinsiyet").FirstChild.Value
            milliyet = ogrenci("Milliyet").FirstChild.Value
            dersadi = ogrenci("Ders_Adi").FirstChild.Value
            vize1 = ogrenci("Vize_1").FirstChild.Value
            vize2 = ogrenci("Vize_2").FirstChild.Value
            final = ogrenci("Final").FirstChild.Value
            ort = ogrenci("Ortalama").FirstChild.Value
            ListView1.Items.Add(tc)
            lvAdd(ListView1, kayitNo, okulno)
            lvAdd(ListView1, kayitNo, ad)
            lvAdd(ListView1, kayitNo, soyad)
            lvAdd(ListView1, kayitNo, cinsiyet)
            lvAdd(ListView1, kayitNo, milliyet)
            lvAdd(ListView1, kayitNo, dersadi)
            lvAdd(ListView1, kayitNo, vize1)
            lvAdd(ListView1, kayitNo, vize2)
            lvAdd(ListView1, kayitNo, final)
            lvAdd(ListView1, kayitNo, ort)
            kayitNo += 1
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim excel As Excel.Application
        Dim wbook As Excel.Workbook
        Dim wsheet As Excel.Worksheet
        excel = CreateObject("Excel.Application")
        wbook = excel.Workbooks.Add
        wsheet = wbook.Worksheets(1)
        wsheet.Cells(1, 1) = "TC"
        wsheet.Cells(1, 2) = "OkulNo"
        wsheet.Cells(1, 3) = "Ad"
        wsheet.Cells(1, 4) = "Soyad"
        wsheet.Cells(1, 5) = "Cinsiyet"
        wsheet.Cells(1, 6) = "Milliyet"
        wsheet.Cells(1, 7) = "DersAdi"
        wsheet.Cells(1, 8) = "Vize1"
        wsheet.Cells(1, 9) = "Vize2"
        wsheet.Cells(1, 10) = "Final"
        wsheet.Cells(1, 11) = "Ortalama"
        For i = 1 To DataGridView1.Rows.Count - 1
            wsheet.Cells(i + 1, 1) = DataGridView1.Rows(i - 1).Cells(0).Value
            wsheet.Cells(i + 1, 2) = DataGridView1.Rows(i - 1).Cells(1).Value
            wsheet.Cells(i + 1, 3) = DataGridView1.Rows(i - 1).Cells(2).Value
            wsheet.Cells(i + 1, 4) = DataGridView1.Rows(i - 1).Cells(3).Value
            wsheet.Cells(i + 1, 5) = DataGridView1.Rows(i - 1).Cells(4).Value
            wsheet.Cells(i + 1, 6) = DataGridView1.Rows(i - 1).Cells(5).Value
            wsheet.Cells(i + 1, 7) = DataGridView1.Rows(i - 1).Cells(6).Value
            wsheet.Cells(i + 1, 8) = DataGridView1.Rows(i - 1).Cells(7).Value
            wsheet.Cells(i + 1, 9) = DataGridView1.Rows(i - 1).Cells(8).Value
            wsheet.Cells(i + 1, 10) = DataGridView1.Rows(i - 1).Cells(9).Value
            wsheet.Cells(i + 1, 11) = DataGridView1.Rows(i - 1).Cells(10).Value
        Next
        wbook.SaveAs(Application.StartupPath + "\" + TextBox3.Text + ".xlsx")
        MsgBox("Bilgiler Excel'e Aktarıldı")
    End Sub

    Private Sub btnLastData_MouseClick(sender As Object, e As MouseEventArgs) Handles btnLastData.MouseClick
        disableAll()
    End Sub

    Private Sub txtMilliyet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMilliyet.KeyPress
        onlyLetters(e)
        txtMilliyet.MaxLength = 7
    End Sub
End Class
