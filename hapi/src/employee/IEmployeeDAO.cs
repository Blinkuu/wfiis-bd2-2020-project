using System.Collections.Generic;

namespace hapi.employee
{
    public interface IEmployeeDAO
    {
        public Employee GetEmployeeById(string id);

        public List<Employee> GetEmployeesByFullName(string firstName, string lastName);

        public List<Employee> GetEmployeesByFirstName(string firstName);

        public List<Employee> GetEmployeesByLastName(string lastName);

        public List<Employee> GetAllEmployees();

        public Employee GetManagerByEmployeeId(string id);

        public List<Employee> GetStaffByEmployeeId(string id);

        public void AddEmployee(Employee employee);

        public void RemoveEmployeeById(string id);
    }
}