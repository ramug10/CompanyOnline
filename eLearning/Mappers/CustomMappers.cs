using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using CompanySystem.Entities;

namespace CompanySystem.Mappers
{
    class CompanyMapper : EntityTypeConfiguration<Company>
    {
        public CompanyMapper()
        {
            this.ToTable("Companies");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Code).IsRequired();
            this.Property(c => c.Code).HasMaxLength(255);

            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Name).HasMaxLength(255);

            this.Property(c => c.Address).IsRequired();
            this.Property(c => c.Address).HasMaxLength(255);

            this.Property(c => c.Phone_Number).IsOptional();
            this.Property(c => c.Phone_Number).HasMaxLength(14);
        }
    }

    class EmployeeMapper : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapper()
        {
            this.ToTable("Employees");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.First_Name).IsRequired();
            this.Property(c => c.First_Name).HasMaxLength(255);

            this.Property(c => c.Last_Name).IsRequired();
            this.Property(c => c.Last_Name).HasMaxLength(255);

            this.Property(c => c.Address).IsRequired();
            this.Property(c => c.Address).HasMaxLength(255);

            this.Property(c => c.Phone_Number).IsRequired();
            this.Property(c => c.Phone_Number).HasMaxLength(255);

            this.Property(c => c.Salary).IsRequired();
            this.Property(c => c.Salary).HasMaxLength(255);

            this.Property(c => c.Email).IsRequired();
            this.Property(c => c.Email).HasMaxLength(255);

            this.Property(c => c.Company_Id).IsRequired();
            //this.Property(c => c.Company_Id).HasMaxLength(255);

            this.HasRequired(c => c.EmployeeCompany).WithMany().Map(s => s.MapKey("Company_Id"));

        }
    }
}
