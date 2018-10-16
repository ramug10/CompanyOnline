using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.Entities
{
    public class Company
    {
        public Company()
        {
            CompanyEmployees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Phone_Number { get; set; }
        public ICollection<Employee> CompanyEmployees { get; set; }
    }

    public class Employee
    {
        public Employee()
        {
            EmployeeCompany = new Company();
        }
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public string Salary { get; set; }
        public string Email { get; set; }        
        public int Company_Id { get; set; }

        [ForeignKey("Company_Id")]
        public Company EmployeeCompany { get; set; }
    }
}
