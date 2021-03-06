﻿using System;
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
        //public string labela="prazno";
        public virtual Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            return alatka.NapraviObjekat(x, y, CellSize);
        }
        public virtual string Text()
        {
            return "Nema nista";
        }
    }
    public class AlatkaI : Alatka
    {
        //public string labela = "I";
        static AlatkaI alatkai = new AlatkaI();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            return new I(x, y);
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

    /*public class AlatkaZica : Alatka
    {
        static AlatkaZica alatkazica = new AlatkaZica();
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            return new I(x, y);
        }
        public static Alatka getAlatka()
        {
            return alatkazica;
        }

        public override string Text()
        {
            return "Dodata Zica";
        }
    }*/

    public class AlatkaZica : Alatka
    {
        static AlatkaZica alatkazica = new AlatkaZica();
        public int pocx, pocy;
        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            x += CellSize / 2; y += CellSize / 2;
            x = x - x % CellSize + (x % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            y = y - y % CellSize + (y % CellSize) / (CellSize / 2) * CellSize - (CellSize / 2);
            return new Zica(x, y);
        }
        public static Alatka getAlatka()
        {
            return alatkazica;
        }
        public override string Text()
        {
            return "Dodat Cvor";
        }
    }

    public class AlatkaIli : Alatka
    {
        static AlatkaIli alatkaili = new AlatkaIli();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            CetiriUlaza.Normalizuj(CellSize, ref x, ref y);
            return new Ili(x, y);
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

    public class AlatkaLampica : Alatka
    {
        static AlatkaLampica alatkalampica = new AlatkaLampica();

        public override Komponenta NapraviObjekat(int x, int y, int CellSize)
        {
            x += CellSize/2; y += CellSize/2;
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
            return "Dodata Tacka()";
        }
    }

    public class AlatkaRuka : Alatka
    {
        static AlatkaRuka alatkaruka = new AlatkaRuka();
        public static Alatka getAlatka()
        {
            return alatkaruka;
        }
        public override string Text()
        {
            return "Ruka";
        }
    }
    public class AlatkaPali : Alatka
    {
        static AlatkaPali alatkapali = new AlatkaPali();
        public static Alatka getAlatka()
        {
            return alatkapali;
        }
        public override string Text()
        {
            return "Pali";
        }
    }
}