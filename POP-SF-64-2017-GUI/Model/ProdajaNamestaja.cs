using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
    public class ProdajaNamestaja
    {
        public int Kolicina { get; set; }
        public string BrojRacuna { get; set; }
        public Korisnik Prodavac { get; set; }
        public string ImeKupca{ get; set; }
        public string PrezimeKupca { get; set; }
        public DateTime DatumProdaje { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
    }

   
}
