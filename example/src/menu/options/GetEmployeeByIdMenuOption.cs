using System;
using hapi.context;
using hapi.employee;

namespace example.menu.options
{
    internal class GetEmployeeByIdMenuOption : MenuOption
    {
        public GetEmployeeByIdMenuOption() : base("3", "Znajdź pracownika po id")
        {
        }

        private void OptionHandler()
        {
            GetEmployeeById(GetInput("Nazwa firmy: "), GetInput("id: "));
        }

        private void GetEmployeeById(string companyName, string id)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var employeeDao = new EmployeeDAO(connectionContext, companyName);
            Console.WriteLine(employeeDao.GetEmployeeById(id));
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}