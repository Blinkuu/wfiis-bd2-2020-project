using hapi.company;

namespace hapi
{
    public class Program
    {
        static void Main(string[] args)
        {
            var companyDAO = new CompanyDAO();

            var company = companyDAO.GetCompany("Test Company");
        }

        public string GetHelloWorld()
        {
            return "Hello, World!";
        }
    }
}
