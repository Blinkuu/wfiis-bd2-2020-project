using System.Xml.Linq;
using hapi.company;
using hapi.context;

namespace example.menu.options
{
    public class AddCompanyMenuOption : MenuOption
    {
        public AddCompanyMenuOption() : base("1", "Dodaj firmę")
        {
        }

        private void OptionHandler()
        {
            AddCompany(new Company(
                GetInput("Nazwa firmy: "),
                XDocument.Parse(
                    @"<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""/>")
            ));
        }

        private void AddCompany(Company company)
        {
            var connectionContext = new ConnectionContext(ConnectionString);
            var companyDao = new CompanyDAO(connectionContext);
            companyDao.AddCompany(company);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}