using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    class EFContext:DbContext
    {
        public EFContext():base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>() //Faz com que o BD seja recriado toda vez que uma modificação acontecer
                );
        }

        public DbSet<Cargo> Cargos { get; set; }
    }
}
