using System;
using System.Xml.Linq;
using hapi.company;
using hapi.context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hapi_tests
{
    [TestClass]
    public class CompanyTest
    {
        private static readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        [TestMethod]
        public void TestGetCompanyById()
        {
            var document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <Employee>
                    <EmployeeID>1</EmployeeID>
                    <ManagerID xsi:nil = ""true""/>
                    <FirstName>Bob</FirstName>
                    <LastName>Frank</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>bob@frank.com</Email>
                    <Address>
                      <City>BobCity</City>
                      <State>BobState</State>
                      <Zip>12345</Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmployeeID>2</EmployeeID>
                    <ManagerID>1</ManagerID>
                    <FirstName>Michael</FirstName>
                    <LastName>Ross</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>michale@ross.com</Email>
                    <Address>
                      <City>MichaelCity</City>
                      <State>MichaelState</State>
                      <Zip>12345</Zip>
                    </Address>
                  </Employee>
                </Company>");

            var connectionContext = new ConnectionContext(connectionString);

            var companyDao = new CompanyDAO(connectionContext);
            var company = companyDao.GetCompanyById(1);

            Assert.AreEqual(1, company.Id);
            Assert.AreEqual("Test Company", company.Name);
            Assert.AreEqual(document.ToString(), company.Data.ToString());
        }

        [TestMethod]
        public void TestGetCompanyByName()
        {
            var document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <Employee>
                    <EmployeeID>1</EmployeeID>
                    <ManagerID xsi:nil = ""true""/>
                    <FirstName>Bob</FirstName>
                    <LastName>Frank</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>bob@frank.com</Email>
                    <Address>
                      <City>BobCity</City>
                      <State>BobState</State>
                      <Zip>12345</Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmployeeID>2</EmployeeID>
                    <ManagerID>1</ManagerID>
                    <FirstName>Michael</FirstName>
                    <LastName>Ross</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>michale@ross.com</Email>
                    <Address>
                      <City>MichaelCity</City>
                      <State>MichaelState</State>
                      <Zip>12345</Zip>
                    </Address>
                  </Employee>
                </Company>");

            var connectionContext = new ConnectionContext(connectionString);

            var companyDao = new CompanyDAO(connectionContext);
            var company = companyDao.GetCompanyByName("Test Company");

            Assert.AreEqual(1, company.Id);
            Assert.AreEqual("Test Company", company.Name);
            Assert.AreEqual(document.ToString(), company.Data.ToString());
        }

        [TestMethod]
        public void TestAddCompany()
        {
            var document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <Employee>
                    <EmployeeID>1</EmployeeID>
                    <ManagerID xsi:nil = ""true""/>
                    <FirstName>Bob</FirstName>
                    <LastName>Frank</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>bob@frank.com</Email>
                    <Address>
                      <City> BobCity </City>
                      <State> BobState </State>
                      <Zip> 12345 </Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmployeeID>2</EmployeeID>
                    <ManagerID>1</ManagerID>
                    <FirstName>Michael</FirstName>
                    <LastName>Ross</LastName>
                    <ContactNo>+48123456789</ContactNo>
                    <Email>michale@ross.com</Email>
                    <Address>
                      <City>MichaelCity</City>
                      <State>MichaelState</State>
                      <Zip>12345</Zip>
                    </Address>
                  </Employee>
                </Company>
                ");

            var connectionContext = new ConnectionContext(connectionString);

            var companyDao = new CompanyDAO(connectionContext);

            var company = new Company("Other Co. " + Guid.NewGuid(), document);
            companyDao.AddCompany(company);
        }
    }
}