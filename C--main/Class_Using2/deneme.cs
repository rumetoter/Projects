using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class deneme
    {
        public int kare(int sayi1)
        {
            return (sayi1 * sayi1);
        }
        public double pisayisi(int sayi1)
        {
            return (sayi1 * 3.14 / 2);
        }
        public double ortalama(int vize, int final)
        {
            return ((vize * 0.4) + (final * 0.6));
        }
        public double ucgen(int tabanalani, int yukseklik)
        {
            return (tabanalani * yukseklik / 2);
        }
        public int kare (int kenar1, int kenar2)
        {
            return (kenar1 * kenar2);
        }
    }
}
