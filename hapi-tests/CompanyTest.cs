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

            Assert.AreEqual(company.Id, 1);
            Assert.AreEqual(company.Name, "Test Company");
            Assert.AreEqual(company.Data.ToString(), document.ToString());
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

            Assert.AreEqual(company.Id, 1);
            Assert.AreEqual(company.Name, "Test Company");
            Assert.AreEqual(company.Data.ToString(), document.ToString());
        }

        [TestMethod]
        public void TestAddCompany()
        {
            var document = XDocument.Parse(
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

            var connectionContext = new ConnectionContext(connectionString);
            var companyDao = new CompanyDAO(connectionContext);

            var company = new Company(1, "Other Co.", document);
            companyDao.AddCompany(company);
        }
    }
}