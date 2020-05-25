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

            Assert.AreEqual("1", employee.Id);
            Assert.AreEqual("0", employee.ManagerId);
            Assert.AreEqual("Bob", employee.FirstName);
            Assert.AreEqual("Frank", employee.LastName);
            Assert.AreEqual("+48123456789", employee.ContactNo);
            Assert.AreEqual("bob@frank.com", employee.Email);
            Assert.AreEqual("BobCity", employee.Address.City);
            Assert.AreEqual("BobState", employee.Address.State);
            Assert.AreEqual("12345", employee.Address.Zip);
        }

        [TestMethod]
        public void TestGetEmployeesByFullName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByFullName("Bob", "Frank");

            Assert.AreEqual("1", employees[0].Id);
            Assert.AreEqual("0", employees[0].ManagerId);
            Assert.AreEqual("Bob", employees[0].FirstName);
            Assert.AreEqual("Frank", employees[0].LastName);
            Assert.AreEqual("+48123456789", employees[0].ContactNo);
            Assert.AreEqual("bob@frank.com", employees[0].Email);
            Assert.AreEqual("BobCity", employees[0].Address.City);
            Assert.AreEqual("BobState", employees[0].Address.State);
            Assert.AreEqual("12345", employees[0].Address.Zip);
        }

        [TestMethod]
        public void TestGetEmployeesByFirstName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByFirstName("Bob");

            Assert.AreEqual("1", employees[0].Id);
            Assert.AreEqual("0", employees[0].ManagerId);
            Assert.AreEqual("Bob", employees[0].FirstName);
            Assert.AreEqual("Frank", employees[0].LastName);
            Assert.AreEqual("+48123456789", employees[0].ContactNo);
            Assert.AreEqual("bob@frank.com", employees[0].Email);
            Assert.AreEqual("BobCity", employees[0].Address.City);
            Assert.AreEqual("BobState", employees[0].Address.State);
            Assert.AreEqual("12345", employees[0].Address.Zip);
        }

        [TestMethod]
        public void TestGetEmployeesByLastName()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetEmployeesByLastName("Frank");

            Assert.AreEqual("1", employees[0].Id);
            Assert.AreEqual("0", employees[0].ManagerId);
            Assert.AreEqual("Bob", employees[0].FirstName);
            Assert.AreEqual("Frank", employees[0].LastName);
            Assert.AreEqual("+48123456789", employees[0].ContactNo);
            Assert.AreEqual("bob@frank.com", employees[0].Email);
            Assert.AreEqual("BobCity", employees[0].Address.City);
            Assert.AreEqual("BobState", employees[0].Address.State);
            Assert.AreEqual("12345", employees[0].Address.Zip);
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetAllEmployees();

            Assert.AreEqual("1", employees[0].Id);
            Assert.AreEqual("0", employees[0].ManagerId);
            Assert.AreEqual("Bob", employees[0].FirstName);
            Assert.AreEqual("Frank", employees[0].LastName);
            Assert.AreEqual("+48123456789", employees[0].ContactNo);
            Assert.AreEqual("bob@frank.com", employees[0].Email);
            Assert.AreEqual("BobCity", employees[0].Address.City);
            Assert.AreEqual("BobState", employees[0].Address.State);
            Assert.AreEqual("12345", employees[0].Address.Zip);
        }

        [TestMethod]
        public void TestGetManagerByEmployeeId()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employee = employeeDao.GetManagerByEmployeeId("2");

            Assert.AreEqual("1", employee.Id);
            Assert.AreEqual("0", employee.ManagerId);
            Assert.AreEqual("Bob", employee.FirstName);
            Assert.AreEqual("Frank", employee.LastName);
            Assert.AreEqual("+48123456789", employee.ContactNo);
            Assert.AreEqual("bob@frank.com", employee.Email);
            Assert.AreEqual("BobCity", employee.Address.City);
            Assert.AreEqual("BobState", employee.Address.State);
            Assert.AreEqual("12345", employee.Address.Zip);
        }

        [TestMethod]
        public void TestGetStaffByEmployeeId()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Test Company");
            var employees = employeeDao.GetStaffByEmployeeId("1");

            Assert.AreEqual("2", employees[0].Id);
            Assert.AreEqual("1", employees[0].ManagerId);
            Assert.AreEqual("Michael", employees[0].FirstName);
            Assert.AreEqual("Ross", employees[0].LastName);
            Assert.AreEqual("+48123456789", employees[0].ContactNo);
            Assert.AreEqual("michale@ross.com", employees[0].Email);
            Assert.AreEqual("MichaelCity", employees[0].Address.City);
            Assert.AreEqual("MichaelState", employees[0].Address.State);
            Assert.AreEqual("12345", employees[0].Address.Zip);

            Assert.AreEqual("3", employees[1].Id);
            Assert.AreEqual("1", employees[1].ManagerId);
            Assert.AreEqual("Ricky", employees[1].FirstName);
            Assert.AreEqual("Boss", employees[1].LastName);
            Assert.AreEqual("+48123456789", employees[1].ContactNo);
            Assert.AreEqual("ricky@boss.com", employees[1].Email);
            Assert.AreEqual("RickyCity", employees[1].Address.City);
            Assert.AreEqual("RickyState", employees[1].Address.State);
            Assert.AreEqual("14578", employees[1].Address.Zip);
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

        [TestMethod]
        public void TestRemoveEmployeeById()
        {
            var connectionContext = new ConnectionContext(connectionString);

            var employeeDao = new EmployeeDAO(connectionContext, "Other Co.");
            var employee = new Employee("123456789", "1", "TestFirstName", "TestLastName", "+48987654321", "test@test.com",
                new Address("TestCity", "TestState", "54321"));

            employeeDao.AddEmployee(employee);

            employeeDao.RemoveEmployeeById("123456789");
        }
    }
}