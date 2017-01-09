using KomunikatorRSA.Algorytmy.Klucze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy
{
    internal interface IAlgorytmyAsymetryczne<TValue, TKey>
    {
        string Szyfruj(TValue dane, TKey parametryKlucza = default(TKey));
        string Deszyfruj(TValue dane, TKey parametryKlucza = default(TKey));

        ParametryKlucza? Klucz { get;  }
    }
}
