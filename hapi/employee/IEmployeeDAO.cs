using System;
using System.Collections.Generic;
using System.Text;

namespace hapi.employee
{
    interface IEmployeeDAO
    {
        public Employee GetEmployeeById(int id);

        public List<Employee> GetEmployeesByFullName(string firstName, string lastName);

        public List<Employee> GetEmployeesByFirstName(string firstName);

        public List<Employee> GetEmployeesByLastName(string lastName);

        public List<Employee> GetAllEmployees();

        public void AddEmployee(Employee employee);
    }
}
