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

            //if (Korisnici.Find("admin") == null)
            //{
            //    Korisnici.Add(new Korisnik(0, "admin", "admin", "admin", "admin", TipKorisnika.ADMINISTRATOR));
            //    SaveChanges();
            //}
        }
        public DbSet<Namestaj> Namestaj { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }

    }
}
