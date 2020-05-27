using System;
using System.Collections.Generic;
using System.Text;
using hapi.context;
using hapi.employee;

namespace example.menu.options
{
    class GetManagerByEmployeeIdMenuOption : MenuOption
    {
        public GetManagerByEmployeeIdMenuOption() : base("5", "Znajdź menadżera po id pracownika")
        {
        }

        private void OptionHandler()
        {
            GetManagerByEmployeeId(GetInput("Nazwa firmy: "), GetInput("id: "));
        }

        private void GetManagerByEmployeeId(string companyName, string id)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var employeeDao = new EmployeeDAO(connectionContext, companyName);
            Console.WriteLine(employeeDao.GetManagerByEmployeeId(id));
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}
