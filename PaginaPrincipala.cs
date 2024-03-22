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
    public partial class PaginaPrincipala : Form
    {
        public PaginaPrincipala()
        {
            InitializeComponent();
        }

        private void salutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Logare logare=new Logare();
            logare.Show();
            
            this.Hide();
           // MessageBox.Show("Anuntul tau a fost adaugat!");
        }

        private void daToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreareCont contNou = new CreareCont();
            contNou.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdaugaAnunt adauga = new AdaugaAnunt();
            adauga.Show();
        }

        private void anunturiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anunturi anunturi = new Anunturi();
            anunturi.Show();
        }
    }
}
