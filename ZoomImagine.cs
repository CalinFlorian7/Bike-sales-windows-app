using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    public partial class ZoomImagine : Form
    {
        int nrAnunt;
        int indexImagineActuala;
        List<Image> listaImaginiVizualizare=new List<Image>();
        public ZoomImagine()
        {
            InitializeComponent();


        }
        public ZoomImagine(int nrAnunt,int indexImagineActuala,List<Image>listaImaginiVizualizare)
        {
            InitializeComponent();
           this.WindowState = FormWindowState.Maximized;
            this.nrAnunt = nrAnunt;
            this.indexImagineActuala = indexImagineActuala;
            this.listaImaginiVizualizare = listaImaginiVizualizare;
           pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            pictureBox7.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = listaImaginiVizualizare[0];
            pictureBox3.Image = listaImaginiVizualizare[1];
            pictureBox4.Image = listaImaginiVizualizare[2];
            pictureBox5.Image = listaImaginiVizualizare[3];
            pictureBox6.Image = listaImaginiVizualizare[4];

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Click += new EventHandler(clickImagineAnunt);
            pictureBox3.Click += new EventHandler(clickImagineAnunt);
            pictureBox4.Click += new EventHandler(clickImagineAnunt);
            pictureBox5.Click += new EventHandler(clickImagineAnunt);
            pictureBox6.Click += new EventHandler(clickImagineAnunt);

        }

        private void ZoomImagine_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Vizualizare vizualizare = new Vizualizare(nrAnunt);
            vizualizare.Show();
           
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

        private void clickImagineAnunt(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            for (int i = 0; i < listaImaginiVizualizare.Count; i++)
                if (listaImaginiVizualizare[i] == pictureBox.Image)
                    indexImagineActuala = i;



            pictureBox7.Image = pictureBox.Image;

        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < pictureBox7.Location.X + pictureBox7.Width / 2 && indexImagineActuala > 0)
            {
                indexImagineActuala -= 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }

            if (e.X >= pictureBox7.Location.X + pictureBox7.Width / 2 && indexImagineActuala < 4)
            {
                indexImagineActuala += 1;
                pictureBox7.Image = listaImaginiVizualizare[indexImagineActuala];
            }
        }
    }
}
