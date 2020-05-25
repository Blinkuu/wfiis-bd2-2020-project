using System;
using System.Xml.Linq;
using hapi.company;
using hapi.context;

namespace example
{
    public class Program
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        public static void Main(string[] args)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var document = XDocument.Parse(
                @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""/>");

            var companyDao = new CompanyDAO(connectionContext);
            companyDao.AddCompany(new Company("Example Co.", document));

            var company = companyDao.GetCompanyByName("Example Co.");
            Console.WriteLine(company);

            companyDao.RemoveCompanyByName("Example Co.");
        }
    }
}