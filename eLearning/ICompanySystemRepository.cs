using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySystem.Entities;

namespace CompanySystem
{
    public interface ICompanySystemRepository
    {
        IQueryable<Company> GetAllCompanies();
        Company GetCompany(int companyId);
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployee(int employeeId);

        ////IQueryable<Company> GetCompanyByEmployee(int employeeId);
        ////IQueryable<Employee> GetEmployeesByCompany(int companyId);

        bool Insert(Company company);
        bool Update(Company originalCompany, Company updatedCompany);
        bool DeleteCompany(int id);
        //bool Insert(Employee employee);
        bool Update(Employee originalEmployee, Employee updatedEmployee);
        bool DeleteEmployee(int id);
        bool Insert(Employee employee);
        bool SaveAll();
    }
}
