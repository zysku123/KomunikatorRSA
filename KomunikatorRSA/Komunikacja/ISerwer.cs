using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Komunikacja
{
    internal interface ISerwer
    {
        void Uruchom(IPEndPoint host, Func<string, string> obslugaRequestFunc);
    }
}
