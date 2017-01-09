using KomunikatorRSA.Algorytmy.Klucze;
using KomunikatorRSA.Algorytmy.RSA.AlgorytmyBudowyRSA.SzybkiePotegowanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.RSA
{
    internal abstract class AlgorytmRSA : IAlgorytmyAsymetryczne<string, ParametryKlucza>
    {
        //Tutaj powinno byc wstrzykniecie zaleznosci
        private IGeneratorKluczy _generatorKluczy = new GeneratorKluczaRSA(); 
        private ISzybkiePotegowanie _szybkiePotegowanie = new PotegowanieModularne(); 

        protected abstract string UtworzBlok(string dane, int indeks, int dlBloku);
        protected abstract string KodujWiadmosc(string blok);
        protected abstract string ParsujNaDane(long deszyfr);

        public ParametryKlucza? Klucz { get; private set; }

        public string Szyfruj(string dane, ParametryKlucza parametryKlucza = default(ParametryKlucza))
        {
            // Ustalam na sztywno blok dlugosci 5
            int dlBloku = 5;
            int indeks = 0;
            int dlCiaguWejscia = dane.Count();
            string szyfr = string.Empty;

            Klucz = JestDomyslny(parametryKlucza)
                    ? _generatorKluczy.GenerujKlucz()
                    : parametryKlucza;

            while (indeks < dlCiaguWejscia )
            {
                string blok = UtworzBlok(dane, indeks, dlBloku);

                string kodBloku = KodujWiadmosc(blok);

                szyfr += _szybkiePotegowanie.Oblicz(
                    long.Parse(kodBloku),
                    Klucz.Value.CzescPubliczna, Klucz.Value.Modul) + " ";

                indeks += dlBloku;
            }

            return szyfr;
        }

        public string Deszyfruj(string szyfr, ParametryKlucza parametryKlucza = default(ParametryKlucza))
        {
            string dane = "";
            string[] kody = szyfr.TrimEnd().Split(' ');

            if( !JestDomyslny( parametryKlucza))
                Klucz = parametryKlucza;

            if ( Klucz == null)
            {
                 throw new ArgumentException("Klucz nie zostal ustawiony");
            }

            foreach (var kod in kody)
            {
                long deszyfr = _szybkiePotegowanie.Oblicz(
                    long.Parse(kod.ToString()),
                    Klucz.Value.CzescPrywatna, Klucz.Value.Modul);

                dane += ParsujNaDane(deszyfr);
            }
            return dane;
        }

        private bool JestDomyslny(ParametryKlucza klucz)
        {
            return klucz.Equals(default(ParametryKlucza));
        }
    }
}
