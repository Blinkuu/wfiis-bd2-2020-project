using hapi.company;
using hapi.context;

namespace example.menu.options
{
    public class RemoveEmployeeMenuOption : MenuOption
    {
        public RemoveEmployeeMenuOption() : base("3", "Usuń pracownika z firmy")
        {
        }

        private void OptionHandler()
        {
            RemoveCompany(
                GetInput("Nazwa firmy: ")
            );
        }

        private void RemoveCompany(string companyName)
        {
            var connectionContext = new ConnectionContext(ConnectionString);
            var companyDao = new CompanyDAO(connectionContext);

            companyDao.RemoveCompanyByName(companyName);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}