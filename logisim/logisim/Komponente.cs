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
        public abstract bool Vrednost
        {
            get;

        }
        public abstract void Nacrtaj(Graphics g);

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
        public override void Nacrtaj(Graphics g)
        {
            g.FillEllipse(new SolidBrush(c), x - CellSize/4, y - CellSize/4, CellSize/2, CellSize/2);
        }
        public void PromeniBoju()
        {
            c = Color.Green;
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

    }
}