using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Baza
{
    public class DBConfiguration : DbMigrationsConfiguration<Context>
    {
        public DBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Database";
        }
    }
}
