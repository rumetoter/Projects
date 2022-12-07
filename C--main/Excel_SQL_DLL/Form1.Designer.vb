<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtTC = New System.Windows.Forms.TextBox()
        Me.txtOkulNo = New System.Windows.Forms.TextBox()
        Me.txtAd = New System.Windows.Forms.TextBox()
        Me.txtSoyad = New System.Windows.Forms.TextBox()
        Me.txtDersAdi = New System.Windows.Forms.TextBox()
        Me.txtVize1 = New System.Windows.Forms.TextBox()
        Me.txtVize2 = New System.Windows.Forms.TextBox()
        Me.txtFinal = New System.Windows.Forms.TextBox()
        Me.txtOrt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnFirstData = New System.Windows.Forms.Button()
        Me.btnNextData = New System.Windows.Forms.Button()
        Me.btnPrevData = New System.Windows.Forms.Button()
        Me.btnLastData = New System.Windows.Forms.Button()
        Me.btnAddData = New System.Windows.Forms.Button()
        Me.btnDelData = New System.Windows.Forms.Button()
        Me.txtCinsiyet = New System.Windows.Forms.TextBox()
        Me.txtMilliyet = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1143, 276)
        Me.DataGridView1.TabIndex = 0
        '
        'txtTC
        '
        Me.txtTC.Location = New System.Drawing.Point(1055, 320)
        Me.txtTC.Name = "txtTC"
        Me.txtTC.Size = New System.Drawing.Size(100, 20)
        Me.txtTC.TabIndex = 1
        '
        'txtOkulNo
        '
        Me.txtOkulNo.Location = New System.Drawing.Point(1055, 346)
        Me.txtOkulNo.Name = "txtOkulNo"
        Me.txtOkulNo.Size = New System.Drawing.Size(100, 20)
        Me.txtOkulNo.TabIndex = 2
        '
        'txtAd
        '
        Me.txtAd.Location = New System.Drawing.Point(94, 346)
        Me.txtAd.Name = "txtAd"
        Me.txtAd.Size = New System.Drawing.Size(100, 20)
        Me.txtAd.TabIndex = 3
        '
        'txtSoyad
        '
        Me.txtSoyad.Location = New System.Drawing.Point(94, 372)
        Me.txtSoyad.Name = "txtSoyad"
        Me.txtSoyad.Size = New System.Drawing.Size(100, 20)
        Me.txtSoyad.TabIndex = 4
        '
        'txtDersAdi
        '
        Me.txtDersAdi.Location = New System.Drawing.Point(94, 450)
        Me.txtDersAdi.Name = "txtDersAdi"
        Me.txtDersAdi.Size = New System.Drawing.Size(100, 20)
        Me.txtDersAdi.TabIndex = 7
        '
        'txtVize1
        '
        Me.txtVize1.Location = New System.Drawing.Point(94, 476)
        Me.txtVize1.Name = "txtVize1"
        Me.txtVize1.Size = New System.Drawing.Size(100, 20)
        Me.txtVize1.TabIndex = 8
        '
        'txtVize2
        '
        Me.txtVize2.Location = New System.Drawing.Point(94, 502)
        Me.txtVize2.Name = "txtVize2"
        Me.txtVize2.Size = New System.Drawing.Size(100, 20)
        Me.txtVize2.TabIndex = 9
        '
        'txtFinal
        '
        Me.txtFinal.Location = New System.Drawing.Point(94, 528)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtFinal.TabIndex = 10
        '
        'txtOrt
        '
        Me.txtOrt.Location = New System.Drawing.Point(94, 554)
        Me.txtOrt.Name = "txtOrt"
        Me.txtOrt.Size = New System.Drawing.Size(100, 20)
        Me.txtOrt.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "TC Numarası"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 323)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Okul Numarası"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 375)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Soyad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 401)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Cinsiyet"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 427)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Milliyet"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 453)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Ders Adı"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 479)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Vize 1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 505)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Vize 2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 531)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Final"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 557)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Ortalama"
        '
        'btnFirstData
        '
        Me.btnFirstData.Location = New System.Drawing.Point(229, 294)
        Me.btnFirstData.Name = "btnFirstData"
        Me.btnFirstData.Size = New System.Drawing.Size(100, 23)
        Me.btnFirstData.TabIndex = 24
        Me.btnFirstData.Text = "İlk Kayıt"
        Me.btnFirstData.UseVisualStyleBackColor = True
        '
        'btnNextData
        '
        Me.btnNextData.Location = New System.Drawing.Point(229, 323)
        Me.btnNextData.Name = "btnNextData"
        Me.btnNextData.Size = New System.Drawing.Size(100, 23)
        Me.btnNextData.TabIndex = 25
        Me.btnNextData.Text = "Sonraki Kayıt"
        Me.btnNextData.UseVisualStyleBackColor = True
        '
        'btnPrevData
        '
        Me.btnPrevData.Location = New System.Drawing.Point(229, 352)
        Me.btnPrevData.Name = "btnPrevData"
        Me.btnPrevData.Size = New System.Drawing.Size(100, 23)
        Me.btnPrevData.TabIndex = 26
        Me.btnPrevData.Text = "Önceki Kayıt"
        Me.btnPrevData.UseVisualStyleBackColor = True
        '
        'btnLastData
        '
        Me.btnLastData.Location = New System.Drawing.Point(229, 381)
        Me.btnLastData.Name = "btnLastData"
        Me.btnLastData.Size = New System.Drawing.Size(100, 23)
        Me.btnLastData.TabIndex = 27
        Me.btnLastData.Text = "Son Kayıt"
        Me.btnLastData.UseVisualStyleBackColor = True
        '
        'btnAddData
        '
        Me.btnAddData.Location = New System.Drawing.Point(94, 673)
        Me.btnAddData.Name = "btnAddData"
        Me.btnAddData.Size = New System.Drawing.Size(100, 23)
        Me.btnAddData.TabIndex = 28
        Me.btnAddData.Text = "EKLE"
        Me.btnAddData.UseVisualStyleBackColor = True
        '
        'btnDelData
        '
        Me.btnDelData.Location = New System.Drawing.Point(94, 731)
        Me.btnDelData.Name = "btnDelData"
        Me.btnDelData.Size = New System.Drawing.Size(100, 23)
        Me.btnDelData.TabIndex = 29
        Me.btnDelData.Text = "SİL"
        Me.btnDelData.UseVisualStyleBackColor = True
        '
        'txtCinsiyet
        '
        Me.txtCinsiyet.Location = New System.Drawing.Point(94, 398)
        Me.txtCinsiyet.Name = "txtCinsiyet"
        Me.txtCinsiyet.Size = New System.Drawing.Size(100, 20)
        Me.txtCinsiyet.TabIndex = 5
        '
        'txtMilliyet
        '
        Me.txtMilliyet.Location = New System.Drawing.Point(94, 424)
        Me.txtMilliyet.Name = "txtMilliyet"
        Me.txtMilliyet.Size = New System.Drawing.Size(100, 20)
        Me.txtMilliyet.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(94, 580)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Ortalama Hesapla"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(94, 294)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 31
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(94, 320)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 615)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(291, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Ekleme ve güncelleme işlemi için önce ortalama hesaplayınız"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(94, 644)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 23)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "YENİ KAYIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(94, 702)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 23)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "GÜNCELLE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(229, 450)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 23)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "XML'e AKTAR"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(355, 320)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(805, 163)
        Me.ListView1.TabIndex = 37
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(569, 294)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 23)
        Me.Button5.TabIndex = 38
        Me.Button5.Text = "XML'den OKU"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(229, 479)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(100, 23)
        Me.Button6.TabIndex = 39
        Me.Button6.Text = "EXCEL'e AKTAR"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(229, 505)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 40
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 820)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDelData)
        Me.Controls.Add(Me.btnAddData)
        Me.Controls.Add(Me.btnLastData)
        Me.Controls.Add(Me.btnPrevData)
        Me.Controls.Add(Me.btnNextData)
        Me.Controls.Add(Me.btnFirstData)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOrt)
        Me.Controls.Add(Me.txtFinal)
        Me.Controls.Add(Me.txtVize2)
        Me.Controls.Add(Me.txtVize1)
        Me.Controls.Add(Me.txtDersAdi)
        Me.Controls.Add(Me.txtMilliyet)
        Me.Controls.Add(Me.txtCinsiyet)
        Me.Controls.Add(Me.txtSoyad)
        Me.Controls.Add(Me.txtAd)
        Me.Controls.Add(Me.txtOkulNo)
        Me.Controls.Add(Me.txtTC)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtTC As TextBox
    Friend WithEvents txtOkulNo As TextBox
    Friend WithEvents txtAd As TextBox
    Friend WithEvents txtSoyad As TextBox
    Friend WithEvents txtDersAdi As TextBox
    Friend WithEvents txtVize1 As TextBox
    Friend WithEvents txtVize2 As TextBox
    Friend WithEvents txtFinal As TextBox
    Friend WithEvents txtOrt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnFirstData As Button
    Friend WithEvents btnNextData As Button
    Friend WithEvents btnPrevData As Button
    Friend WithEvents btnLastData As Button
    Friend WithEvents btnAddData As Button
    Friend WithEvents btnDelData As Button
    Friend WithEvents txtCinsiyet As TextBox
    Friend WithEvents txtMilliyet As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents TextBox3 As TextBox
End Class
