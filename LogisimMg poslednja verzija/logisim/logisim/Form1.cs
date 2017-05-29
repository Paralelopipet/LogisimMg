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
        int pocx, pocy;
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
                        bry++;
                    }
                    brx++;
                    bry = 0;
                }
            }
        }
        public List<Komponenta> komponente = new List<Komponenta>();

        public Form1()
        {
            InitializeComponent();
        }
        public void Refreshh()
        {
            pictureBox1.Refresh();
            
        }

        Ili k;
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTreeView();
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
            //Alatka.Al = AlatkaI.getAlatka();
            //label1.Text = "I alatka";
        }

        private void Ilipic_Click(object sender, EventArgs e)
        {
            //Alatka.Al = AlatkaIli.getAlatka();
            //label1.Text = "Ili alatka";
        }
        private void lanpic_Click(object sender, EventArgs e)
        {
            //Alatka.Al = AlatkaLampica.getAlatka();
            //label1.Text = "Lampica alatka";
        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Trenutna_komponenta.Tren == null)
            {
                if (Alatka.Al != null)
                {
                    if (Alatka.Al.Text() != "Dodat Cvor")
                    {
                        komponente.Add(Alatka.Al.NapraviObjekat(e.X, e.Y, cellSize));
                        listBox1.Items.Add(Alatka.Al.Text());
                    }
                    else
                    {
                        Zica nova=null, stara=null;

                        while (e.X >= pocx + cellSize / 2)
                        {
                            listBox1.Items.Add(Alatka.Al.Text());
                            nova = (Zica)Alatka.Al.NapraviObjekat(pocx, pocy, cellSize);
                            komponente.Add(nova);
                            if (stara != null)
                            {
                                nova.levo = stara;
                                stara.desno = nova;
                            }
                            stara = nova;
                            pocx += cellSize;
                        }

                        while (e.X <= pocx - cellSize / 2)
                        {
                            listBox1.Items.Add(Alatka.Al.Text());
                            nova = (Zica)Alatka.Al.NapraviObjekat(pocx, pocy, cellSize);
                            komponente.Add(nova);
                            if (stara != null)
                            {
                                nova.desno = stara;
                                stara.levo = nova;
                            }
                            stara = nova;
                            pocx -= cellSize;
                        }

                        while (e.Y >= pocy + cellSize / 2)
                        {
                            listBox1.Items.Add(Alatka.Al.Text());
                            nova = (Zica)Alatka.Al.NapraviObjekat(pocx, pocy, cellSize);
                            komponente.Add(nova);
                            if (stara != null)
                            {
                                nova.gore = stara;
                                stara.dole = nova;
                            }
                            stara = nova;
                            pocy += cellSize;
                            
                        }
                        while (e.Y <= pocy - cellSize / 2)
                        {
                            listBox1.Items.Add(Alatka.Al.Text());
                            nova = (Zica)Alatka.Al.NapraviObjekat(pocx, pocy, cellSize);
                            komponente.Add(nova);
                            if (stara != null)
                            {
                                nova.dole = stara;
                                stara.gore = nova;
                            }
                            stara = nova;
                            pocy -= cellSize;
                            
                        }
                    }
                    
                }
            }
            else 
            {
                bool DaLi = false;
                foreach (Komponenta k in komponente)
                {
                    if (k.Is_Clicked(e.X, e.Y, cellSize) == true)
                    {
                        DaLi = true;
                    }
                }
                if (!DaLi)
                {
                    Trenutna_komponenta.Tren.Promeni_Poziciju(e.X, e.Y, Trenutna_komponenta.Pomx, Trenutna_komponenta.Pomy);
                    pictureBox1.Refresh();
                    
                }
                Trenutna_komponenta.Tren = null;
            }
            Refreshh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Trenutna_komponenta.dodavanje = true;
            foreach (Komponenta k in komponente)
            {
                if (k.Is_Clicked(e.X,e.Y,cellSize) == true)
                {
                    Trenutna_komponenta.dodavanje = false;
                    Trenutna_komponenta.Tren = k;
                    //if (Alatka.Al.Text()=="Ruka")
                    //{
                        Trenutna_komponenta.Pomx = e.X;
                        Trenutna_komponenta.Pomy = e.Y;
                    //}
                    /*if (Alatka.Al.Text() == "Pali")
                    {
                        Zica m = (Zica)k;
                        if(m.vrednost==-1|| m.vrednost == 0)
                        {
                            m.PromeniVrednost(1, "");
                        }
                        else
                        {
                            m.PromeniVrednost(0, "");
                        }
                        
                        Trenutna_komponenta.Pomx = e.X;
                        Trenutna_komponenta.Pomy = e.Y;
                    }*/

                }
            }
            if(Trenutna_komponenta.dodavanje = true&&Alatka.Al.Text()== "Dodat Cvor")
            {
                pocx = e.X;
                pocy = e.Y;
                //komponente.Add(Alatka.Al.NapraviObjekat(e.X, e.Y, cellSize));
                //listBox1.Items.Add(Alatka.Al.Text());
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Trenutna_komponenta.Tren != null)
            {
                int x = Trenutna_komponenta.Tren.X;
                int y = Trenutna_komponenta.Tren.Y;
                Trenutna_komponenta.Tren.Privremena_Pozicija(e.X, e.Y, Trenutna_komponenta.Pomx, Trenutna_komponenta.Pomy);
                pictureBox1.Refresh();
                Trenutna_komponenta.Tren.X=x;
                Trenutna_komponenta.Tren.Y=y;
                
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeTreeView()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Kola");
            treeView1.Nodes.Add("Zica");
            treeView1.Nodes.Add("Ruka");
            treeView1.Nodes.Add("Pali");
            treeView1.Nodes[0].Nodes.Add("Pokazivaci");
            treeView1.Nodes[0].Nodes.Add("Kola");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("LED");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("I");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Ili");
            //treeView1.Nodes[0].Nodes[1].Nodes[0]
            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.Text=="LED")
            {
                Alatka.Al = AlatkaLampica.getAlatka();
                label1.Text = "Lampica alatka";
            }

            if (treeView1.SelectedNode.Text == "Ili")
            {
                Alatka.Al = AlatkaIli.getAlatka();
                label1.Text = "Ili alatka";
            }

            if (treeView1.SelectedNode.Text == "I")
            {
                Alatka.Al = AlatkaI.getAlatka();
                label1.Text = "I alatka";
            }

            if (treeView1.SelectedNode.Text == "Zica")
            {
                Alatka.Al = AlatkaZica.getAlatka();
                label1.Text = "Zica alatka";
            }

            if (treeView1.SelectedNode.Text == "Ruka")
            {
                Alatka.Al = AlatkaRuka.getAlatka();
                label1.Text = "Ruka";
            }

            if (treeView1.SelectedNode.Text == "Pali")
            {
                Alatka.Al = AlatkaPali.getAlatka();
                label1.Text = "Pali";
            }


        }


        /* MOOOORAAAAAAAAAMMMMMMMMMMMMM*/














    }
}