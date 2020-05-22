using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Xml.Linq;

namespace hapi_tests
{
    [TestClass]
    public class CompanyTest
    {
        private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        [TestMethod]
        public void TestGetCompanyById()
        {
            XDocument document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <Employee>
                    <EmployeeID> 1 </EmployeeID>
                    <ManagerID xsi:nil = ""true""/>
                    <FirstName> Bob </FirstName>
                    <LastName> Frank </LastName>
                    <ContactNo> +48 123 456 789 </ContactNo>
                    <Email> bob@frank.com </Email>
                    <Address>
                      <City> BobCity </City>
                      <State> BobState </State>
                      <Zip> 12345 </Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmployeeID> 2 </EmployeeID>
                    <ManagerID> 1 </ManagerID>
                    <FirstName> Michael </FirstName>
                    <LastName> Ross </LastName>
                    <ContactNo> +48 123 456 789 </ContactNo>
                    <Email> michale@ross.com </Email>
                    <Address>
                      <City> MichaelCity </City>
                      <State> MichaelState </State>
                      <Zip> 12345 </Zip>
                    </Address>
                  </Employee>
                </Company>
                ");

            var connectionContext = new hapi.context.ConnectionContext(connectionString);

            var companyDAO = new hapi.company.CompanyDAO(connectionContext);
            var company = companyDAO.GetCompany(1);

            Assert.AreEqual(company.id, 1);
            Assert.AreEqual(company.name, "Test Company");
            Assert.AreEqual(company.data.ToString(), document.ToString());
        }

        [TestMethod]
        public void TestGetCompanyByName()
        {
            XDocument document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <Employee>
                    <EmployeeID> 1 </EmployeeID>
                    <ManagerID xsi:nil = ""true""/>
                    <FirstName> Bob </FirstName>
                    <LastName> Frank </LastName>
                    <ContactNo> +48 123 456 789 </ContactNo>
                    <Email> bob@frank.com </Email>
                    <Address>
                      <City> BobCity </City>
                      <State> BobState </State>
                      <Zip> 12345 </Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmployeeID> 2 </EmployeeID>
                    <ManagerID> 1 </ManagerID>
                    <FirstName> Michael </FirstName>
                    <LastName> Ross </LastName>
                    <ContactNo> +48 123 456 789 </ContactNo>
                    <Email> michale@ross.com </Email>
                    <Address>
                      <City> MichaelCity </City>
                      <State> MichaelState </State>
                      <Zip> 12345 </Zip>
                    </Address>
                  </Employee>
                </Company>
                ");
            
            var connectionContext = new hapi.context.ConnectionContext(connectionString);

            var companyDAO = new hapi.company.CompanyDAO(connectionContext);
            var company = companyDAO.GetCompany("Test Company");

            Assert.AreEqual(company.id, 1);
            Assert.AreEqual(company.name, "Test Company");
            Assert.AreEqual(company.data.ToString(), document.ToString());
        }
    }
}
