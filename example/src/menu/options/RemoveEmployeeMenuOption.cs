using hapi.context;
using hapi.employee;

namespace example.menu.options
{
    internal class RemoveEmployeeMenuOption : MenuOption
    {
        public RemoveEmployeeMenuOption() : base("4", "Usuń pracownika z firmy")
        {
        }

        private void OptionHandler()
        {
            RemoveEmployee(
                GetInput("Nazwa firmy: "),
                GetInput("id: ")
            );
        }

        private void RemoveEmployee(string companyName, string id)
        {
            var connectionContext = new ConnectionContext(ConnectionString);
            var employeeDao = new EmployeeDAO(connectionContext, companyName);

            employeeDao.RemoveEmployeeById(id);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}