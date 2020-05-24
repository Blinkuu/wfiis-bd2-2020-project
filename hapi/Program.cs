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
            var employee = employeeDao.GetEmployeeById("1");

            Console.WriteLine(employee);

            //var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            //var employee = new Employee("1", "TestFirstName", "TestLastName", "+48987654321", "test@test.com",
            //    new Address("TestCity", "TestState", "54321"));

            //employeeDao.AddEmployee(employee);
        }
    }
}