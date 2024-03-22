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
    public partial class PaginaPrincipalaConectat : Form
    {
        public PaginaPrincipalaConectat()
        {
            InitializeComponent();
        }

        private void salutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void daToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void profilulMeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfilulMeu profilulMeu=new ProfilulMeu();
            profilulMeu.Show();
            this.Hide();
        }

        private void deconectareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaginaPrincipala pagina = new PaginaPrincipala();
            pagina.Show();
        }

        private void editezaContToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditeazaCont editeaza = new EditeazaCont();
            editeaza.Show();
           
        }

        private void anunturileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {


            this.Hide();
            EditareAnunt editare = new EditareAnunt();
            editare .Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdaugaAnunt adauga = new AdaugaAnunt();
            adauga.Show();
        }

        private void anunturiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnunturiConectat anunturi = new AnunturiConectat();
            anunturi.Show();
        }
    }
}
