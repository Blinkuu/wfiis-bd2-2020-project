using System;
using System.Collections.Generic;
using System.Text;

namespace hapi.company
{
    interface ICompanyDAO
    {
        public Company GetCompany(int id);

        public Company GetCompany(string name);

        public List<Company> GetAllCompanies();
    }
}
