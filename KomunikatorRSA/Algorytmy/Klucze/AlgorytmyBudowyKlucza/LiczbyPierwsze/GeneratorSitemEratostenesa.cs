using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.LiczbyPierwsze
{
    internal sealed class GeneratorSitemEratostenesa : IGeneratorLiczbPierwszych
    {
        public long Generuj()
        {
            Random r = new Random();

            int liczba = r.Next(20000000, 50000000);
            bool jestPierwsza = false;

            while (!jestPierwsza)
            {
                jestPierwsza = SprawdzCzyJestPierwsza(--liczba);
            }

            return liczba;
        }

        private bool SprawdzCzyJestPierwsza(long liczba)
        {
            if (liczba == 2)
                return true;
            else if (liczba == 1 || liczba % 2 == 0)
                return false;

            double pierwiastek = Math.Sqrt(liczba);

            for (int i = 3; i < pierwiastek; i += 2)
            {
                if (liczba % i == 0)
                    return false;
            }
            return true;

        }
    }
}
