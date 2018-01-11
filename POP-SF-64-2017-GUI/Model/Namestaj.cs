using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
   public class Namestaj
    {
        public int ID { get; set; }
        
        private int TipNamestajaId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public string Tip { get; set; }
        public int AkcijaId;

        [NotMapped]
        public Akcija Akcija {
            get
            {
                foreach (var item in Database.Akcije)
                {
                    if (item.ID == AkcijaId)
                        return item;
                }
                return new Akcija("", DateTime.MinValue, DateTime.MinValue, 0, false); //ne bi imalo nad cime da pozove ToString da nemamo objekat
            }
        }

        public bool Obrisano { get; set; }

        public Namestaj()
        {

        }

        public Namestaj(Namestaj n)
        {
            Naziv = n.Naziv;
            Sifra = n.Sifra;
            Cena = n.Cena;
            Kolicina = n.Kolicina;
            Tip = n.Tip;
            Obrisano = n.Obrisano;
            AkcijaId = n.AkcijaId;
            ID = n.ID;
        }

       

        public Namestaj(string naziv, string sifra, double cena, int kolicina, string tip, bool akcijaPostoji, bool obrisano )
        {
            Naziv = naziv;
            Sifra = sifra;
            Cena = cena;
            Kolicina = kolicina;
            Tip = tip;
            Obrisano = obrisano;
            //if(akcijaPostoji)
               // Akcija = new Akcija(Naziv + "Akcija", DateTime.Now, DateTime.Now.AddMonths(1), 10, false);

        }


        public void Zameni(Namestaj n)
        {
            Naziv = n.Naziv;
            Sifra = n.Sifra;
            Cena = n.Cena;
            Kolicina = n.Kolicina;
            Tip = n.Tip;
            Obrisano = n.Obrisano;
            AkcijaId = n.AkcijaId;
            ID = n.ID;
        }

    }
}
