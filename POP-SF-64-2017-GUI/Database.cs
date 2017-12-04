using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To do: Napravi listu Namestaja, dodaj u konstruktor neki namestaj, DataGrid,
// Dugme Korpa... 
//dodavanje/editovanje namestaja prozor


namespace POP_SF_64_2017_GUI
{
    public class Database
    {
        public static Dictionary<string, Korisnik> Korisnici;

        static Database()
        {
            Korisnici = new Dictionary<string, Korisnik>();

            Korisnik k1 = new Korisnik(0, "Tamara", "Markovic", "admin", "admin", TipKorisnika.ADMINISTRATOR);
            Korisnici[k1.Username] = k1;

            Korisnik k2 = new Korisnik(1, "Prodavac", "Proda", "prod", "prod", TipKorisnika.PRODAVAC);
            Korisnici[k2.Username] = k2;
        }
    }
} 
