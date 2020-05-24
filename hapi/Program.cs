using System;
using hapi.context;
using hapi.employee;

namespace hapi
{
    public class Program
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        private static void Main(string[] args)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Other Co.");
            var employee = employeeDao.GetManagerByEmployeeId("fd6b7c83-d699-4a5b-9284-00c783a9162c");

            Console.WriteLine(employee);
        }
    }
}