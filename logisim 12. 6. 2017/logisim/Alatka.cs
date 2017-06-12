using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika_ba
{
    public class Alatka
    {
        public static Alatka alatka;
        public static Alatka Al
        {
            get
            {
                return alatka;
            }
            set
            {
                alatka = value;
            }
        }
        public virtual Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            return alatka.NapraviObjekat(x, y, CellSize);
        }
        public static Alatka getAlatka()
        {
            return alatka;
        }
        public virtual string Text()
        {
            return "Nema nista";
        }
    }
    public class AlatkaI : Alatka
    {
        static AlatkaI alatkai = new AlatkaI();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize - 2;
             
            Komponenta I = new I(x, y);
             for (int i = 0; i < 4; i++)
             {
                 if (i == 2) ips++;
                 Tacka tac = Tacka.t[iks-1, ips + i];
                 tac.izlaz = false;
                 tac.komp = I;
                 tac.broj = i;
             }
             Tacka tacc = Tacka.t[iks + 3, ips + 1];
             tacc.izlaz = true;
             tacc.komp = I;
             tacc.broj = 1;
             
             return I;
        }
        public static Alatka getAlatka()
        {
            return alatkai;
        }

        public override string Text()
        {
            return "Dodato I";
        }
    }

    public class AlatkaNe : Alatka
    {
        static AlatkaNe alatkaNe = new AlatkaNe();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize;

            Komponenta NE = new Ne(x, y);

            Tacka tac = Tacka.t[iks - 1, ips];
            tac.izlaz = false;
            tac.komp = NE;
            tac.broj = 0;

            Tacka tacc = Tacka.t[iks + 1, ips];
            tacc.izlaz = true;
            tacc.komp = NE;
            tacc.broj = 0;

            return NE;
        }
        public static Alatka getAlatka()
        {
            return alatkaNe;
        }

        public override string Text()
        {
            return "Dodato Ne";
        }
    }

    public class AlatkaNI : Alatka
    {
        static AlatkaNI alatkani = new AlatkaNI();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize - 2;

            Komponenta NI = new NI(x, y);
            for (int i = 0; i < 4; i++)
            {
                if (i == 2) ips++;
                Tacka tac = Tacka.t[iks - 1, ips + i];
                tac.izlaz = false;
                tac.komp = NI;
                tac.broj = i;
            }
            Tacka tacc = Tacka.t[iks + 3, ips + 1];
            tacc.izlaz = true;
            tacc.komp = NI;
            tacc.broj = 1;
            return NI;
        }
        public static Alatka getAlatka()
        {
            return alatkani;
        }

        public override string Text()
        {
            return "Dodato NI";
        }
    }

    public class AlatkaDes : Alatka
    {
        static AlatkaDes alatkaDes = new AlatkaDes();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            
            return null;
        }
        public void Unisti(int x, int y,Form1 form1)
        {
            Komponenta pom = null;
            CetiriUlaza.Normalizuj(Form1.CellSize, ref x, ref y);
            foreach (Komponenta komp in Form1.komponente)
            {
                foreach (var tacka in komp.Oblast())
                {
                    if (tacka.X == x && tacka.Y == y)
                    {
                        pom = komp;
                        break;
                    }
                }
            }

            pom.Uklanjanje(form1);
            Form1.komponente.Remove(pom);

        }

        public static AlatkaDes getAlatka()
        {
            return alatkaDes;
        }

        public override string Text()
        {
            return "Izbacena komponenta";
        }
    }


    public class AlatkaZica : Alatka
    {
        static AlatkaZica alatkazica = new AlatkaZica();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            return new Zica();
        }

        public Komponenta NapraviObjekatZica(PZica p)
        {
            return new Zica(p);
        }
        public Komponenta NapraviPZicu(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            return new PZica(x, y);
        }
        public static Alatka getAlatka()
        {
            return alatkazica;
        }
        public override string Text()
        {
            return "Dodata Zica";
        }
    }


    

    public class AlatkaIli : Alatka
    {
        static AlatkaIli alatkaili = new AlatkaIli();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize - 2;

            Komponenta ILI = new Ili(x, y);
            for (int i = 0; i < 4; i++)
            {
                if (i == 2) ips++;
                Tacka tac = Tacka.t[iks - 1, ips + i];
                tac.izlaz = false;
                tac.komp = ILI;
                tac.broj = i;
            }
            Tacka tacc = Tacka.t[iks + 3, ips + 1];
            tacc.izlaz = true;
            tacc.komp = ILI;
            tacc.broj = 1;
            return ILI;
        }
        public static Alatka getAlatka()
        {
            return alatkaili;
        }
        public override string Text()
        {
            return "Dodato Ili";
        }
    }

    public class AlatkaNIli : Alatka
    {
        static AlatkaNIli alatkanili = new AlatkaNIli();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize - 2;

            Komponenta NILI = new NIli(x, y);
            for (int i = 0; i < 4; i++)
            {
                if (i == 2) ips++;
                Tacka tac = Tacka.t[iks - 1, ips + i];
                tac.izlaz = false;
                tac.komp = NILI;
                tac.broj = i;
            }
            Tacka tacc = Tacka.t[iks + 3, ips + 1];
            tacc.izlaz = true;
            tacc.komp = NILI;
            tacc.broj = 1;
            return NILI;
        }
        public static Alatka getAlatka()
        {
            return alatkanili;
        }
        public override string Text()
        {
            return "Dodato Nili";
        }
    }

    public class AlatkaIzvor : Alatka
    {
        static AlatkaIzvor alatkaizvor = new AlatkaIzvor();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);

            int iks = (x - CellSize / 2) / CellSize;
            int ips = (y - CellSize / 2) / CellSize - 2;
            Komponenta IZVOR = new Izvor(x, y);
            Tacka tacc = Tacka.t[iks, ips +1];
            tacc.izlaz = true;
            tacc.komp = IZVOR;
            tacc.broj = 1;
            return IZVOR;
        }
        public static Alatka getAlatka()
        {
            return alatkaizvor;
        }
        public override string Text()
        {
            return "Dodat Izvor()";
        }
    }

    public class AlatkaKlok : Alatka
    {
        static AlatkaKlok alatkaizvor = new AlatkaKlok();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            x += CellSize / 2; y += CellSize / 2;
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            return new Klok(x, y);
        }
        public static Alatka getAlatka()
        {
            return alatkaizvor;
        }
        public override string Text()
        {
            return "Dodat Izvor()";
        }
    }

    public class AlatkaLampica : Alatka
    {
        static AlatkaLampica alatkalampica = new AlatkaLampica();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            x += CellSize / 2; y += CellSize / 2;
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            return new Lampica(x, y);
        }
        public static Alatka getAlatka()
        {
            return alatkalampica;
        }
        public override string Text()
        {
            return "Dodata lampica";
        }
    }
}