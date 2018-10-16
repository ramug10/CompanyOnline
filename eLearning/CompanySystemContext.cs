using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompanySystem;
using CompanySystem.Entities;
using CompanySystem.Mappers;

public class CompanySystemContext : DbContext
{
    public CompanySystemContext() :
        base("name=companySystemConnection")
    {
        Configuration.ProxyCreationEnabled = false;
        Configuration.LazyLoadingEnabled = false;

        if (Database.Exists())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanySystemContext, CompanySystemContextMigrationConfiguration>());
        }
    }

    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //modelBuilder.Configurations.Add(new CompanyMapper());
        //modelBuilder.Configurations.Add(new EmployeeMapper());

        //base.OnModelCreating(modelBuilder);
    }
}
