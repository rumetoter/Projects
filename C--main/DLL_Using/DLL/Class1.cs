using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class hesaplama
    {
        public double ortalama(int vize1, int vize2, int final)
        {
            return ((vize1 * 0.2) + (vize2 * 0.2) + (final * 0.6));
        }
    }
}
