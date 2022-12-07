Imports System.Xml
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'XML Dosyasıyla ilgili fiziksel bağlantıyı kurar ve üzerinde işlem yapılacak diğer nesneleri oluşturur.
        Dim dosya As New XmlDocument
        dosya.Load(Application.StartupPath + "\ogrenci.xml")

        'Yeni bir Veri Yapısı (Satır oluşturur)
        Dim ogren As XmlElement = dosya.CreateElement("ogren")
        ogren.SetAttribute("kimlik", TextBox1.Text)

        'Yeni bir alt veri Yapısı (Satıra ait Sütun Oluşturur.
        Dim tc As XmlNode = dosya.CreateNode("element", "tc", "")
        tc.InnerText = TextBox2.Text
        ogren.AppendChild(tc)
        Dim ad As XmlNode = dosya.CreateNode("element", "ad", "")
        ad.InnerText = TextBox3.Text
        ogren.AppendChild(ad)
        Dim soyad As XmlNode = dosya.CreateNode("element", "soyad", "")
        soyad.InnerText = TextBox4.Text
        ogren.AppendChild(soyad)
        Dim adres As XmlNode = dosya.CreateNode("element", "adres", "")
        adres.InnerText = TextBox5.Text
        ogren.AppendChild(adres)
        Dim dersad As XmlNode = dosya.CreateNode("element", "dersad", "")
        dersad.InnerText = TextBox6.Text
        ogren.AppendChild(dersad)
        Dim vize As XmlNode = dosya.CreateNode("element", "vize", "")
        vize.InnerText = TextBox7.Text
        ogren.AppendChild(vize)
        Dim final As XmlNode = dosya.CreateNode("element", "final", "")
        final.InnerText = TextBox8.Text
        ogren.AppendChild(final)
        Dim sonuc As XmlNode = dosya.CreateNode("element", "sonuc", "")
        sonuc.InnerText = TextBox9.Text
        ogren.AppendChild(sonuc)
        dosya.DocumentElement.AppendChild(ogren)
        dosya.Save(Application.StartupPath + "\ogrenci.xml")

    End Sub
End Class
