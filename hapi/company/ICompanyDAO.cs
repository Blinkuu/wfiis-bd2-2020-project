using System;
using System.Collections.Generic;
using System.Text;

namespace hapi.company
{
    public interface ICompanyDAO
    {
        public Company GetCompanyById(int id);

        public Company GetCompanyByName(string name);

        public List<Company> GetAllCompanies();

        public void AddCompany(Company company);
    }
}
