using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace betenroate
{
    public partial class Vizualizare : betenroate.PaginaPrincipala
    {
        int numarAnunt;
        int indexImagineActuala;
        List<Image>listaImaginiVizualizare=new List<Image>();
        public Vizualizare()
        {
            InitializeComponent();
        }
        public Vizualizare(int nrAnunt)
        {
          
            InitializeComponent();
            numarAnunt = nrAnunt;
            labelNume.Text = Program.listaAnunturi[nrAnunt].Nume;
          
            labelNume.Font = new Font("", 14);
            labelNume.ForeColor = Color.Blue;
            labelLocalitate.Text = Program.listaAnunturi[nrAnunt].Localitate;
            labelCreareContDin.Text = Program.listaAnunturi[nrAnunt].DataCreareCont.ToString();
            labelCategorie.Text = "Categorie: " + Program.listaAnunturi[nrAnunt].Anunturi[0].CategorieAnunt;
           
            labelDescriereAnunt.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].DescriereAnunt;
            labelDescriereAnunt.Width = panel5.Width - panel6.Width - 20;
            using (Graphics g = labelDescriereAnunt.CreateGraphics())
            {
                SizeF size = g.MeasureString(labelDescriereAnunt.Text, labelDescriereAnunt.Font, labelDescriereAnunt.Width);

                // Update the height of the label to fit the text
                labelDescriereAnunt.Height = (int)Math.Ceiling(size.Height);
            }



            pictureBox1.Image = Program.listaAnunturi[nrAnunt].ImagineProfil;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            labelTitluAnunt.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].TitluAnunt;
            labelLocalitateAnunt.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].LocalitateAnunt;
            labelmetodalivrare.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].MetodaLivrare;
            Label label = new Label();
            label.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].Valuta;
            label.ForeColor = Color.Blue;
            label.Font = new Font("", 16);
            labelPretValuta.ForeColor = Color.Green;
            labelPretValuta.Text = Program.listaAnunturi[nrAnunt].Anunturi[0].Pret.ToString()+" ";
            labelPretValuta.Text += label.Text;
            labelNume.Cursor = Cursors.Hand;
            pictureBox1.Cursor = Cursors.Hand;
            
            labeldatapublicare.Text = "Data publicare: " + Program.listaAnunturi[nrAnunt].Anunturi[0].DataCreareAnunt.ToString();
            labeldatapublicare.Location = new Point(labelDescriereAnunt.Location.X, labelDescriereAnunt.Bottom+20);
            
            labelDataEditare.Text = "Ultima actualizare: " + Program.listaAnunturi[nrAnunt].Anunturi[0].DataEditareAnunt.ToString();
            labelDataEditare.Location = new Point(labelDescriereAnunt.Location.X,labeldatapublicare.Bottom +10);

            //imagine inchisa la culoare
            pictureBox2.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[0];
            pictureBox3.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[1];
            pictureBox4.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[2];
            pictureBox5.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[3];
            pictureBox6.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[4];
            pictureBox2.Click += new EventHandler(clickImagineAnunt);
            pictureBox3.Click += new EventHandler(clickImagineAnunt);
            pictureBox4.Click += new EventHandler(clickImagineAnunt);
            pictureBox5.Click += new EventHandler(clickImagineAnunt);
            pictureBox6.Click += new EventHandler(clickImagineAnunt);

            pictureBox7.Image = Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[0];
            indexImagineActuala = 0;
            listaImaginiVizualizare.Add(Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[0]);
            listaImaginiVizualizare.Add(Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[1]);
            listaImaginiVizualizare.Add(Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[2]);
            listaImaginiVizualizare.Add(Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[3]);
            listaImaginiVizualizare.Add(Program.listaAnunturi[nrAnunt].Anunturi[0].ImaginiAnunt[4]);
         
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

            


        }

        private void Vizualizare_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = Program.listaAnunturi[Program.nrAnuntVizualizare].NrTelefon;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = Program.listaAnunturi[Program.nrAnuntVizualizare].Email;
            label4.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anunturi anunt = new Anunturi(Program.butonActual);
            anunt.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            //else
                if(e.X<pictureBox7.Location.X+pictureBox7.Width/2&&indexImagineActuala>0)
            {
                indexImagineActuala -= 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }

            if (e.X >= pictureBox7.Location.X + pictureBox7.Width / 2 && indexImagineActuala <4)
            {
                indexImagineActuala += 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (indexImagineActuala < 4)
            {
                indexImagineActuala += 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (indexImagineActuala > 0)
            {
                indexImagineActuala -= 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }
        }

        private void clickImagineAnunt(object sender,EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            for (int i = 0; i < listaImaginiVizualizare.Count; i++)
                if (listaImaginiVizualizare[i] == pictureBox.Image)
                    indexImagineActuala = i;
           
                
           
            pictureBox7.Image = pictureBox.Image;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ZoomImagine zoom = new ZoomImagine(numarAnunt,indexImagineActuala,listaImaginiVizualizare);
            zoom.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProfilulMeu profilul = new ProfilulMeu(numarAnunt);
            this.Hide();
            profilul.Show();
            

        }

        private void labelNume_Click(object sender, EventArgs e)
        {
            ProfilulMeu profilul = new ProfilulMeu(numarAnunt);
            this.Hide();
            profilul.Show();

        }
    }
}
