using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logika_ba
{
    public partial class Form1 : Form
    {
        int cellSize = 20;
        class Tacka
        {
            int x;
            int y;
            int stanje;
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
            public Tacka(int x,int y)
            {
                this.x = x;
                this.y = y;
                this.stanje = 0;
                this.pov = new povezanost();
            }
            static Tacka[,] MatricaTacaka; 
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
            public static void napuni_matricu(int height,int width, int cellsize)
            {
                int brx = 0;
                int bry = 0;
                Tacka.t=new Tacka[width/cellsize+1,height/cellsize+1];
                for (int dx = 0; dx <= width; dx += cellsize)
                {
                    for (int dy = 0; dy <= height; dy += cellsize)
                    {
                        Tacka.t[brx,bry] = new Tacka(dx + cellsize / 2, dy + cellsize / 2);
                      //  MessageBox.Show(Tacka.t[brx,bry].x.ToString() + " " + Tacka.t[brx,bry].y.ToString());
                        brx++;
                    }
                    bry++;
                    brx = 0;
                }
            }
        }
        public List<Komponenta> komponente = new List<Komponenta>();

        public Form1()
        {
            InitializeComponent();
        }
        Ili k;
        private void Form1_Load(object sender, EventArgs e)
        {
            Komponenta lampica = new Lampica(10, 10);
            k = new Ili(60, 60);
            k.Dodaj(lampica, 1);
            Tacka.napuni_matricu(pictureBox1.Height, pictureBox1.Width, cellSize);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Silver);
            for (int x = 0; x < pictureBox1.Width; x+=cellSize)
            {
                for (int y = 0; y < pictureBox1.Height; y += cellSize)
                {
                    g.DrawEllipse(p, x+cellSize/2, y+cellSize/2, 1, 1);
                }
            }
            foreach (var k in komponente)
            {
                k.Nacrtaj(g);
            }
            //k.Nacrtaj(g);
        }
        Ili ili;
        I i;
        Lampica lampica;
        private void Ipic_Paint_1(object sender, PaintEventArgs e)
        {
            i = new I(40, 40);
            i.Nacrtaj(e.Graphics);
        }

        private void Ilipic_Paint(object sender, PaintEventArgs e)
        {
            ili = new Ili(40, 40);
            ili.Nacrtaj(e.Graphics);
        }
        
        private void lanpic_Paint(object sender, PaintEventArgs e)
        {
            lampica = new Lampica(40, 40);
            lampica.Nacrtaj(e.Graphics);
        }

        private void Ipic_Click(object sender, EventArgs e)
        {
            Alatka.Al = AlatkaI.getAlatka();
            label1.Text = "I alatka";
        }

        private void Ilipic_Click(object sender, EventArgs e)
        {
            Alatka.Al = AlatkaIli.getAlatka();
            label1.Text = "Ili alatka";
        }
        private void lanpic_Click(object sender, EventArgs e)
        {
            Alatka.Al = AlatkaLampica.getAlatka();
            label1.Text = "Lampica alatka";
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Alatka.Al != null)
            {
                komponente.Add(Alatka.Al.NapraviObjekat(e.X, e.Y));
                listBox1.Items.Add(Alatka.Al.Text());
                pictureBox1.Refresh();

            }
        }

      
        

        

        

        

        

        

        






    }
}