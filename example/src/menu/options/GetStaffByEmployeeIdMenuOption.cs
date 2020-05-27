using System;
using System.Collections.Generic;
using System.Text;
using hapi.context;
using hapi.employee;

namespace example.menu.options
{
    class GetStaffByEmployeeIdMenuOption : MenuOption
    {
        public GetStaffByEmployeeIdMenuOption() : base("6", "Znajdź osoby pod menadżerem po id menadżera")
        {
        }

        private void OptionHandler()
        {
            GetStaffByEmployeeId(GetInput("Nazwa firmy: "), GetInput("id: "));
        }

        private void GetStaffByEmployeeId(string companyName, string id)
        {
            var connectionContext = new ConnectionContext(ConnectionString);

            var employeeDao = new EmployeeDAO(connectionContext, companyName);
            foreach(var employee in employeeDao.GetStaffByEmployeeId(id))
                Console.WriteLine(employee);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}
