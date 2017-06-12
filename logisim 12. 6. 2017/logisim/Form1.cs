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
        
        static public int CellSize = 20;
        static public int Vreme = 0;
        bool dodavanjeZice = false;
        bool mousedown;
        static public bool debug;
        static public List<Komponenta> komponente = new List<Komponenta>();
        static public List<TikKomponenta> Tikkomponente = new List<TikKomponenta>();
        public Form1()
        {
            InitializeComponent();
            //this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }
        /*private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            CellSize += (int)e.Delta/100;
            pictureBox1.Refresh();
        }*/
        public bool Preklapa(Komponenta trenutna, List<Tacka> lista1)
        {
            List<Tacka> lista2;
            foreach (var komponenta in komponente)
            {
                if (komponenta != trenutna)
                {
                    lista2 = komponenta.Oblast();
                    foreach (var tacka1 in lista1)
                    {
                        foreach (var tacka2 in lista2)
                        {
                            if (tacka1.X == tacka2.X && tacka1.Y == tacka2.Y)
                            {
                                return true;
                            }
                        }
                    }
                }
                
            }
            return false;
            
        }
        public void Refreshh()
        {
            pictureBox1.Refresh();
            
        }

        Ili k;
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTreeView();
            //Tacka.napuni_matricu(pictureBox1.Height, pictureBox1.Width, CellSize);
            Tacka.napuni_matricu(5000, 5000, CellSize);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Silver);
            Pen m = new Pen(Color.Blue);
            Pen me = new Pen(Color.Red);
            for (int x = 0; x < pictureBox1.Width; x+=CellSize)
            {
                for (int y = 0; y < pictureBox1.Height; y += CellSize)
                {
                    g.DrawEllipse(p, x+CellSize/2, y+CellSize/2, 1, 1);
                    if (debug&&Tacka.t[x / CellSize, y / CellSize].izlaz != null)
                    {
                        if ((bool)Tacka.t[x / CellSize, y / CellSize].izlaz) g.DrawEllipse(m, x + CellSize / 2, y + CellSize / 2, 10, 10); else g.DrawEllipse(me, x + CellSize / 2, y + CellSize / 2, 10, 10);
                    }
                }
            }
            foreach (var k in komponente)
            {
                if (k!=null) k.Nacrtaj(g);
            }
            //k.Nacrtaj(g);
        }
        


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
            if (Trenutna_komponenta.Tren == null)
            {
                if (Alatka.Al != null)
                {
                    if (Alatka.getAlatka() == AlatkaZica.getAlatka())
                    {
                        MessageBox.Show("a");
                        Komponenta pom = ((AlatkaZica)Alatka.Al).NapraviObjekatZica((PZica)komponente[komponente.Count - 1]);
                        if (!((Zica)pom).greska)
                        {
                            MessageBox.Show("b");
                            if (!Preklapa(pom, pom.Oblast()))
                            {
                                komponente.Add(pom);
                                listBox1.Items.Add(Alatka.Al.Text());
                            }
                        }
                        else
                        {
                            MessageBox.Show("c");
                        }

                    }
                    else
                    {
                        Komponenta pom = Alatka.Al.NapraviObjekat(e.X, e.Y, CellSize);
                        if (pom != null)
                        {
                            if (!Preklapa(pom, pom.Oblast()))
                            {
                                komponente.Add(pom);
                                listBox1.Items.Add(Alatka.Al.Text());
                                pom.Napravi_Slider(this);
                            }
                        }
                    }
                    
                }
            }
            else 
            {
                if (Alatka.Al.NapraviObjekat(e.X, e.Y, CellSize) == null)
                {
                    AlatkaDes.getAlatka().Unisti(e.X,e.Y,this);
                    listBox1.Items.Add(Alatka.Al.Text());
                }
                else if (!Preklapa(Trenutna_komponenta.Tren,Trenutna_komponenta.Oblast(e.X,e.Y)))
                {
                    
                    Trenutna_komponenta.Tren.Promeni_Poziciju(e.X, e.Y, Trenutna_komponenta.Pomx, Trenutna_komponenta.Pomy);
                    pictureBox1.Refresh();
                    
                }
                Trenutna_komponenta.Tren = null;
            }
            Refreshh();
            dodavanjeZice = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            dodavanjeZice = false;
            Trenutna_komponenta.dodavanje = true;
            foreach (Komponenta k in komponente)
            {
                if (k.label == 0 && k.Is_Clicked(e.X, e.Y, CellSize) == true)
                {
                    Trenutna_komponenta.dodavanje = false;
                    Trenutna_komponenta.Tren = k;
                    Trenutna_komponenta.Pomx = e.X;
                    Trenutna_komponenta.Pomy = e.Y;
                }
            }
            if (Trenutna_komponenta.dodavanje && Alatka.getAlatka() == AlatkaZica.getAlatka())
            {
                
                dodavanjeZice = true;
                komponente.Add(((AlatkaZica)Alatka.Al).NapraviPZicu(e.X, e.Y, CellSize));
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Refreshh();
            if (Trenutna_komponenta.Tren != null)
            {
                int x = Trenutna_komponenta.Tren.X;
                int y = Trenutna_komponenta.Tren.Y;
                Trenutna_komponenta.Tren.Privremena_Pozicija(e.X, e.Y, Trenutna_komponenta.Pomx, Trenutna_komponenta.Pomy);
                pictureBox1.Refresh();
                Trenutna_komponenta.Tren.X=x;
                Trenutna_komponenta.Tren.Y=y;
            }
            if (mousedown && dodavanjeZice)
            {
                int iks = e.X, ips = e.Y;
                Komponenta.Normalizuj(CellSize, ref iks, ref ips);
                ((PZica)komponente[komponente.Count - 1]).Update(iks, ips);
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
            treeView1.Nodes.Add("Destruktor");
            treeView1.Nodes[0].Nodes.Add("Pokazivaci");
            treeView1.Nodes[0].Nodes.Add("Kola");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Izvor");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Klok");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("LED");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("I");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Ili");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Ne");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("NI");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("NIli");
            //treeView1.Nodes[0].Nodes[1].Nodes[0]
            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.Text=="Izvor")
            {
                Alatka.Al = AlatkaIzvor.getAlatka();
                label1.Text = "Izvor alatka";
            }
            if (treeView1.SelectedNode.Text == "Klok")
            {
                Alatka.Al = AlatkaKlok.getAlatka();
                label1.Text = "Klok alatka";
            }
            if (treeView1.SelectedNode.Text == "LED")
            {
                Alatka.Al = AlatkaLampica.getAlatka();
                label1.Text = "LED alatka";
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
            if (treeView1.SelectedNode.Text == "Ne")
            {
                Alatka.Al = AlatkaNe.getAlatka();
                label1.Text = "Ne alatka";
            }
            if (treeView1.SelectedNode.Text == "NI")
            {
                Alatka.Al = AlatkaNI.getAlatka();
                label1.Text = "NI alatka";
            }
            if (treeView1.SelectedNode.Text == "NIli")
            {
                Alatka.Al = AlatkaNIli.getAlatka();
                label1.Text = "NIli alatka";
            }

            if (treeView1.SelectedNode.Text == "Zica")
            {
                Alatka.Al = AlatkaZica.getAlatka();
                label1.Text = "Zica alatka";
            }
            if (treeView1.SelectedNode.Text == "Destruktor")
            {
                Alatka.Al = AlatkaDes.getAlatka();
                label1.Text = "Destruktor";
            }


        }
        
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var komp in Tikkomponente)
            {
                if (Vreme % komp.Lambda == 0) komp.PromeniVrednost();
            }
            Vreme++;
            Vreme %= 100000;
            pictureBox1.Refresh();
        }
        

        /* MOOOORAAAAAAAAAMMMMMMMMMMMMM*/

        private void button1_Click(object sender, System.EventArgs e)
        {
            
            TextBox myText = new TextBox();
            myText.Location = new Point(25, 25);
            this.Controls.Add(myText);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            Vreme = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            debug = !debug;
            Refreshh();
        }
    }
}