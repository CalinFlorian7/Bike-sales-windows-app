using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betenroate
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    

        public static List<Button> listaButoanePagini=new List<Button>();
        public static int nrButoane;
        public static int nrAnuntVizualizare;
        public static int numarAnunturiPePagina = 3;
        public static int butonActual;
        public static List<User> listaUtilizatori=new List<User>();
        public static User userConectat=new User();
        public static List<User> listaAnunturi = new List<User>();
        public static List<User> lisaAnunturiUtilizator=new List<User>();
    //public    static void serializareListaAnunturi(string caleFisier, List<Anunt> anunturi)
    //    {
    //        BinaryFormatter bf=new BinaryFormatter();
    //        FileStream fs=new FileStream(caleFisier, FileMode.Create,FileAccess.Write);
    //        bf.Serialize(fs, anunturi);

    //    }
    //public     static void deserializareListaAnunturi(string caleFisier, List<Anunt> anunturi)
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream fs = new FileStream(caleFisier, FileMode.Open, FileAccess.Read);
    //        anunturi=(List<Anunt>)bf.Deserialize(fs);

    //    }
     public    static void deserializareListaUseri(string caleFisier,List<User> useri)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(caleFisier, FileMode.Open, FileAccess.Read);
            useri = (List<User>)bf.Deserialize(fs);
            fs.Close();
        }
     public   static void serializareListauseri(string caleFisier,List<User> useri)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(caleFisier, FileMode.Create, FileAccess.Write);

            bf.Serialize(fs,useri);

            fs.Close();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new ZoomImagine());
            Application.Run(new PaginaPrincipala());
            //Application.Run(new Testare());
            //List <int> numere=new List<int> ();
            //numere.Add(12);
            //numere.Add(123);
            //numere.Add(1234);
            //numere.RemoveAt(1);
            //foreach(int i in numere)
            //    Console.WriteLine(i);


            Console.ReadLine();
        }
    }
}
