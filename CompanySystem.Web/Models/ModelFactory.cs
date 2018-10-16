using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using CompanySystem.Entities;

namespace CompanySystem.Web.Models
{
    public class ModelFactory
    {
        private System.Web.Http.Routing.UrlHelper _UrlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _UrlHelper = new System.Web.Http.Routing.UrlHelper(request);
        }

        public CompanyModel Create(Company company)
        {
            return new CompanyModel()
            {
                Url = _UrlHelper.Link("Companies", new { id = company.Id }),
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                Address = company.Address,
                Website = company.Website,
                Phone_Number = company.Phone_Number,
                //CompanyEmployees = Create(company.CompanyEmployees)
            };
        }

        public EmployeeModel Create(Employee employee)
        {
            return new EmployeeModel()
            {
                Id = employee.Id,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Address = employee.Address,
                Phone_Number = employee.Phone_Number,
                Salary = employee.Salary,
                Email = employee.Email,
                Company_Id = employee.Company_Id,
                EmployeeCompany = Create(employee.EmployeeCompany)
            };


        }
        public Company Parse(CompanyModel model)
        {
            try
            {
                var company = new Company()
                {
                    Code = model.Code,
                    Name = model.Name,
                    Address = model.Address,
                    Website = model.Website,
                    Phone_Number = model.Phone_Number
                };

                return company;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Employee Parse(EmployeeModel model)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = model.Id,
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Address = model.Address,
                    Phone_Number = model.Phone_Number,
                    Salary = model.Salary,
                    Email = model.Email,
                    Company_Id = model.Company_Id                                       
                };

                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}