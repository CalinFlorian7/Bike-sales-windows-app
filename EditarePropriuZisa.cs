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
    public partial class EditarePropriuZisa : Form
    {
        public int numar_anunt;
        public EditarePropriuZisa()
        {
           
            InitializeComponent();
            
        }
        public EditarePropriuZisa(int poz)
        {
            InitializeComponent();
            tbxTitluAnunt.Text = Program.userConectat.Anunturi[poz].TitluAnunt;
            comboBox1.Text = Program.userConectat.Anunturi[poz].CategorieAnunt;
            comboBox4.Text = Program.userConectat.Anunturi[poz].LocalitateAnunt;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode= PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode= PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode= PictureBoxSizeMode.StretchImage;

            pictureBox2.Image = Program.userConectat.Anunturi[poz].ImaginiAnunt[0];
            pictureBox3.Image = Program.userConectat.Anunturi[poz].ImaginiAnunt[1];
            pictureBox5.Image=Program.userConectat.Anunturi[poz].ImaginiAnunt[2];
            pictureBox1.Image = Program.userConectat.Anunturi[poz].ImaginiAnunt[3];
            pictureBox4.Image = Program.userConectat.Anunturi[poz].ImaginiAnunt[4];
            textBox1.Text = Program.userConectat.Anunturi[poz].DescriereAnunt;
            comboBox2.Text = Program.userConectat.Anunturi[poz].MetodaLivrare;
            textBox2.Text = Program.userConectat.Anunturi[poz].Pret.ToString();
            comboBox3.Text = Program.userConectat.Anunturi[poz].Valuta;
            numar_anunt = poz;
        }
        private void EditarePropriuZisa_Load(object sender, EventArgs e)
        {

        }

        private void selecteazaImagine(PictureBox pictureBox)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {pictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(dlg.FileName);
            }
        }

      

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            selecteazaImagine(pictureBox3);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            selecteazaImagine(pictureBox2);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            selecteazaImagine(pictureBox5);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selecteazaImagine(pictureBox1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            selecteazaImagine(pictureBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditareAnunt editareAnunt = new EditareAnunt();
            editareAnunt.Show();
            this.Close();
        }
        private bool validarePret(string sir)
        {
            int numar = 0;
            if (int.TryParse(sir, out numar))
            {
                if (Convert.ToInt32(sir) >= 1 && Convert.ToInt32(sir) <= 9999999)
                    return true;
                else
                    return false;

            }
            else

                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Anunt anunt;
            //anunt = new Anunt();
            ErrorProvider eroare = new ErrorProvider();
            if (tbxTitluAnunt.Text.Trim() == "")
                eroare.SetError(tbxTitluAnunt, "Nu ai introdus titlu");
            else
                if (tbxTitluAnunt.Text.Trim().Length > 150)
                eroare.SetError(tbxTitluAnunt, "Titlul nu trebuie sa depaseasca 150 de caractere!");
            else
                if (comboBox1.SelectedIndex == -1)
                eroare.SetError(comboBox1, "Nu ai selectat categoria!");
            else
                if (pictureBox1.Image == null || pictureBox1.Image == null || pictureBox2.Image == null || pictureBox3.Image == null || pictureBox4.Image == null
                || pictureBox5.Image == null)
                eroare.SetError(pictureBox4, "Selecteaza toate cele 5 poze pentru anunt!");
            else
                if (textBox1.Text.Trim() == "")
                eroare.SetError(textBox1, "Pune descriere anuntului!");
            else

                if (textBox1.Text.Trim().Length >= 5000)
                eroare.SetError(textBox1, "Descrierea nu trebuie sa depaseasca 5000 de caractere!");
            else
                if (comboBox2.SelectedIndex == -1)
                eroare.SetError(comboBox2, "Nu ai selectat metoda de livrare!");
            else
                if (validarePret(textBox2.Text) == false)
                eroare.SetError(textBox2, "Introdu un pret!");
            else
                if (comboBox3.SelectedIndex == -1)
                eroare.SetError(comboBox3, "Nu ai selectat valuta!");
            else
                try
                {
                    Program.userConectat.Anunturi[numar_anunt].TitluAnunt = tbxTitluAnunt.Text;
                    Program.userConectat.Anunturi[numar_anunt].CategorieAnunt = comboBox1.Text;
                    Program.userConectat.Anunturi[numar_anunt].DescriereAnunt = textBox1.Text;
                    Program.userConectat.Anunturi[numar_anunt].MetodaLivrare = comboBox2.Text;
                    Program.userConectat.Anunturi[numar_anunt].Valuta = comboBox3.Text;
                    Program.userConectat.Anunturi[numar_anunt].Pret = Convert.ToInt32(textBox2.Text);
                   // Program.userConectat.Anunturi[numar_anunt].DataCreareAnunt = DateTime.Now.ToString();
                    Program.userConectat.Anunturi[numar_anunt].DataEditareAnunt = DateTime.Now.ToString();
                    Program.userConectat.Anunturi[numar_anunt].LocalitateAnunt = comboBox4.Text;
                    Program.userConectat.Anunturi[numar_anunt].seteazaImagine(pictureBox2.Image);
                    Program.userConectat.Anunturi[numar_anunt].ImaginiAnunt.Add(pictureBox3.Image);
                    Program.userConectat.Anunturi[numar_anunt].ImaginiAnunt.Add(pictureBox5.Image);
                    Program.userConectat.Anunturi[numar_anunt].ImaginiAnunt.Add(pictureBox1.Image);
                    Program.userConectat.Anunturi[numar_anunt].ImaginiAnunt.Add(pictureBox4.Image);
                
                   // Program.userConectat.Anunturi.Add(anunt);
                    List<User> listaCuAnuntAdaugat = new List<User>();
                    foreach (User user in Program.listaUtilizatori)
                    {
                        if (Program.userConectat.Email != user.Email)
                            listaCuAnuntAdaugat.Add(user);
                    }
                    // Program.listaUtilizatori.Add(Program.userConectat);
                    listaCuAnuntAdaugat.Add(Program.userConectat);
                    //foreach(Anunt anuntul in Program.userConectat.Anunturi)
                    //  {
                    //      Console.WriteLine("Anunturile tale sunt:"+anuntul.ToString());
                    //  }
                    Program.serializareListauseri("utilizatori.dat", listaCuAnuntAdaugat);
                    this.Hide();
                    EditareAnunt editare = new EditareAnunt();
                    editare.Show();
                    MessageBox.Show("Anuntul tau a fost editat!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
