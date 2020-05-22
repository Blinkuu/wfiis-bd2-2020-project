using hapi.company;
using System;
using System.Configuration;


namespace hapi
{
    public class Program
    {
        private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";
        static void Main(string[] args)
        {
            var connectionContext = new hapi.context.ConnectionContext(connectionString);

            var companyDAO = new CompanyDAO(connectionContext);
            var company = companyDAO.GetCompany("Test Company");

            Console.WriteLine(company);
        }
    }
}
