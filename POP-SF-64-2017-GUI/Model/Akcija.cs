using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
    public class Akcija
    {
        public static int ID = 0;
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
            ID++;
            Naziv = naziv;
            PocetakAkcije = pocetakAkcije;
            KrajAkcije = krajAkcije;
            Popust = popust;
            Obrisano = obrisano;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", PocetakAkcije.ToShortDateString(), KrajAkcije.ToShortDateString());
        }
    }
}
