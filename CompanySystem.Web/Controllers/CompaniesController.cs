using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using CompanySystem.Entities;
using CompanySystem.Web.Models;
using Elmah;
using CompanySystem.Web.Filters;
using System.Diagnostics;
using eLearning.Utils;
//using System.Web.Mvc;
//using System.Web.Mvc;

namespace CompanySystem.Web.Controllers
{
    [ElmahError]
    [NlogTrace]
    public class CompaniesController : BaseApiController
    {
        public CompaniesController(ICompanySystemRepository repo) : base(repo)
        {

        }
       
        [HttpGet]
        [ElmahError]
        [ActionName("Companies")]
        public IHttpActionResult GetAllCompanies()
        {
            Trace.WriteLine("Invoking respository to get all companies");

            IQueryable<Company> query;
            query = TheRepository.GetAllCompanies();
            if (query == null)
            {
                return NotFound();
            }
            var result = query
                .ToList()
                .Select(s => TheModelFactory.Create(s));
            return Ok(result);
        }

       
        [HttpGet]
        [ElmahError]
        [ActionName("Companies")]
        [NlogTrace]
        public IHttpActionResult GetCompany(int id)
        {
            Trace.WriteLine("Invoking respository to get company details.");

            var company = TheRepository.GetCompany(id);
            company.CompanyEmployees = TheRepository.GetAllEmployees(id).ToList();
            if (company != null)
            {
                return Ok(company);
            }
            else
            {
                return NotFound();
            }

           
        }

        [HttpPost]
        [ActionName("Company")]
        [NlogTrace]
        public HttpResponseMessage InsertCompany([FromBody] CompanyModel companyModel)
        {
            Trace.WriteLine("Invoking respository to insert a company");

            var entity = TheModelFactory.Parse(companyModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read company details from body");

                if (TheRepository.Insert(entity) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request invalid");
                }
           
        }

        [HttpPut]
        [ActionName("Company")]
        [NlogTrace]
        public HttpResponseMessage Company(int id, [FromBody] CompanyModel companyModel)
        {
            Trace.WriteLine("Invoking respository to update a company");

            var updatedCompany = TheModelFactory.Parse(companyModel);

                if (updatedCompany == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read company details from body");

                var originalCompany = TheRepository.GetCompany(id);

                if (originalCompany == null || originalCompany.Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedCompany.Id = id;
                }

                if (TheRepository.Update(originalCompany, updatedCompany) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedCompany));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }

           
        }

        [HttpDelete]
        [ActionName("Company")]
        [NlogTrace]
        public HttpResponseMessage Company(int id)
        {
            Trace.WriteLine("Invoking respository to delete a company");

            var company = TheRepository.GetCompany(id);
           

                if (company == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (TheRepository.DeleteCompany(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

           
        }

        [HttpPost]
        [ActionName("Employee")]
        public HttpResponseMessage Employee([FromBody] EmployeeModel employeeModel)
        {
            Trace.WriteLine("Invoking respository to insert employee.");

            var entity = TheModelFactory.Parse(employeeModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read employee details from body");

                if (TheRepository.Insert(entity) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            
        }
      
        [HttpGet]
        [ActionName("Employees")]
        public IHttpActionResult Employees()
        {
            Trace.WriteLine("Invoking respository to get all employees");

            IQueryable<Employee> query;
            query = TheRepository.GetAllEmployees();
            if (query == null)
                return NotFound();
            var result = query
                .ToList()
                .Select(s =>
                {
                    s.EmployeeCompany = TheRepository.GetCompany(s.Company_Id);
                    return TheModelFactory.Create(s);
                });
            return Ok(result);
        }

       
        [HttpGet]
        [ActionName("Employees")]
        public HttpResponseMessage Employees(int id)
        {
            Trace.WriteLine("Invoking respository to get employee details.");

            var employee = TheRepository.GetEmployee(id);
                employee.EmployeeCompany = TheRepository.GetCompany(employee.Company_Id);

                if (employee != null)
                {                    
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(employee));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

          
        }
        [HttpPut]
        [ActionName("Employee")]
        public HttpResponseMessage Employee(int id, [FromBody] EmployeeModel employeeModel)
        {
            Trace.WriteLine("Invoking respository to update employee");

            var updatedEmployee = TheModelFactory.Parse(employeeModel);

                if (updatedEmployee == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read Employee details from body");

                var originalEmployee = TheRepository.GetEmployee(id);

                if (originalEmployee == null || originalEmployee.Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Employee is not found");
                }
                else
                {
                    updatedEmployee.Id = id;
                }

                if (TheRepository.Update(originalEmployee, updatedEmployee) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedEmployee));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            
        }

        [HttpDelete]
        [ActionName("Employee")]
        public HttpResponseMessage Employee(int id)
        {
            Trace.WriteLine("Invoking respository to delete employee.");

            var employee = TheRepository.GetEmployee(id);

                if (employee == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (TheRepository.DeleteEmployee(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }           
        }

    }
}