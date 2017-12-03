using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
    public class Salon
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PIB { get; set; }
        public string MaticniBr { get; set; }
        public string ZiroRacun { get; set; }


        public Salon()
        {

        }

        public Salon(string naziv, string adresa, string telefon, string email, string website, string pib, string maticniBr, string ziroRacun)
        {
            Naziv = naziv;
            Adresa = adresa;
            Telefon = telefon;
            Email = email;
            Website = website;
            PIB = pib;
            MaticniBr = maticniBr;
            ZiroRacun = ziroRacun;
        }
    }

}
