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
    public partial class ProfilulMeu : Form
    {
        int nrAnunt;
        public ProfilulMeu()
        {
            InitializeComponent();
            label1.Text = Program.userConectat.Nume;
            label2.Text = "Localitate:  "+Program.userConectat.Localitate;
            label3.Text = "Varsta:  "+Program.userConectat.Varsta.ToString();
            label4.Text = "S-a alaturat la:  "+Program.userConectat.DataCreareCont;
            pictureBox1.Image = Program.userConectat.ImagineProfil;
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
        }
        public ProfilulMeu(int nrAnunt)
        {
            InitializeComponent();
            this.button1.Click -= button1_Click;
            this.nrAnunt = nrAnunt;
            label1.Text = Program.listaAnunturi[nrAnunt].Nume;
            label2.Text = "Localitate:  " + Program.listaAnunturi[nrAnunt].Localitate;
            label3.Text = "Varsta:  " + Program.listaAnunturi[nrAnunt].Varsta.ToString();
            label4.Text =  Program.listaAnunturi[nrAnunt].DataCreareCont;
            pictureBox1.Image = Program.listaAnunturi[nrAnunt].ImagineProfil;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.Text = "inapoi la anunturi";
            button1.Click += new EventHandler(clickButon);
           
        }
        private void ProfilulMeu_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaginaPrincipalaConectat pagina=new PaginaPrincipalaConectat();
            pagina.Show();

        }
        public void inlaturaButon()
        {
            this.Controls.Remove(button1);
        }
        public void adaugaButon()
        {
            Button button = new Button();
            button.Location = new Point(30, 552);
            button.AutoSize = true;
            button.Text = "Inapoi la anunt";
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.Controls.Add(button);
        }

        private void clickButon(object sender,EventArgs e)
        {
            this.Hide();
            Vizualizare vz = new Vizualizare(nrAnunt);
            vz.Show();
        }
    }
}
