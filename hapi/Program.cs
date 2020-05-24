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

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetAllEmployees();

            foreach (var employee in employees) Console.WriteLine(employee);
        }
    }
}