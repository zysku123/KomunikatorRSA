using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.ModuloOdwrotnosc
{
    internal sealed class RozszerzonyAlgEuklidesa : IOdwrotnoscModulo
    {
        public long Oblicz(long a, long n)
        {
            long a0, n0, p0, p1, q, r, t;

            p0 = 0; p1 = 1; a0 = a; n0 = n;
            q = n0 / a0;
            r = n0 % a0;
            while (r > 0)
            {
                t = p0 - q * p1;
                if (t >= 0)
                    t = t % n;
                else
                    t = n - ((-t) % n);

                p0 = p1;
                p1 = t;
                n0 = a0;
                a0 = r;
                q = n0 / a0;
                r = n0 % a0;
            }
            return p1;
        }
    }
}
