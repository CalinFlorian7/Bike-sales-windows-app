using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace betenroate
{
   [Serializable] internal class User
    {
        private string nume;
        private int varsta;
        private string dataCreareCont;
        private string localitate;
        private string email;
        private string nrTelefon;
        private string parola;
        private Image imagineProfil;
        private List<Anunt> anunturi;
        public User()
        {
            this.nume = "N/A";
            this.varsta = 0;
            this.imagineProfil =Image.FromFile("C:\\Users\\LENOVO\\Documents\\imaginesite\\Panorama_of_3mb.jpg"); 
            
          
            this.dataCreareCont = DateTime.Now.ToString("dd MMMM yyyy");
            this.parola = "N/A";
            this.localitate = "N/A";
            this.email = "N/A";
            this.nrTelefon = "N/A";
            this.anunturi = new List<Anunt>();
        }
        
        
        public User(string nume, int varsta, string dataCreareCont, string localitate, string email, string nrTelefon,string parola,Image imagineProfil, List<Anunt> anunturi)
        {
            this.nume = nume;
            this.varsta = varsta;
            this.dataCreareCont = dataCreareCont;
            this.localitate = localitate;
            this.email = email;
            this.nrTelefon = nrTelefon;
            this.parola = parola;
            this.imagineProfil = imagineProfil;
            this.anunturi = new List<Anunt>();

            foreach (Anunt anunt in anunturi)
            {
                Anunt anuntNou = new Anunt(anunt.TitluAnunt,anunt.Pret,anunt.LocalitateAnunt,anunt.MetodaLivrare,anunt.MetodaLivrare,anunt.ImaginiAnunt,anunt.Valuta,anunt.DescriereAnunt,anunt.DataCreareAnunt,anunt.DataEditareAnunt);

                this.anunturi.Add(anuntNou);
            }
        }

        public override string ToString()
        {
            return "nume:" + nume+"\n"+
            "varsta:" + varsta + "\n" +
            "data creare cont:" + dataCreareCont+"\n"+
            "localitate:" +localitate+"\n"+
            "email:" + email+"\n"+
            "nr tel:" +nrTelefon+"\n"+
            "parola:" +parola + "\n" ; 
        }

        public string Nume { get => nume; set => nume = value; }
        public int Varsta { get => varsta; set => varsta = value; }
        public string DataCreareCont { get => dataCreareCont; set => dataCreareCont = value; }
        public string Localitate { get => localitate; set => localitate = value; }
        public string Email { get => email; set => email = value; }
        public string NrTelefon { get => nrTelefon; set => nrTelefon = value; }
        public string Parola { get => parola; set => parola = value; }
        public Image ImagineProfil { get => imagineProfil; set => imagineProfil = value; }
        internal List<Anunt> Anunturi { get => anunturi; set => anunturi = value; }
    }
}
