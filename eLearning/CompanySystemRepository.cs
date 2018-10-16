using System;
using System.Linq;
using System.Reflection;
using CompanySystem.Entities;
using eLearning.Utils;
using log4net;

namespace CompanySystem
{    
    public class CompanySystemRepository : ICompanySystemRepository
    {
        private CompanySystemContext _ctx;
        private ILog _logger;

        public CompanySystemRepository(CompanySystemContext ctx)
        {
            _ctx = ctx;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        #region Commented
        //public IQueryable<Company> GetAllCompanies()
        //{
        //    var obj1 = new Company();
        //    obj1.Id = 1;
        //    obj1.Name = "CTS";
        //    obj1.Phone_Number = "8987774464";
        //    obj1.Website = "www.CTS.com";
        //    var obj2 = new Company();
        //    obj2.Id = 2;
        //    obj2.Name = "TCS";
        //    obj2.Phone_Number = "7784884777";
        //    obj2.Website = "www.TCS.com";
        //    var tempList = new List<Company>();
        //    tempList.Add(obj1);
        //    tempList.Add(obj2);
        //    return tempList.AsQueryable();
        //}

        //public Company GetCompany(int companyId)
        //{
        //    var obj = new Company();
        //    obj.Id = 1;
        //    obj.Name = "CTS";
        //    obj.Phone_Number = "8987774464";
        //    obj.Website = "www.CTS.com";
        //    return obj;
        //}

        //public IQueryable<Employee> GetAllEmployees()
        //{
        //    var obj1 = new Employee();
        //    obj1.Id = 1;
        //    obj1.First_Name = "samba";
        //    obj1.Last_Name = "nalamala";
        //    obj1.Address = "TestAddress1";
        //    obj1.Phone_Number = "9899994654";
        //    obj1.Salary = "100K";
        //    obj1.Email = "samba.nalamala@gmail.com";
        //    obj1.Company_Id = "TCS";

        //    var obj2 = new Employee();
        //    obj1.Id = 2;
        //    obj1.First_Name = "siva";
        //    obj1.Last_Name = "Pathuri";
        //    obj1.Address = "TestAddress2";
        //    obj1.Phone_Number = "8884545667";
        //    obj1.Salary = "120K";
        //    obj1.Email = "siva.pathuri@gmail.com";
        //    obj1.Company_Id = "CTS";
        //    var tempList = new List<Employee>();
        //    tempList.Add(obj1);
        //    tempList.Add(obj2);
        //    return tempList.AsQueryable();
        //    //return _ctx.Employees.AsQueryable();
        //}
        //public Employee GetEmployee(int employeeId)
        //{
        //    var obj = new Employee();
        //    obj.Id = 1;
        //    obj.First_Name = "samba";
        //    obj.Last_Name = "nalamala";
        //    obj.Address = "TestAddress1";
        //    obj.Phone_Number = "9899994654";
        //    obj.Salary = "100K";
        //    obj.Email = "samba.nalamala@gmail.com";
        //    obj.Company_Id = "TCS";
        //    return obj;
        //    //return _ctx.Employees.Find(employeeId);
        //}
        #endregion
        
        [NlogTrace]
        public IQueryable<Company> GetAllCompanies()
        {
            _logger.Info("Log - Gets all companies from database");
            return _ctx.Companies.AsQueryable();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _ctx.Employees.AsQueryable();
        }

        
        public Company GetCompany(int companyId)
        {
            return _ctx.Companies.Find(companyId);
        }

        public Employee GetEmployee(int employeeId)
        {
            return _ctx.Employees.Find(employeeId);
        }

        public bool Insert(Company company)
        {
            try
            {
                _logger.Info("Inserting new Company to database");
                _ctx.Companies.Add(company);
                return true;
            }
            catch(Exception ex)
            {
                _logger.Error("Error on inserting company", ex);
                return false;
            }
        }

        public bool Update(Company originalCompany, Company updatedCompany)
        {
            _ctx.Entry(originalCompany).CurrentValues.SetValues(updatedCompany);
            //_ctx.Entry(updatedCompany).State = System.Data.Entity.EntityState.Modified;
            return true;
        }

        public bool DeleteCompany(int id)
        {
            try
            {
                var entity = _ctx.Companies.Find(id);
                if (entity != null)
                {
                    _ctx.Companies.Remove(entity);
                    return true;
                }
                return true;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return false;
        }

        public bool Insert(Employee employee)
        {
            try
            {
                Company ecmp;
                ecmp = _ctx.Companies.Find(employee.Company_Id);
                if (ecmp != null)
                {
                    Employee emp = new Employee
                    {
                        Id = employee.Id,
                        First_Name = employee.First_Name,
                        Last_Name = employee.Last_Name,
                        Address = employee.Address,
                        Phone_Number = employee.Phone_Number,
                        Salary = employee.Salary,
                        Email = employee.Email,
                        Company_Id = employee.Company_Id,
                        EmployeeCompany = ecmp
                    };
                    ecmp.CompanyEmployees.Add(emp);
                }
                else
                {
                    _ctx.Employees.Add(employee);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            
            return false;
            }
        }

        public bool Update(Employee originalEmployee, Employee updatedEmployee)
        {
            _ctx.Entry(originalEmployee).CurrentValues.SetValues(updatedEmployee);
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var entity = _ctx.Employees.Find(id);
                if (entity != null)
                {
                    _ctx.Employees.Remove(entity);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return false;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
            //return true;
        }
    }
}
