using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Logika_ba
{
    //komponenta crni = new komponenta(10, 2.5, black);
    public struct tocka
    {
        public int x, y;
        public tocka(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

   
    public abstract class Komponenta
    {
        protected int x, y;
        protected Tacka t;
        public Komponenta[] b;
        public Komponenta(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Komponenta()
        {

        }
        public virtual int label
        {
            get { return 0; }
        }
        public abstract void Dodaj(Komponenta k, int n);

        public static int CellSize
        {
            get
            {
                return Form1.CellSize;
            }
        }
        public abstract List<Tacka> Oblast();
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
        public virtual void Napravi_Slider(Form1 form)
        { }
        public virtual void Uklanjanje(Form1 form1)
        { }
        public static void Normalizuj(int CellSize, ref int x, ref int y)
        {
            x += CellSize / 2; y += CellSize / 2;
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
        }

    }
    public class Izvor : Komponenta
    {
        Color c = Color.Red;
        public Izvor(int x, int y)
            : base(x, y)
        {
            this.vrednost = false;
        }
        public override void Dodaj(Komponenta k, int n){}
        bool? vrednost=false;
        public void PromeniVrednost()
        {
            if ((bool)vrednost)
            {
                vrednost = false;
                c = Color.Red;
            }
            else
            {
                vrednost = true;
                c = Color.Green;
            }
        }
        public override bool Vrednost
        {
            get
            {
                return (bool)vrednost;
            }
        }
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            tacke.Add(new Tacka(this.x,this.y));
            tacke.Add(new Tacka(this.x, this.y-CellSize));
            return tacke;
        }
        
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka=new Pen(Color.Black);
            g.FillEllipse(new SolidBrush(c), X - CellSize/4, Y - CellSize/4, CellSize/2, CellSize/2);
            g.DrawLine(cetka, new Point(x, y - CellSize / 4), new Point(x, y - CellSize));
            g.DrawLine(cetka, new Point(X - CellSize / 4, Y - CellSize/4), new Point(X - CellSize/4, Y + CellSize/4));
            g.DrawLine(cetka, new Point(X - CellSize / 4, Y - CellSize / 4), new Point(X + CellSize / 4, Y - CellSize / 4));
            g.DrawLine(cetka, new Point(X + CellSize / 4, Y + CellSize / 4), new Point(X - CellSize / 4, Y + CellSize / 4));
            g.DrawLine(cetka, new Point(X + CellSize / 4, Y + CellSize / 4), new Point(X + CellSize / 4, Y - CellSize / 4));
        }
        
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y)) return true;
            //if ((clickedx == this.x) && (clickedy == this.y - CellSize)) return true;
            else return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            clickedx -= pomx;
            clickedy -= pomy;
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if (this.x == clickedx && this.y == clickedy) this.PromeniVrednost();
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
    }
    public abstract class TikKomponenta:Komponenta
    {
        protected int lambda;
        protected TrackBar mojtrack;
        public TrackBar Mojtrack
        {
            get { return mojtrack; }
        }
        static int mojy = 957;
        protected static int mojx = 36;
        public TikKomponenta(int x, int y)
            : base(x, y)
        {
            lambda = 1;
            Form1.Tikkomponente.Add(this);
            if(Form1.debug)MessageBox.Show(Form1.Tikkomponente.Count.ToString());
        }
        public int Lambda
        {
            get
            {
                return this.lambda;
            }
        }
        public abstract void PromeniVrednost();
        public override void Napravi_Slider(Form1 form1)
        {
            TrackBar trackbar= new TrackBar();
            trackbar.Location = new Point(mojy,mojx);
            this.mojtrack = trackbar;
            mojx += 50;
            form1.Controls.Add(trackbar);
            mojtrack.Scroll += delegate 
            {
                lambda = mojtrack.Value + 1;
                //MessageBox.Show(lambda.ToString());
            };
        }
    }

    public class Klok : TikKomponenta
    {
        Color c = Color.Red;
        public Klok(int x, int y)
            : base(x, y)
        {
            this.vrednost = false;
        }
        public override void Dodaj(Komponenta k, int n) { }
        bool? vrednost = false;
        public override void PromeniVrednost()
        {
            if ((bool)vrednost)
            {
                vrednost = false;
                c = Color.Red;
            }
            else
            {
                vrednost = true;
                c = Color.Green;
            }
        }
        public override bool Vrednost
        {
            get
            {
                return (bool)vrednost;
            }
        }
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            tacke.Add(new Tacka(this.x, this.y));
            tacke.Add(new Tacka(this.x, this.y-CellSize));
            return tacke;
        }

        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            if (Vrednost)
            {
                
                g.FillRectangle(new SolidBrush(c), X - CellSize / 8, Y - CellSize / 4, CellSize / 4, CellSize / 2);
            }
            g.FillRectangle(new SolidBrush(c), X - CellSize / 4, Y - CellSize / 8, CellSize / 2, CellSize / 4);
            g.DrawLine(cetka, new Point(x, y - CellSize / 4), new Point(x, y - CellSize));
            g.DrawLine(cetka, new Point(X - CellSize / 4, Y - CellSize / 4), new Point(X - CellSize / 4, Y + CellSize / 4));
            g.DrawLine(cetka, new Point(X - CellSize / 4, Y - CellSize / 4), new Point(X + CellSize / 4, Y - CellSize / 4));
            g.DrawLine(cetka, new Point(X + CellSize / 4, Y + CellSize / 4), new Point(X - CellSize / 4, Y + CellSize / 4));
            g.DrawLine(cetka, new Point(X + CellSize / 4, Y + CellSize / 4), new Point(X + CellSize / 4, Y - CellSize / 4));
        }

        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y)) return true;
            if ((clickedx == this.x) && (clickedy == this.y - CellSize)) return true;
            else return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            clickedx -= pomx;
            clickedy -= pomy;
            Klok.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            this.Promeni_Poziciju(clickedx,clickedy,pomx,pomy);
        }
        public override void Uklanjanje(Form1 form1)
        {
            bool b = false;
            TikKomponenta pom=null;
            foreach(TikKomponenta komp in Form1.Tikkomponente)
            {
                if (b)
                {
                    if(pom!=null)
                    komp.Mojtrack.Location = pom.Mojtrack.Location;

                }
                if (komp == this)
                {
                    b = true;
                }
                
                
                pom = komp;
            }
            form1.Controls.Remove(this.Mojtrack);
            Form1.Tikkomponente.Remove(this);
            mojx -= 50;
        }
    }


    public class Lampica : Komponenta
    {
        Color c = Color.Red;
        public Lampica(int x, int y)
            : base(x, y)
        {
            this.vrednost = false;
        }
        public override void Dodaj(Komponenta k, int n) { }
        bool? vrednost = false;
        public void PostaviVrednost(Zica zica)
        {
            vrednost = zica.Vrednost;
            if ((bool)vrednost)
                c = Color.Green;
            else
            {
                c = Color.Red;

            }
        }
        public override bool Vrednost
        {
            get
            {
                return (bool)vrednost;
            }
        }
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            tacke.Add(new Tacka(this.x, this.y));
            tacke.Add(new Tacka(this.x, this.y-CellSize));
            return tacke;
        }

        public override void Nacrtaj(Graphics g)
        {
            g.FillEllipse(new SolidBrush(c), x - CellSize / 4, y - CellSize / 4, CellSize / 2, CellSize / 2);
            g.DrawLine(new Pen(Color.Black),new Point(x,y-CellSize/4),new Point(x,y-CellSize));
        }
        
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            return false;
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y)) return true;
            if ((clickedx == this.x) && (clickedy == this.y-CellSize)) return true;
            
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            clickedx -= pomx;
            clickedy -= pomy;
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
        public override void Dodaj(Komponenta k, int n)
        {
            this.b[n] = k;
        }
         public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            //(clickx > x - CellSize && clickx < x + 4 * CellSize && clicky < y + 2 * CellSize && clicky > y - 2 * CellSize)
            for (int i = -1; i <=3; i++)
                for (int j = -2; j <= 2; j++)
                {
                    tacke.Add(new Tacka(this.x+CellSize*i, this.y+CellSize*j));
                }
            return tacke;
        }
        public override bool Is_Clicked(int clickx, int clicky, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref clickx, ref clicky);
            if (clickx > x - CellSize && clickx < x + 4 * CellSize && clicky < y + 2 * CellSize && clicky > y - 2 * CellSize)
            {
                if (clicky == y && clickx == x + 3*CellSize) return false;
                MessageBox.Show(clickx.ToString());
                return true;
            }
            return false;
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
            g.DrawPie(cetka, x-3*CellSize/2, y - 2*CellSize, 4*CellSize, 4*CellSize, -90, 180);
            g.DrawRectangle(cetka, x-CellSize/2, y - 2*CellSize, CellSize, 4*CellSize);
            g.DrawLine(cetka, new Point(x-CellSize/2, y - 2 * CellSize), new Point(x - CellSize, y - 2 * CellSize));
            g.DrawLine(cetka, new Point(x-CellSize / 2, y - CellSize), new Point(x - CellSize, y - CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + CellSize), new Point(x - CellSize, y + CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x - CellSize, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x + 5*CellSize / 2, y), new Point(x + 6*CellSize/2, y));
            g.DrawLine(new Pen(Color.White), new Point(x + CellSize / 2, y - 2 * CellSize), new Point(x + CellSize / 2, y + 2 * CellSize));
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
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x - CellSize / 2, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x + 5 * CellSize / 2, y));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x + 5 * CellSize / 2, y));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x - CellSize, y - 2 * CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - CellSize), new Point(x - CellSize, y - CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + CellSize), new Point(x - CellSize, y + CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x - CellSize, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x + 5 * CellSize / 2, y), new Point(x + 6 * CellSize / 2, y));
           
        }
    }

    public class NIli : CetiriUlaza
    {
        public NIli(int x, int y)
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
                    return !(bool)vrednost;


            }
        }
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x - CellSize / 2, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x + 5 * CellSize / 2, y));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x + 5 * CellSize / 2, y));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x - CellSize, y - 2 * CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - CellSize), new Point(x - CellSize, y - CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + CellSize), new Point(x - CellSize, y + CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x - CellSize, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x + 5 * CellSize / 2 + CellSize / 3, y), new Point(x + 6 * CellSize / 2, y));
            g.DrawEllipse(cetka, x + 5 * CellSize / 2, y - CellSize / 6, CellSize / 3, CellSize / 3);

        }
    }

    public class NI : CetiriUlaza
    {
        public NI(int x, int y)
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
                    return !(bool)vrednost;
            }
        }
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            g.DrawPie(cetka, x - 3 * CellSize / 2, y - 2 * CellSize, 4 * CellSize, 4 * CellSize, -90, 180);
            g.DrawRectangle(cetka, x - CellSize / 2, y - 2 * CellSize, CellSize, 4 * CellSize);
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - 2 * CellSize), new Point(x - CellSize, y - 2 * CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - CellSize), new Point(x - CellSize, y - CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + CellSize), new Point(x - CellSize, y + CellSize));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y + 2 * CellSize), new Point(x - CellSize, y + 2 * CellSize));
            g.DrawLine(cetka, new Point(x + 5 * CellSize / 2+CellSize/3, y), new Point(x + 6 * CellSize / 2, y));
            g.DrawEllipse(cetka, x + 5 * CellSize / 2, y-CellSize/6, CellSize/3,CellSize/3);
            g.DrawLine(new Pen(Color.White), new Point(x + CellSize / 2, y - 2 * CellSize), new Point(x + CellSize / 2, y + 2 * CellSize));
        }
    }


    public class Ne : Komponenta
    {
        Komponenta k;
        public Ne(int x, int y)
            : base(x, y)
        {

        }
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            tacke.Add(new Tacka(this.x, this.y));
            tacke.Add(new Tacka(this.x - CellSize, this.y));
            tacke.Add(new Tacka(this.x + CellSize, this.y));
            return tacke;
        }
        public override bool Vrednost
        {
            get
            {
                return !k.Vrednost;

            }
        }
        
        public void Dodaj(Komponenta k)
        {
            this.k = k;
        }
        public override void Dodaj(Komponenta k, int n) { }
        public override void Nacrtaj(Graphics g)
        {
            Pen cetka = new Pen(Color.Black);
            
            g.DrawLine(cetka, new Point(x +CellSize / 3, y), new Point(x + CellSize, y));
            g.DrawLine(cetka, new Point(x - CellSize, y), new Point(x -CellSize/2, y));
            g.DrawLine(cetka, new Point(x - CellSize/2, y+CellSize/3), new Point(x, y));
            g.DrawLine(cetka, new Point(x - CellSize/2, y-CellSize/3), new Point(x, y));
            g.DrawLine(cetka, new Point(x - CellSize / 2, y - CellSize / 3), new Point(x - CellSize / 2, y + CellSize / 3));
            g.DrawEllipse(cetka, x, y-CellSize/6, CellSize / 3, CellSize / 3);
           
        }
        public override bool Is_Clicked(int clickx, int clicky, int CellSize)
        {
            
            if (clickx >= x - CellSize && clickx <= x + CellSize && clicky > y-CellSize/2 && clicky <y+CellSize/2)
            {
                
                //if (clickx == x + 2*CellSize && clicky == y) return false;
                return true;
            }
            return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            clickedx -= pomx;
            clickedy -= pomy;
            CetiriUlaza.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
        }
    }

    public class Zica : Komponenta
    {
        Color c = Color.Blue;
        Komponenta ka;
        public bool greska = false;
        public Zica(int x, int y)
            : base(x, y)
        {
            this.vrednost = false;
        }
        public override void Dodaj(Komponenta k, int n) { }
        public Zica(PZica p)
        {
            greska = false;
            Komponenta k = null;
            foreach (tocka to in p.tocke)
            {
                this.tocke.Add(to);
                int iks = (to.x - CellSize / 2) / CellSize;
                int ips = (to.y - CellSize / 2) / CellSize;
                if (Tacka.t[iks, ips].izlaz == true)
                {
                    MessageBox.Show("a");
                    if (k != null) greska = true;
                    k = Tacka.t[iks, ips].komp;
                    ka = k;
                }

            }
            if (k != null && greska != true)
            {
                foreach (tocka to in p.tocke)
                {
                    int iks = (to.x - CellSize / 2) / CellSize;
                    int ips = (to.y - CellSize / 2) / CellSize;
                    if (Tacka.t[iks, ips].izlaz == false)
                    {
                        //Tacka
                        Tacka.t[iks, ips].komp.Dodaj(k, Tacka.t[iks, ips].broj);

                    }
                }

            }

            Form1.komponente.RemoveAt(Form1.komponente.Count - 1);

            //this.vrednost = false;
        }
        List<tocka> tocke = new List<tocka>();
        public Zica() { }
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
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            //tacke.Add(new Tacka(this.x, this.y));
            return tacke;
        }
        
        public override void Nacrtaj(Graphics g)
        {
            if (ka!=null&&ka.Vrednost == true) c = Color.Red; else c = Color.Black;
            for (int i = 0; i < tocke.Count; i++)
            {
                //g.FillEllipse(new SolidBrush(c), tocke[i].x - CellSize / 4, tocke[i].y - CellSize / 4, CellSize / 2, CellSize / 2);
                if (i < tocke.Count - 1) g.DrawLine(new Pen(c), tocke[i].x - CellSize / 4, tocke[i].y - CellSize / 4, tocke[i + 1].x - CellSize / 4, tocke[i + 1].y - CellSize / 4);
            }
        }
        public void PromeniBoju()
        {
            if (c == Color.Blue)
                c = Color.Green;
            else
                c = Color.Blue;
        }
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y))  return true;
            if ((clickedx == this.x) && (clickedy == this.y - CellSize)) return true;
            else return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {

            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
        }
    }

    public class PZica : Komponenta
    {
        Color c = Color.Black;

        public List<tocka> tocke = new List<tocka>();

        public override int label
        {
            get { return 1; }
        }

        public PZica(int x, int y)
        {
            tocke.Add(new tocka(x, y));
        }
        public override void Dodaj(Komponenta k, int n) { }
        bool? vrednost;

        public void Update(int x, int y)
        {
            if (tocke.Count == 1)
            {
                if (tocke[0].x != x || tocke[0].y != y)
                {
                    tocke.Add(new tocka(x, y));
                }
            }
            else
            {
                if (tocke[tocke.Count - 1].x != x)
                {
                    if (tocke[tocke.Count - 2].x == x)
                    {
                        tocke.RemoveAt(tocke.Count - 1);
                    }
                    else
                    {
                        tocke.Add(new tocka(x, tocke[tocke.Count - 1].y));
                    }
                }
                else
                {
                    if (tocke[tocke.Count - 1].y != y)
                    {
                        if (tocke[tocke.Count - 2].y == y)
                        {
                            tocke.RemoveAt(tocke.Count - 1);
                        }
                        else
                        {
                            tocke.Add(new tocka(tocke[tocke.Count - 1].x, y));
                        }
                    }

                }
            }
        }

        public override bool Vrednost
        {
            get
            {
                return (bool)vrednost;
            }
        }
        public override List<Tacka> Oblast()
        {
            List<Tacka> tacke = new List<Tacka>();
            tacke.Add(new Tacka(this.x, this.y));
            return tacke;
        }

        public override void Nacrtaj(Graphics g)
        {
            for (int i = 0; i < tocke.Count; i++)
            {
                //g.FillEllipse(new SolidBrush(c), tocke[i].x - CellSize / 4, tocke[i].y - CellSize / 4, CellSize / 2, CellSize / 2);
                if (i < tocke.Count - 1) g.DrawLine(new Pen(c), tocke[i].x - CellSize / 4, tocke[i].y - CellSize / 4, tocke[i + 1].x - CellSize / 4, tocke[i + 1].y - CellSize / 4);
            }

        }
        public void PromeniBoju()
        {
            if (c == Color.Blue)
                c = Color.Green;
            else
                c = Color.Blue;
        }
        public override bool Is_Clicked(int clickedx, int clickedy, int CellSize)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            if ((clickedx == this.x) && (clickedy == this.y)) return true;
            else return false;
        }
        public override void Promeni_Poziciju(int clickedx, int clickedy, int pomx, int pomy)
        {
            Izvor.Normalizuj(CellSize, ref clickedx, ref clickedy);
            this.x = clickedx;
            this.y = clickedy;
        }
        public override void Privremena_Pozicija(int clickedx, int clickedy, int pomx, int pomy)
        {
            Promeni_Poziciju(clickedx, clickedy, pomx, pomy);
        }
    }
}