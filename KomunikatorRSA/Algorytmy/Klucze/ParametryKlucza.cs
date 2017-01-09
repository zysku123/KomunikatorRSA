using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorRSA.Algorytmy.Klucze
{
    internal struct ParametryKlucza
    {
        private readonly long _czescPubliczna;
        public long CzescPubliczna
        {
            get { return _czescPubliczna; }
        }
        private readonly long _czescPrywatna;
        public long CzescPrywatna
        {
            get { return _czescPrywatna; }
        }
        private readonly long _modul;
        public long Modul
        {
            get { return _modul; }
        }
        public ParametryKlucza(long czescPubliczna, long czescPrywatna, long modul )
        {
            _czescPubliczna = czescPubliczna;
            _czescPrywatna = czescPrywatna;
            _modul = modul;
        }
    }
}
