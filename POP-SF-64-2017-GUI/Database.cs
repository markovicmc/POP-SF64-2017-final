using POP_SF_64_2017_GUI.Baza;
using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

// To do: Napravi listu Namestaja, dodaj u konstruktor neki namestaj, DataGrid,
// Dugme Korpa... 
//dodavanje/editovanje namestaja prozor


namespace POP_SF_64_2017_GUI
{
    public class Database
    {
        public static List<string> TipoviNamestaja
        {
            get
            {
                using (var unitOfWork = new Context())
                {
                    var TipoviNamestaja = new List<string>();
                    foreach (var item in unitOfWork.TipoviNamestaja.ToList())
                    {
                        TipoviNamestaja.Add(item.Naziv);
                    }
                    return TipoviNamestaja;
                }
            }
        }
        public static List<Akcija> Akcije
        {
            get
            {
                using (var unitOfWork = new Context())
                {
                    return unitOfWork.Akcije.ToList();
                }
            }
        }
        public static Dictionary<string, Korisnik> Korisnici;

        static Database()
        {
            Korisnici = new Dictionary<string, Korisnik>();

            using (var unitOfWork = new Context())
            {
                var tempList = unitOfWork.Korisnici.ToList();

                foreach (var item in tempList)
                {
                    Korisnici[item.Username] = item;
                }
            }
        }
    }
} 
