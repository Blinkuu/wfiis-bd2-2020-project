using System;
using hapi.context;
using hapi.employee;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hapi_tests
{
    [TestClass]
    public class EmployeeTest
    {
        private static readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        [TestMethod]
        public void TestGetEmployeeById()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employee = employeeDao.GetEmployeeById("1");

            Assert.AreEqual(employee.Id, "1");
            Assert.AreEqual(employee.ManagerId, "0");
            Assert.AreEqual(employee.FirstName, "Bob");
            Assert.AreEqual(employee.LastName, "Frank");
            Assert.AreEqual(employee.ContactNo, "+48123456789");
            Assert.AreEqual(employee.Email, "bob@frank.com");
            Assert.AreEqual(employee.Address.City, "BobCity");
            Assert.AreEqual(employee.Address.State, "BobState");
            Assert.AreEqual(employee.Address.Zip, "12345");
        }

        [TestMethod]
        public void TestGetEmployeesByFullName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByFullName("Bob", "Frank");

            Assert.AreEqual(employees[0].Id, "1");
            Assert.AreEqual(employees[0].ManagerId, "0");
            Assert.AreEqual(employees[0].FirstName, "Bob");
            Assert.AreEqual(employees[0].LastName, "Frank");
            Assert.AreEqual(employees[0].ContactNo, "+48123456789");
            Assert.AreEqual(employees[0].Email, "bob@frank.com");
            Assert.AreEqual(employees[0].Address.City, "BobCity");
            Assert.AreEqual(employees[0].Address.State, "BobState");
            Assert.AreEqual(employees[0].Address.Zip, "12345");
        }

        [TestMethod]
        public void TestGetEmployeesByFirstName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByFirstName("Bob");

            Assert.AreEqual(employees[0].Id, "1");
            Assert.AreEqual(employees[0].ManagerId, "0");
            Assert.AreEqual(employees[0].FirstName, "Bob");
            Assert.AreEqual(employees[0].LastName, "Frank");
            Assert.AreEqual(employees[0].ContactNo, "+48123456789");
            Assert.AreEqual(employees[0].Email, "bob@frank.com");
            Assert.AreEqual(employees[0].Address.City, "BobCity");
            Assert.AreEqual(employees[0].Address.State, "BobState");
            Assert.AreEqual(employees[0].Address.Zip, "12345");
        }

        [TestMethod]
        public void TestGetEmployeesByLastName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByLastName("Frank");

            Assert.AreEqual(employees[0].Id, "1");
            Assert.AreEqual(employees[0].ManagerId, "0");
            Assert.AreEqual(employees[0].FirstName, "Bob");
            Assert.AreEqual(employees[0].LastName, "Frank");
            Assert.AreEqual(employees[0].ContactNo, "+48123456789");
            Assert.AreEqual(employees[0].Email, "bob@frank.com");
            Assert.AreEqual(employees[0].Address.City, "BobCity");
            Assert.AreEqual(employees[0].Address.State, "BobState");
            Assert.AreEqual(employees[0].Address.Zip, "12345");
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetAllEmployees();

            Assert.AreNotEqual(employees.Count, 0);
        }

        [TestMethod]
        public void GetManagerByEmployeeId()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetStaffByManagerId()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Other Co.");
            var employee = new Employee("1", "TestFirstName", "TestLastName", "+48987654321", "test@test.com",
                new Address("TestCity", "TestState", "54321"));

            employeeDao.AddEmployee(employee);
        }
    }
}