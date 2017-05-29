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
    }
}
