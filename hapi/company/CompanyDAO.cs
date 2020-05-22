using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace hapi.company
{
    class CompanyDAO : ICompanyDAO
    {
        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(string name)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT companyData FROM [Company] WHERE companyName=@companyName;", connection);
                command.Parameters.AddWithValue("@companyName", name);

                try
                {
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        XDocument document = XDocument.Load(reader);
                        if (document != null)
                        {
                            Console.WriteLine("XML document read correctly!");

                            var stringWriter = new StringWriter();
                            document.Save(stringWriter);
                            Console.WriteLine(stringWriter.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("XML document could not be read!");
                }
            }

            return new Company(0, "");
        }

        public List<Company> GetAllCompanies()
        {
            

            return new List<Company>();
        }
    }
}
