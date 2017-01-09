using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Komunikacja
{
    internal interface IKlient
    {
        string Polacz(string wiadomosc, IPEndPoint host, Func<string, string> obslugaResponseFunc);
    }
}
