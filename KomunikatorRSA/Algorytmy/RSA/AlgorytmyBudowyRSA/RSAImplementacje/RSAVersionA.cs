using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.RSA.AlgorytmyBudowyRSA.RSAImplementacje
{
    internal class RSAVersionA : AlgorytmRSA
    {
        protected override string KodujWiadmosc(string blok)
        {
            string kodBloku = string.Empty;
            
            foreach (var elem in blok)
            {
                //dodaje 100 aby przy deszyfrowaniu nie bylo problemow z rozną dlugoscia kodow ASCII
                kodBloku += (int)elem + 100;
            }

            return kodBloku;
        }

        protected override string ParsujNaDane(long deszyfr)
        {
            string ciagDeszyfrujacy = deszyfr.ToString();

            string result = "";

            for (int i = 0; i < ciagDeszyfrujacy.Count(); i += 3)
            {
                int liczba = int.Parse(ciagDeszyfrujacy.Substring(i, 3)) - 100;
                result += (char)liczba;
            }

            return result;
        }

        protected override string UtworzBlok(string dane, int indeks, int dlBloku)
        {
            string blok = string.Empty;
            int dlCiaguWejscia = dane.Count();

            if (indeks + dlBloku < dlCiaguWejscia)
                blok = dane.Substring(indeks, dlBloku);
            else
                blok = dane.Substring(indeks, dlCiaguWejscia - indeks);

            int dlugoscBloku = blok.Count();

            //dodaje puste znaki dla ostatniego bloku dla wyrownania
            if (dlugoscBloku < dlBloku)
                for (int i = 0; i < dlBloku - dlugoscBloku; i++)
                    blok += " ";

            return blok;
        }
    }
}
