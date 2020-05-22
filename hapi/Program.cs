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

            var companyDAO = new CompanyDAO(connectionContext);
            var singleCompany = companyDAO.GetCompany("Test Company");
            Console.WriteLine(singleCompany);
        }
    }
}