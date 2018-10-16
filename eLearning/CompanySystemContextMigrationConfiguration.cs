using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using CompanySystem.Data;

namespace CompanySystem
{
    class CompanySystemContextMigrationConfiguration : DbMigrationsConfiguration<CompanySystemContext>
    {
        public CompanySystemContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

#if DEBUG
        //protected override void Seed(CompanySystemContext context)
        //{
        //    //new CompanySystemDataSeeder(context).Seed();
        //}
#endif

    }
}


