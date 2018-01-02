using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Utils
{
    public class Context : DbContext
    {
        public Context() : base("dbConnection2017")
        {
            Configuration.LazyLoadingEnabled = false;
           // Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            
            if (Users.Find("admin") == null)
            {
                Users.Add(new Korisnik(0, "admin", "admin", "admin", "admin", TipKorisnika.ADMINISTRATOR));
                SaveChanges();
            }
        }
        public DbSet<Namestaj> Notes { get; set; }
        public DbSet<Korisnik> Users { get; set; }

    }
}
