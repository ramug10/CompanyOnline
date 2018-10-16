using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanySystem.Web.Models
{
    public class CompanyModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Phone_Number { get; set; }
        public ICollection<EmployeeModel> CompanyEmployees { get; set; }
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public string Salary { get; set; }
        public string Email { get; set; }
        public int Company_Id { get; set; }
        public CompanyModel EmployeeCompany { get; set; }
    }
}