using KomunikatorRSA.Algorytmy;
using KomunikatorRSA.Algorytmy.Klucze;
using KomunikatorRSA.Algorytmy.RSA;
using KomunikatorRSA.Algorytmy.RSA.AlgorytmyBudowyRSA.RSAImplementacje;
using KomunikatorRSA.Komunikacja;
using System;
using System.Net;
using System.Threading.Tasks;

namespace KomunikatorRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            IKlient klient = new Klient();
            ISerwer serwer = new Serwer();

            IAlgorytmyAsymetryczne<string, ParametryKlucza> rsa = new RSAVersionA();

            Task taskA = Task.Factory.StartNew(() => serwer.Uruchom(
                Host,
                wiadomosc =>
                {
                    string szyfr = rsa.Szyfruj(wiadomosc, KluczPubliczny);
                    Console.WriteLine("Wiadosc zaszyfrowana : " + szyfr);
                    return szyfr;
                }));

            Task<string> taskB = new Task<string>(() => klient.Polacz(
                "To jest super tajna wiadomosc",
                Host,
                wiadomosc =>
                {
                    string deszyfr = rsa.Deszyfruj(wiadomosc, _KluczPrywatny);
                    Console.WriteLine("Wiadosc odszyfrowana : " + deszyfr);
                    return wiadomosc;
                }));

            taskB.Start();

            Console.ReadKey();
        }

        private static IGeneratorKluczy _generatorKluczy = new GeneratorKluczaRSA();
        private static ParametryKlucza _KluczPrywatny = _generatorKluczy.GenerujKlucz();
        private static IPEndPoint Host = PobierzHost();
        private static ParametryKlucza KluczPubliczny => UstawKluczPubliczny();

        private static IPEndPoint PobierzHost()
        {
            IPHostEntry _hostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress _adressIP = _hostInfo.AddressList[0];
            return new IPEndPoint(_adressIP, 11000);
        }
        private static ParametryKlucza UstawKluczPubliczny() => new ParametryKlucza(_KluczPrywatny.CzescPubliczna, 0, _KluczPrywatny.Modul);

    }
}