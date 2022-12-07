using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basari
{
    public class ogrenci
    {
        public string ortalama(int vize1, int vize2, int final)
        {
            string a;
            double ortalama;
            ortalama = ((vize1 * 0.2) + ((vize2 * 0.2) + (final * 0.6)));
            if (ortalama > 50)
                a = "Geçti";
            else
                a = "Kaldı";
            return a;
        }
    }
}
