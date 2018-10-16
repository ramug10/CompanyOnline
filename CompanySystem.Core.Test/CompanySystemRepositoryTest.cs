using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CompanySystem.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompanySystem.Core.Test
{    
    [TestClass]
    public class CompanySystemRepositoryTest
    {
        private CompanySystemContext companySystemContext;
        private CompanySystemRepository companySystemRepository;
        private Mock<CompanySystemContext>  mockCompanySystemContext = new Mock<CompanySystemContext>();        

        [TestInitialize]
        public void Initialize()
        {
            //mockCompanySystemContext.SetupGet(context => context.Companies.AsQueryable()).Returns(mockCompanyList);
                                   
            //mockCompanySystemContext.SetupGet(context => context.Employees.AsQueryable()).Returns(mockEmployeeList);
            
            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);
        }


        [TestMethod]
        public void GetAllCompanies_Test()
        {
            var mockCompanyList = (new List<Company>() { new Company() { Id = 1 }, new Company() { Id = 2 } }).AsQueryable();
            var mockDbSetCompany = new Mock<DbSet<Company>>();
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(mockCompanyList.Expression);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(mockCompanyList.ElementType);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(mockCompanyList.GetEnumerator);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Company>(mockCompanyList.Provider));
            mockCompanySystemContext.Setup(context => context.Companies).Returns(mockDbSetCompany.Object);

            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.GetAllCompanies();

            mockCompanySystemContext.Verify(ctxt => ctxt.Companies, Times.Once);
            //Assert.IsInstanceOfType(result, typeof(IQueryable<Company>));
            //Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void GetAllEmployees_Test()
        {
            var mockEmployeeList = (new List<Employee>() { new Employee() { Id = 1 }, new Employee() { Id = 2 } }).AsQueryable();
            var mockDbSetEmployee = new Mock<DbSet<Employee>>();
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(mockEmployeeList.Expression);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(mockEmployeeList.ElementType);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(mockEmployeeList.GetEnumerator);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Employee>(mockEmployeeList.Provider));
            mockCompanySystemContext.Setup(context => context.Employees).Returns(mockDbSetEmployee.Object);

            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.GetAllEmployees();

            mockCompanySystemContext.Verify(ctxt => ctxt.Employees, Times.Once);
           // Assert.IsInstanceOfType(result, typeof(IQueryable<Employee>));
           // Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void GetEmployee_Test()
        {
            var mockEmployeeList = (new List<Employee>() { new Employee() { Id = 1 }, new Employee() { Id = 2 } }).AsQueryable();
            var mockDbSetEmployee = new Mock<DbSet<Employee>>();
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(mockEmployeeList.Expression);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(mockEmployeeList.ElementType);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(mockEmployeeList.GetEnumerator);
            mockDbSetEmployee.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Employee>(mockEmployeeList.Provider));
            mockCompanySystemContext.Setup(context => context.Employees).Returns(mockDbSetEmployee.Object);

            mockCompanySystemContext.Setup((context => context.Employees.Find(It.IsAny<int>()))).Returns(new Employee());

            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.GetEmployee(It.IsAny<int>());

            mockCompanySystemContext.Verify(ctxt => ctxt.Employees.Find(It.IsAny<int>()), Times.Once);
            //Assert.IsInstanceOfType(result, typeof(Employee));
            //Assert.AreEqual(result.Id, 1);
        }


        [TestMethod]
        public void GetCompany_Test()
        {
            var mockCompanyList = (new List<Company>() { new Company() { Id = 1 }, new Company() { Id = 2 } }).AsQueryable();
            var mockDbSetCompany = new Mock<DbSet<Company>>();
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(mockCompanyList.Expression);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(mockCompanyList.ElementType);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(mockCompanyList.GetEnumerator);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Company>(mockCompanyList.Provider));
            mockCompanySystemContext.Setup(context => context.Companies).Returns(mockDbSetCompany.Object);

            mockCompanySystemContext.Setup((context => context.Companies.Find(It.IsAny<int>()))).Returns(new Company());

            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.GetCompany(It.IsAny<int>());

            mockCompanySystemContext.Verify(ctxt => ctxt.Companies.Find(It.IsAny<int>()), Times.Once);

           // Assert.IsInstanceOfType(result, typeof(Company));
           // Assert.AreEqual(result.Id, 1);
        }


        [TestMethod]
        public void InsertCompany_Test()
        {
            var mockCompanyList = (new List<Company>() { new Company() { Id = 1 }, new Company() { Id = 2 } }).AsQueryable();
            var mockDbSetCompany = new Mock<DbSet<Company>>();
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(mockCompanyList.Expression);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(mockCompanyList.ElementType);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(mockCompanyList.GetEnumerator);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Company>(mockCompanyList.Provider));
            mockCompanySystemContext.Setup(context => context.Companies).Returns(mockDbSetCompany.Object);

            mockCompanySystemContext.Setup((context => context.Companies.Add(It.IsAny<Company>()))).Returns(It.IsAny<Company>());  
            
            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.Insert(It.IsAny<Company>());

            mockCompanySystemContext.Verify(ctxt => ctxt.Companies.Add(It.IsAny<Company>()), Times.Once);

            // Assert.IsInstanceOfType(result, typeof(Company));
            // Assert.AreEqual(result.Id, 1);
        }

        [TestMethod]        
        public void InsertCompany_Exception_Test()
        {
            var mockCompanyList = (new List<Company>() { new Company() { Id = 1 }, new Company() { Id = 2 } }).AsQueryable();
            var mockDbSetCompany = new Mock<DbSet<Company>>();
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(mockCompanyList.Expression);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(mockCompanyList.ElementType);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(mockCompanyList.GetEnumerator);
            mockDbSetCompany.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(new AsyncQueryProvider<Company>(mockCompanyList.Provider));
            mockCompanySystemContext.Setup(context => context.Companies).Returns(mockDbSetCompany.Object);

            mockCompanySystemContext.Setup((context => context.Companies.Add(It.IsAny<Company>()))).Throws<ArgumentException>();

            companySystemContext = mockCompanySystemContext.Object;
            companySystemRepository = new CompanySystemRepository(companySystemContext);

            var result = companySystemRepository.Insert(It.IsAny<Company>());

            mockCompanySystemContext.Verify(ctxt => ctxt.Companies.Add(It.IsAny<Company>()), Times.Once);

            // Assert.IsInstanceOfType(result, typeof(Company));
            // Assert.AreEqual(result.Id, 1);
        }

    }
}
