using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika_ba
{
    public class Tacka
    {
        int x;
        int y;
        int stanje;
        public bool? izlaz;
        public int broj;
        public Komponenta komp;

        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        class povezanost
        {
            bool levo;
            bool desno;
            bool gore;
            bool dole;
            public povezanost()
            {
                this.levo = false;
                this.desno = false;
                this.gore = false;
                this.dole = false;
            }
        };
        povezanost pov;
        public Tacka(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.stanje = 0;
            this.pov = new povezanost();
        }
        public static Tacka[,] MatricaTacaka;
        public static Tacka[,] t
        {
            get
            {
                return MatricaTacaka;
            }
            set
            {
                MatricaTacaka = value;
            }
        }
        public static void napuni_matricu(int height, int width, int cellsize)
        {
            int brx = 0;
            int bry = 0;
            Tacka.t = new Tacka[width / cellsize + 1, height / cellsize + 1];
            for (int dx = 0; dx <= width; dx += cellsize)
            {
                for (int dy = 0; dy <= height; dy += cellsize)
                {
                    Tacka.t[brx, bry] = new Tacka(dx + cellsize / 2, dy + cellsize / 2);
                    //  MessageBox.Show(Tacka.t[brx,bry].x.ToString() + " " + Tacka.t[brx,bry].y.ToString());
                    bry++;
                }
                brx++;
                bry = 0;
            }
        }

    }
}
