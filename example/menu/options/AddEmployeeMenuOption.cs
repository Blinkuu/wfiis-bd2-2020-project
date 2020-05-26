using System;
using hapi.context;
using hapi.employee;

namespace example.menu.options
{
    public class AddEmployeeMenuOption : MenuOption
    {
        public AddEmployeeMenuOption() : base("2", "Dodaj pracownika do firmy")
        {
        }

        private void OptionHandler()
        {
            AddEmployee(GetInput("Nazwa firmy:"), new Employee(
                GetInput("id: "),
                GetInput("Manager id: "),
                GetInput("Imie: "),
                GetInput("Nazwisko: "),
                GetInput("Nr tel.: "),
                new Address(
                    GetInput("Miasto: "),
                    GetInput("Stan: "),
                    GetInput("Kod pocztowy: ")
                )
            ));
        }

        private void AddEmployee(string companyName, Employee employee)
        {
            var connectionContext = new ConnectionContext(ConnectionString);
            var employeeDao = new EmployeeDAO(connectionContext, companyName);
            employeeDao.AddEmployee(employee);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}