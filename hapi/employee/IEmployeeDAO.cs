using System.Collections.Generic;

namespace hapi.employee
{
    internal interface IEmployeeDAO
    {

        public Employee GetEmployeeById(int id);

        public List<Employee> GetEmployeesByFullName(string firstName, string lastName);

        public List<Employee> GetEmployeesByFirstName(string firstName);

        public List<Employee> GetEmployeesByLastName(string lastName);

        public List<Employee> GetAllEmployees();

        public Employee GetManagerByEmployeeId(int id);

        public List<Employee> GetStaffByManagerId(int id);

        public void AddEmployee(Employee employee);
    }
}