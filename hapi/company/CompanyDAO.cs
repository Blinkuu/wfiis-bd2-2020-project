using hapi.context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace hapi.company
{
    public class CompanyDAO : ICompanyDAO
    {
        private ConnectionContext connectionContext;
        public CompanyDAO(ConnectionContext connectionContext)
        {
            this.connectionContext = connectionContext;
        }

        public Company GetCompany(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionContext.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [Company] WHERE id=@id;", connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                XDocument document = XDocument.Parse(reader[2].ToString());
                                return new Company(reader.GetInt32(0), reader.GetString(1), document);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Could not load XML document");
                                Console.WriteLine(e.ToString());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not execute reader!");
                    Console.WriteLine(e.ToString());
                }
            }

            return Company.Null;
        }

        public Company GetCompany(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionContext.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [Company] WHERE companyName=@companyName;", connection);
                command.Parameters.AddWithValue("@companyName", name);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                XDocument document = XDocument.Parse(reader[2].ToString());
                                return new Company(reader.GetInt32(0), reader.GetString(1), document);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Could not load XML document");
                                Console.WriteLine(e.ToString());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not execute reader!");
                    Console.WriteLine(e.ToString());
                }
            }

            return Company.Null;
        }

        public List<Company> GetAllCompanies()
        {


            return new List<Company>();
        }
    }
}
