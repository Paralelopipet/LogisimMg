using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika_ba
{
    static class Trenutna_komponenta
    {
        static Komponenta tren;
        static int pomx;
        static int pomy;
        public static bool dodavanje;
        public static Komponenta Tren
        {
            get
            {
                return tren;
            }
            set
            {
                tren = value;
            }
        }
        public static int Pomx
        {
            get
            {
                return pomx-tren.X;
            }
            set
            {
                pomx = value;
            }
        }
        public static int Pomy
        {
            get
            {
                return pomy-tren.Y;
            }
            set
            {
                pomy = value;
            }
        }
        public static List<Tacka> Oblast(int clickedx, int clickedy)
        {
            int xstaro = tren.X, ystaro = tren.Y;
            Trenutna_komponenta.Tren.Privremena_Pozicija(clickedx, clickedy, Trenutna_komponenta.Pomx, Trenutna_komponenta.Pomy);
            List<Tacka> tacke = tren.Oblast();
            tren.X = xstaro;
            tren.Y = ystaro;
            return tacke;
        }
    }
}
