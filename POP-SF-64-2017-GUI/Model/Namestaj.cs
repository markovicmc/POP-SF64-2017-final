using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
   public class Namestaj
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public string Tip { get; set; }
        public Akcija Akcija { get; set; }

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
            Akcija = n.Akcija;
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
            if(akcijaPostoji)
                Akcija = new Akcija(Naziv + "Akcija", DateTime.Now, DateTime.Now.AddMonths(1), 10, false);

        }


        public void Zameni(Namestaj n)
        {
            Naziv = n.Naziv;
            Sifra = n.Sifra;
            Cena = n.Cena;
            Kolicina = n.Kolicina;
            Tip = n.Tip;
            Obrisano = n.Obrisano;
            Akcija = n.Akcija;
            ID = n.ID;
        }

    }
}
