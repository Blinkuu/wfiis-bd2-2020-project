using System;
using System.Collections.Generic;
using System.Text;

namespace hapi.employee
{
    interface IEmployeeDAO
    {
        public Employee GetEmployeeById(int id);

        public Employee GetEmployeeByName(string name);

        public List<Employee> GetAllEmployees();

        public void AddEmployee(Employee company);
    }
}
