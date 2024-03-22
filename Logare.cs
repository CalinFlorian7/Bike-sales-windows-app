using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
           User utilizator = new User();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("utilizatori.dat", FileMode.Open, FileAccess.Read);
            Program.listaUtilizatori = (List<User>)bf.Deserialize(fs);
            fs.Close();
            foreach (User user in Program.listaUtilizatori)
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void Logare_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            PaginaPrincipala pagina = new PaginaPrincipala();
            pagina.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ErrorProvider eroare = new ErrorProvider();
            bool verificaContExistent = false;
            string numeUser = "";
            foreach (User user in Program.listaUtilizatori)
                if (user.Email == textBox1.Text && user.Parola == textBox2.Text)
                {
                    verificaContExistent = true;
                    numeUser = user.Nume;
                    Program.userConectat=user;
                }
            if (verificaContExistent==false)
                eroare.SetError(button1, "Nu exista cont cu aceasta parola de email sau ai introdus gresit parola!");
                else
                    try
                    {
                    PaginaPrincipalaConectat paginaPrincipalaConectat = new PaginaPrincipalaConectat();
                    paginaPrincipalaConectat.Show();
                    this.Hide();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


            //this.Hide();
        }
    }
}
