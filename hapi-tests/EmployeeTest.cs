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
            var employee = employeeDao.GetEmployeeById(1);

            Assert.AreEqual(employee.Id, 1);
            Assert.AreEqual(employee.ManagerId, 0);
            Assert.AreEqual(employee.FirstName, "Bob");
            Assert.AreEqual(employee.LastName, "Frank");
            Assert.AreEqual(employee.ContactNo, "+48123456789");
            Assert.AreEqual(employee.Email, "bob@frank.com");
            Assert.AreEqual(employee.Address.City, "BobCity");
            Assert.AreEqual(employee.Address.State, "BobState");
            Assert.AreEqual(employee.Address.Zip, "12345");
        }
    }

}
