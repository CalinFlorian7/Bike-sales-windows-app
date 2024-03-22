using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    public partial class CreareCont : Form
    {
        User utilizator;
        public CreareCont()
        {
            InitializeComponent();
            utilizator = new User();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("utilizatori.dat", FileMode.Open, FileAccess.Read);
            Program.listaUtilizatori = (List<User>)bf.Deserialize(fs);
            fs.Close();
            foreach (User user in Program.listaUtilizatori)
            {
                Console.WriteLine(user.ToString());
            }


        }

        private void CreareCont_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ErrorProvider eroare = new ErrorProvider();
            if (tbxNume.Text.Trim() == "")
                eroare.SetError(tbxNume, "Introdu nume");
            else
                if (validareDoarLitere(tbxNume.Text) == false)
                eroare.SetError(tbxNume, "Numele trebuie sa contina doar litere!");
            else
            if (validareAdresaEmail(tbxEmail.Text) == false)
                eroare.SetError(tbxEmail, "Emailul nu este valid");
            else
            if (validareParolaUser(tbxParola.Text) == false)
                eroare.SetError(tbxParola, "Parola trebuie sa contina minimum 8 caracter dintre care cel putin 2 cifre,5 litere si un caracter special!");
            else
                if (tbxLocalitate.Text.Trim() == "")
                eroare.SetError(tbxLocalitate, "Introdu localitate");
            else
               if (validareDoarLitere(tbxLocalitate.Text) == false)
                eroare.SetError(tbxLocalitate, "Localitatea trebuie sa contina doar litere!");
            else
                if (validareVarsta(tbxVarsta.Text) == false)
                eroare.SetError(tbxVarsta, "Varsta trebuie sa fie un numar!");
            else
                if (tbxNrTelefon.Text.Trim() == "")
                eroare.SetError(tbxNrTelefon, "Introdu numar de telefon!");
            else
                if (validareNrTelefon(tbxNrTelefon.Text) == false)
                eroare.SetError(tbxNrTelefon, "Numarul de telefon trebuie sa inceapa cu 0 si sa aiba 10 cifre");
            else
                if (!checkBox1.Checked)
                eroare.SetError(checkBox1, "Trebuie sa bifezi acordul");
            else
                if (existaCont(Program.listaUtilizatori, tbxEmail.Text) == false)
                eroare.SetError(button1, "Nu poti crea contul,deja exista un cont cu aceast email!");
            else
            try
                {
                   // eroare.Clear();
                    utilizator.Nume = tbxNume.Text;
                    utilizator.Parola = tbxParola.Text;
                    utilizator.Localitate = tbxLocalitate.Text;
                    utilizator.Email = tbxEmail.Text;
                    utilizator.Varsta = Convert.ToInt32(tbxVarsta.Text);
                    utilizator.NrTelefon = tbxNrTelefon.Text;
                    Program.listaUtilizatori.Add(utilizator);
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("utilizatori.dat", FileMode.Create, FileAccess.Write);
                    
                        bf.Serialize(fs,Program.listaUtilizatori);
                    
                    fs.Close();
                    this.Hide();
                    PaginaPrincipalaConectat pagina = new PaginaPrincipalaConectat();
                    pagina.Show();
                    MessageBox.Show("Contul tau a fost creat!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private bool validareDoarLitere(string sir)
        {

            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(sir);
        }
        private bool validareAdresaEmail(string sir)
        {
            int nr = 0;
            foreach (char s in sir)
            {
                if (s.ToString() == "@")
                    nr++;
            }
            if (nr == 1 && sir.Length == sir.Trim().Length)
                return true;
            else
                return false;
        }
        private bool validareParolaUser(string sir)
        {
            int nrCifre = 0;
            int numar;
            int nrLitere = 0;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            Regex regex1 = new Regex(@"^[^a-zA-Z0-9\s]+$");
            int nrCaractereSpeciale = 0;
            if (sir.Length < 8)
                return false;
            foreach (char s in sir)
            {
                if (int.TryParse(s.ToString(), out numar))
                    nrCifre++;
                if (regex.IsMatch(s.ToString()))
                    nrLitere++;
                if (regex1.IsMatch(s.ToString()))
                    nrCaractereSpeciale++;

            }
            if (nrCifre < 2||nrLitere<5||nrCaractereSpeciale<1)
                return false;
            else
                return true;
        
            
        }
        private bool validareVarsta(string sir)
        {
            int numar=0;
            if (int.TryParse(sir, out numar))
            {
                if (Convert.ToInt32(sir) >= 5 && Convert.ToInt32(sir) <= 100)
                    return true;
                else
                    return false;
           
            }
            else

                return false;
        }
        private bool validareNrTelefon(string sir)
        {
            int ok = 0;
            bool verifCifre = true;
            foreach (char s in sir)
            {
                if (Char.IsDigit(s) == false)
                    ok++;
            }
            if (ok == 0)
                verifCifre = true;
            else
                verifCifre = false;
            return verifCifre;
        }
        private bool existaCont(List<User>lista,string email)
        {
            foreach (User user in lista)
                if (user.Email == email)
                    return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            PaginaPrincipala pagina = new PaginaPrincipala();
            pagina.Show();
        }
    }
}
