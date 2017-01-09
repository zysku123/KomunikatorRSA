using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Komunikacja
{
    internal class Serwer : ISerwer
    {
        public void Uruchom(IPEndPoint host, Func<string, string> obslugaRequestFunc)
        {
            byte[] bytes = new Byte[1024];

            Socket listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            string dane = null;

            try
            {
                listener.Bind(host);
                listener.Listen(10);

                while (true)
                {
                    Socket handler = listener.Accept();

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        dane += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if (obslugaRequestFunc != null)
                            dane = obslugaRequestFunc(dane);

                        break;
                    }

                    byte[] msg = Encoding.ASCII.GetBytes(dane);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
