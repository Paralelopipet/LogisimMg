using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace logika_ba
{
    class Drvo
    {
        List<Drvo> grane = new List<Drvo>();

        public void dodajGranu(Drvo a)
        {
            grane.Add(a);
        }
        string Ime;
    }

    class Objekti:Drvo
    {
        string Ime;
        public void klik()
        {
         //   Kompone
        }

    }

}
