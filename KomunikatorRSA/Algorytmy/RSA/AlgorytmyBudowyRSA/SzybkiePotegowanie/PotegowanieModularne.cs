using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.RSA.AlgorytmyBudowyRSA.SzybkiePotegowanie
{
    internal sealed class PotegowanieModularne : ISzybkiePotegowanie
    {
        public long Oblicz(long a1, long b1, long m1)
        {
            long i;
            //Wartosci wychodzili poza zakres long przy potegowaniu dlago nalezalo
            //uzyc typu nieograniczonego BigInteger.
            BigInteger a = a1;
            BigInteger b = b1;
            BigInteger m = m1;
            BigInteger result = 1;
            BigInteger x = a % m;

            for (i = 1; i <= b; i <<= 1)
            {
                x %= m;
                if ((b & i) != 0)
                {
                    result *= x;
                    result %= m;
                }
                x *= x;
            }

            return (long)result;
        }
    }
}
