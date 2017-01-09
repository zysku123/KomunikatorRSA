using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.ModuloOdwrotnosc
{
    internal interface IOdwrotnoscModulo
    {
        long Oblicz(long a, long n);
    }
}
