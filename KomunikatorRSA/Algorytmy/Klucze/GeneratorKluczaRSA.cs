using KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.LiczbyPierwsze;
using KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.ModuloOdwrotnosc;
using KomunikatorRSA.Algorytmy.Klucze.AlgorytmyBudowyKlucza.NWD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze
{
    internal sealed class GeneratorKluczaRSA : IGeneratorKluczy
    {
        private IWyznacznikNWD _algorytmNWD = new AlgorytmEuklidesa();
        private IOdwrotnoscModulo _moduloOdwrotnosc = new RozszerzonyAlgEuklidesa();   //Tutaj powinno byc wstrzykniecie zaleznosci
        private IGeneratorLiczbPierwszych _generatorLiczbyPierwszej = new GeneratorSitemEratostenesa();  

        public ParametryKlucza GenerujKlucz()
        {
            long liczbaPier1 = 0;
            long liczbaPier2 = 0;
            long modul = 0;
            long wykladnik = 43; // Przykladowo n = 43, mozna dobrac jakakolwiek inna
            long funkcjaEulera = 0;
            long liczbaOdwrotnaDoWykladnika = 0;

            while (liczbaPier1 == liczbaPier2)
            {
                liczbaPier1 = _generatorLiczbyPierwszej.Generuj();
                liczbaPier2 = _generatorLiczbyPierwszej.Generuj();
            }

            funkcjaEulera = (liczbaPier1 - 1) * (liczbaPier2 - 1);

            modul = liczbaPier1 * liczbaPier2;

            while (_algorytmNWD.Wyznacz(wykladnik, funkcjaEulera) != 1)
            {
                wykladnik += 2;
            }

            liczbaOdwrotnaDoWykladnika = _moduloOdwrotnosc.Oblicz(wykladnik, funkcjaEulera);

            return new ParametryKlucza(wykladnik, liczbaOdwrotnaDoWykladnika, modul);
        }
    }
}
