using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Baza
{
    public class Context : DbContext
    {
        public Context() : base("dbConnection2017")
        {
            Configuration.LazyLoadingEnabled = false;
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            if (Korisnici.Find(1) == null)
            {
                Korisnici.Add(new Korisnik(1, "admin", "admin", "admin", "admin", TipKorisnika.ADMINISTRATOR));
                SaveChanges();
            }
        }

       

        public DbSet<Namestaj> Namestaji { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Akcija> Akcije { get; set; }
        public DbSet<TipNamestaja> TipoviNamestaja { get; set; }
    }
}
