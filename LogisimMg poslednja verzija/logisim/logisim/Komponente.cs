using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Logika_ba
{
    public abstract class Komponenta
    {
        protected int x, y;
        protected int CellSize=20;
        public Komponenta(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return this.x; }
            set { x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { y = value; }
        }
        public abstract bool Vrednost
        {
            get;

        }
        public abstract void Nacrtaj(Graphics g);
        public abstract bool Is_Clicked(int clickedx, int clickedy, int CellSize);
        public abstract void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy);
        public abstract void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy);


    }
    public class Lampica : Komponenta
    {
        Color c = Color.Red;
        public Lampica(int x, int y)
            : base(x, y)
        {
            this.vrednost = false;
        }
        bool? vrednost;
        public void PromeniVrednost()
        {
            if ((bool)vrednost)
                vrednost = false;
            else
                vrednost = true;
        }
        public override bool Vrednost
        {
            get
            {
                return (bool)vrednost;
            }
        }
        public static void Normalizuj(int CellSize, ref int x, ref int y)
        {
            x += CellSize / 2; y += CellSize / 2;
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
        }
        public override void Nacrtaj(Graphics g)
        {
            g.FillEllipse(new SolidBrush(c), x - CellSize/4, y - CellSize/4, CellSize/2, CellSize/2);
        }
        public void PromeniBoju()
        {
            c = Color.Green;
        }
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            Lampica.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y)) return true;
            else return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            Lampica.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
        }
    }
    public abstract class CetiriUlaza : Komponenta
    {
        protected Komponenta[] b = new Komponenta[4];
        public CetiriUlaza(int x, int y)
            : base(x, y)
        {

        }
        public void Dodaj(Komponenta k, int n)
        {
            this.b[n] = k;
        }
        public override bool Is_Clicked(int clickx, int clicky, int CellSize)
        {
            if (clickx > x - CellSize && clickx < x + 4 * CellSize && clicky < y + 2 * CellSize && clicky > y - 2 * CellSize)
            {
                return true;
            }
            return false;
        }
        public static void Normalizuj(int CellSize, ref int x, ref int y)
        {
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize;
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy,int pomx, int pomy)
        {
            clickedx -= pomx;
            clickedy -= pomy;
            CetiriUlaza.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            int x=this.x;
            int y=this.y;
            Form1 myform = new Form1();
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
            
        }
    }

    public class I : CetiriUlaza
    {
        public I(int x, int y)
            : base(x, y) { }
        public override bool Vrednost
        {
            get
            {
                bool? vrednost = null;
                foreach (Komponenta item in b)
                {
                    if (item != null)
                    {
                        if (vrednost == null)
                            vrednost = item.Vrednost;
                        else
                        {
                            if ((bool)vrednost && item.Vrednost)
                            {
                                vrednost = true;
                            }
                            else
                                vrednost = false;
                        }
                    }
                }
                if (vrednost == null)
                    return false;
                else
                    return (bool)vrednost;
            }
        }
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            g.DrawPie(cetka, x, y - 2*CellSize, 4*CellSize, 4*CellSize, -90, 180);
            g.DrawRectangle(cetka, x, y - 2*CellSize, 2*CellSize, 4*CellSize);
            g.DrawLine(new Pen(Color.White), new Point(x + 2 * CellSize, y - 2 * CellSize), new Point(x + 2 * CellSize, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x, y - 3 * CellSize / 2), new Point(x - CellSize / 2, y - 3 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y - CellSize / 2), new Point(x - CellSize / 2, y - 1 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y + CellSize / 2), new Point(x - CellSize / 2, y + 1 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y + 3 * CellSize / 2), new Point(x - CellSize / 2, y + 3 * CellSize / 2));
        }
    }

    public class Ili : CetiriUlaza
    {
        public Ili(int x, int y)
            : base(x, y)
        {

        }
        public override bool Vrednost
        {
            get
            {
                bool? vrednost = null;
                foreach (Komponenta item in b)
                {
                    if (item != null)
                    {
                        if (vrednost == null)
                            vrednost = item.Vrednost;
                        else
                        {
                            if ((bool)vrednost || item.Vrednost)
                            {
                                vrednost = true;
                            }
                            else
                                vrednost = false;
                        }
                    }
                }
                if (vrednost == null)
                    return false;
                else
                    return (bool)vrednost;


            }
        }
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            g.DrawPie(cetka, x - 4*CellSize , y - 2*CellSize , 8* CellSize , 8*CellSize , -90, 60);
            g.DrawPie(cetka, x - 4 * CellSize, y - 6*CellSize , 8 * CellSize, 8 * CellSize, +90, -60);
            g.DrawLine(cetka, new Point(x, y - 3 * CellSize / 2), new Point(x - CellSize / 2, y - 3 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y - CellSize / 2), new Point(x - CellSize / 2, y - 1 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y + CellSize / 2), new Point(x - CellSize / 2, y + 1 * CellSize / 2));
            g.DrawLine(cetka, new Point(x, y + 3 * CellSize / 2), new Point(x - CellSize / 2, y + 3 * CellSize / 2));
        }
    }

    public class Ne : Komponenta
    {
        Komponenta k;
        public Ne(int x, int y)
            : base(x, y)
        {

        }
        public override bool Vrednost
        {
            get
            {
                return !Vrednost;

            }
        }
        public void Dodaj(Komponenta k)
        {
            this.k = k;
        }
        public override void Nacrtaj(Graphics g)
        {

        }
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            throw new NotImplementedException();
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
            this.x = clickedx;
            this.y = clickedy;
        }
    }
}