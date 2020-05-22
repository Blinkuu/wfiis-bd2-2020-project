using System;
using hapi.company;
using hapi.context;

namespace hapi
{
    public class Program
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        private static void Main(string[] args)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var companyDao = new CompanyDAO(connectionContext);
            var company = companyDao.GetCompanyByName("Test Company");

            // var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            Console.WriteLine(company);
        }
    }
}