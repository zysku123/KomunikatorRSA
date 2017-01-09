using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.NWD
{
    internal sealed class AlgorytmEuklidesa : IWyznacznikNWD
    {
        public long Wyznacz(long LiczbaA, long LiczbaB)
        {
            long tmp;

            while (LiczbaB != 0)
            {
                tmp = LiczbaB;
                LiczbaB = LiczbaA % LiczbaB;
                LiczbaA = tmp;
            };

            return LiczbaA;
        }
    }
}
