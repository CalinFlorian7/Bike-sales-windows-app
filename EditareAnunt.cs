using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    public partial class EditareAnunt : Form
    {
        public  List<Button> listaButoaneEditareAnunturi = new List<Button>();
        public  List<Button> listaButoaneStergereAnunturi = new List<Button>();
        public EditareAnunt()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            if(Program.userConectat.Anunturi.Count>0)
            {
                Console.WriteLine("numar de anunturi:" + Program.userConectat.Anunturi.Count);




                for (int i=0;i< Program.userConectat.Anunturi.Count;i++)
                {
                    Console.WriteLine("Pret:"+Program.userConectat.Anunturi[i].Pret);
                    Label label1 = new Label();
                    label1.BackColor = Color.White;
                    label1.Location = new Point(41, 200*(i+1)+50*i);
                    label1.Size = new Size(this.Width, 200);
                   // label1.Padding = new Padding(10);
                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Program.userConectat.Anunturi[i].ImaginiAnunt[0];
                    label1.Controls.Add(pictureBox1);
                    pictureBox1.Size = new Size(190, 180);
                    pictureBox1.Location = new Point(10, 10);
                    Label label2 = new Label();
                    label1.Controls.Add(label2);
                    label2.BackColor = Color.White;
                    label2.Location = new Point(220, 30);
                    label2.Font = new Font("Blue", 14);
                    label2.Text = Program.userConectat.Anunturi[i].TitluAnunt;
                    label2.AutoSize = true;
                    //BUTOANE STERGERE /EDITARE
                    Button editeaza = new Button();
                    Button sterge = new Button();
                    label1.Controls.Add(editeaza);
                    label1.Controls.Add(sterge);
                    editeaza.Location = new Point(label1.Width-100,label1.Height-60);
                    sterge.Location = new Point(label1.Width - 100, label1.Height - 30);
                    editeaza.Text = "Editeaza";
                    sterge.Text = "Sterge";
                    Label label3 = new Label();
                    label1.Controls.Add(label3);
                    label3.Text ="Pret:"+ Program.userConectat.Anunturi[i].Pret.ToString()+" " + Program.userConectat.Anunturi[i].Valuta;
                    label3.Location = new Point(label1.Width - 120, label1.Height - 140);
                    listaButoaneEditareAnunturi.Add(editeaza);
                    listaButoaneStergereAnunturi.Add(sterge);

                    
                    editeaza.Click += new EventHandler(clickButonEditare);
                    sterge.Click+=new EventHandler(clickButonStergere);

                    this.Controls.Add(label1);
                }
            }
            else
            {
                Label label = new Label();
                label.Size = new Size(300,30);
                label.Location = new Point(80,150);
                label.Text = "Nu ai anuturi publicate";
                label.Font = new Font("", 14);
                
        
                this.Controls.Add(label);
            }
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
                PaginaPrincipalaConectat pagina = new PaginaPrincipalaConectat();
            pagina.Show();
        }

        private void EditareAnunt_Load(object sender, EventArgs e)
        {

        }
        private void clickButonEditare(object sender,EventArgs e)
        {
            Button butonApasat = sender as Button;
            for (int i=0;i<listaButoaneEditareAnunturi.Count;i++)
            {
                if (butonApasat == listaButoaneEditareAnunturi[i])
                {
                    this.Close();
                    EditarePropriuZisa anunt = new EditarePropriuZisa(i);
                    anunt.Show();
                    
                }
            }



        }
        private void clickButonStergere(object sender, EventArgs e)
        {
            int indexButon=-1;
            Button butonApasat = sender as Button;
            for (int i = 0; i < listaButoaneStergereAnunturi.Count; i++)
            {
                if (butonApasat == listaButoaneStergereAnunturi[i])
                {
                    //this.Close();
                    indexButon = i;
                   

                }
            }
            if(indexButon>=0)
            {
               
                DialogResult result = MessageBox.Show("Daca stergi  anuntul va disparea definitiv.Esti sigur ca vrei sa stergi anuntul?","Confirmare", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Program.userConectat.Anunturi.RemoveAt(indexButon);
                    this.Hide();
                    EditareAnunt editare = new EditareAnunt();
                    editare.Show();
                    List<User> listaCuAnuntSters = new List<User>();
                    foreach (User user in Program.listaUtilizatori)
                    {
                        if (Program.userConectat.Email != user.Email)
                            listaCuAnuntSters.Add(user);
                    }
                    
                    listaCuAnuntSters.Add(Program.userConectat);
                    Program.serializareListauseri("utilizatori.dat", listaCuAnuntSters);
                    MessageBox.Show("Anuntul a fost sters!");
                }
           
            }


        }




    }
}
