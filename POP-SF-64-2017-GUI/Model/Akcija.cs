using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace POP_SF_64_2017_GUI.Model
{
    public class Akcija
    {
        private Akcija selektovanaAkcija;

        // [NotMapped]
        // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime PocetakAkcije { get; set; }
        public DateTime KrajAkcije { get; set; }
        public double Popust { get; set; }
        public bool Obrisano { get; set; }

        public bool AkcijaPostoji //ovako cemo znati da li je neki namestaj na akciji ili ne
        {
            get
            {
                if(DateTime.Now > PocetakAkcije && DateTime.Now < KrajAkcije)
                {
                    return true;
                }

                return false;
            }
        }

        public Akcija(){

        }

        public Akcija (string naziv, DateTime pocetakAkcije, DateTime krajAkcije, double popust, bool obrisano)
        {
            Naziv = naziv;
            PocetakAkcije = pocetakAkcije;
            KrajAkcije = krajAkcije;
            Popust = popust;
            Obrisano = obrisano;
        }

        public Akcija(Akcija selektovanaAkcija)
        {
            this.selektovanaAkcija = selektovanaAkcija;
        }

        public override string ToString()
        {
            if (AkcijaPostoji)
            {
                return Naziv;
            }
            return "Nema";
        }

        public void Zameni(Akcija a)
        {
            ID = a.ID;
            Naziv = a.Naziv;
            PocetakAkcije = a.PocetakAkcije;
            KrajAkcije = a.KrajAkcije;
            Popust = a.Popust;
            Obrisano = a.Obrisano;
        }
    }
}
