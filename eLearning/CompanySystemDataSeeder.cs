using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySystem.Entities;
using CompanySystem.Mappers;

namespace CompanySystem.Data
{
    class CompanySystemDataSeeder
    {
        CompanySystemContext _ctx;
        public CompanySystemDataSeeder(CompanySystemContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            try
            {
                for (int i = 0; i < companyNames.Length; i++)
                {
                    var companyDetails = SplitValue(companyNames[i]);
                    var company = new Company
                    {
                        Id = int.Parse(companyDetails[0]),
                        Name = companyDetails[1],
                        Address = companyDetails[2],
                        Website = companyDetails[3],
                        Phone_Number = companyDetails[4]
                    };
                    _ctx.Companies.Add(company);
                    _ctx.SaveChanges();
                }
                for (int j = 0; j < employeeNames.Length; j++)
                {
                    var employeeDetails = SplitValue(employeeNames[j]);
                    //var employee = new Employee
                    //{
                    //    Id = int.Parse(employeeDetails[0]),
                    //    First_Name = employeeDetails[1],
                    //    Last_Name = employeeDetails[2],
                    //    Address = employeeDetails[3],
                    //    Phone_Number = employeeDetails[4],
                    //    Salary = employeeDetails[5],
                    //    Email = employeeDetails[6],
                    //    Company_Id = employeeDetails[7]
                    //};
                    //_ctx.Employees.Add(employee);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                throw ex;
            }
        }

        private static string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        static string[] companyNames =
        {
            "CTS,Cognizant Technology Solutions,India,www.cts.com,9874836348",
            "TCS,Tata Consultancy Services,India,www.tcs.com,8747484635",
            "HTC,HTC Corporation Limited,New Taipei city,www.htc.com,9835222132",
            "HSBC,The Hongkong and Shangai Banking Corporation Limited,Hong Kong,www.hsbc.com,7893534333",
            "IBM,International Business Machines Corporation,New York,www.ibm.com,8884536252",
            "IKEA,Ingvar Kamprad Elmtaryd,Netherlands,www.ikea.com,9993737888",
            "SAS,Scandinavian Airlines System Aktiebolag,Sweden,www.sas.com,9356666373",
            "AXA,AXA Groups,France,www.axa.com,8974555444"
        };

        static string[] employeeNames =
        {
            "101,Skyler,Beckman,Houston,9874636666,100K,Skyler.Beckman@cts.com,CTS",
            "102,Daniel,cheffee,Austin,9998633666,90K,Daniel.Cheffee@tcs.com,TCS",
            "103,Tabitha,Lumpkins,Dallas,83738383292,110K,Tabitha.Lumpkins@htc.com,HTC",
            "104,Wanda,Smith,Chicago,83738383292,120K,Wanda.Smith@hsbc.com,HSBC",
            "105,James,Garcia,Boston,9835222132,100K,James.Garcia@ibm.com,IBM",
            "106,David,Smith,New York,83738383292,110K,David.Smith@ikea.com,IKEA",
            "107,Maria,Rodriguez,Tampa,8747484635,120K,Maria.Rodriguez@sas.com,SAS",
            "108,Mary,Hernandez,Orlando,9356666373,90K,Mary.Hernandez@axa.com,AXA",
            "109,Michael,Lumpkins,Miami,9874836348,100K,Michael.Lumpkins@cts.com,CTS",
            "110,Sambasiva Rao,Nalamala,Hyderabad,83738383292,110K,Tabitha.Lumpkins@tcs.com,TCS",
            "111,Raghu,Pathuri,Mumbai,83738383292,120K,Wanda.Smith@htc.com,HTC",
            "112,Narendra,Raavi,Chennai,9835222132,100K,James.Garcia@hsbc.com,HSBC",
            "113,Anusha,Muppalla,Kolkata,83738383292,110K,David.Smith@ibm.com,IBM",
            "114,Lalitha,Ghannamaneeni,Bangalor,8747484635,120K,Maria.Rodriguez@ikea.com,IKEA",
            "115,Suman,Vankayalapati,Pune,9356666373,90K,Mary.Hernandez@sas.com,SAS",
            "116,Santhosh,Nannapaneeni,Chennai,9874836348,100K,Michael.Lumpkins@axa.com,AXA"
        };

    }
}
