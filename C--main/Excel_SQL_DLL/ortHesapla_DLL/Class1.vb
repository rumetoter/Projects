Public Class Hesaplama
    Dim vize1 As Integer
    Dim vize2 As Integer
    Dim final As Integer

    Function OrtHesapla(vize1, vize2, final) As Double
        Dim ortalama As Double = (vize1 * 2 / 10) + (vize2 * 2 / 10) + (final * 6 / 10)
        Return ortalama
    End Function

End Class
