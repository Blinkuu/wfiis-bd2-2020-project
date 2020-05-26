using System;
using hapi.company;
using hapi.context;

namespace example.menu.options
{
    public class ShowCompanyMenuOption : MenuOption
    {
        public ShowCompanyMenuOption() : base("0", "Wyświetl dane o firmie")
        {
        }

        private void OptionHandler()
        {
            ShowCompany(
                GetInput("Nazwa firmy: ")
            );
        }

        private void ShowCompany(string companyName)
        {
            var connectionContext = new ConnectionContext(ConnectionString);
            var companyDao = new CompanyDAO(connectionContext);

            Console.WriteLine(companyDao.GetCompanyByName(companyName));
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}