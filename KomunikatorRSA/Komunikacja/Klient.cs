using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Komunikacja
{
    internal class Klient : IKlient
    {
        public string Polacz(string wiadomosc, IPEndPoint host, Func<string, string> obslugaResponseFunc)
        {
            byte[] bytes = new byte[1024];
            string dane = null;

            try
            {
                Socket sender = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(host);

                byte[] msg = Encoding.ASCII.GetBytes(wiadomosc);

                int bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytes);
                dane = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                if (obslugaResponseFunc != null)
                    dane = obslugaResponseFunc(dane);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

            return dane;
        }
    }
}
