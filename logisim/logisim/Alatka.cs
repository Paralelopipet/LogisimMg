using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika_ba
{
    public class Alatka
    {
        static Alatka alatka;
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
        public virtual Komponenta NapraviObjekat(int x, int y)
        {
            return alatka.NapraviObjekat(x, y);
        }
        public virtual string Text()
        {
            return "Nema nista";
        }
    }
    public class AlatkaI : Alatka
    {
        static AlatkaI alatkai = new AlatkaI();
        public override Komponenta NapraviObjekat(int x, int y)
        {
            x = x - x % 20 + (x % 20) / 10 * 20;
            y = y - y % 20 + (y % 20) / 10 * 20;
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
    public class AlatkaIli : Alatka
    {
        static AlatkaIli alatkaili = new AlatkaIli();

        public override Komponenta NapraviObjekat(int x, int y)
        {
            x = x - x % 20 + (x % 20) / 10 * 20;
            y = y - y % 20 + (y % 20) / 10 * 20;
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

        public override Komponenta NapraviObjekat(int x, int y)
        {
            x += 10; y += 10;
            x = x - x % 20 + (x % 20) / 10 * 20 - 10;
            y = y - y % 20 + (y % 20) / 10 * 20 - 10;
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
}