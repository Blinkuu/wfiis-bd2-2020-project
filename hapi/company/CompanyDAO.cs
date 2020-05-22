using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml.Linq;
using hapi.context;

namespace hapi.company
{
    public class CompanyDAO : ICompanyDAO
    {
        private readonly ConnectionContext _connectionContext;

        public CompanyDAO(ConnectionContext connectionContext)
        {
            this._connectionContext = connectionContext;
        }

        public Company GetCompany(int id)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT * FROM [Company] WHERE id=@id;", connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                    try
                    {
                        var document = XDocument.Parse(reader[2].ToString());
                        return new Company(reader.GetInt32(0), reader.GetString(1), document);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return Company.Null;
        }

        public Company GetCompany(string name)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT * FROM [Company] WHERE companyName=@companyName;", connection);
            command.Parameters.AddWithValue("@companyName", name);

            try
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                    try
                    {
                        var document = XDocument.Parse(reader[2].ToString());
                        return new Company(reader.GetInt32(0), reader.GetString(1), document);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return Company.Null;
        }

        public List<Company> GetAllCompanies()
        {
            var result = new List<Company>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT * FROM [Company];", connection);

            try
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                    try
                    {
                        var document = XDocument.Parse(reader[2].ToString());
                        result.Add(new Company(reader.GetInt32(0), reader.GetString(1), document));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return result;
        }

        public void AddCompany(Company company)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"INSERT INTO [Company] ([companyName] ,[companyData])
                      VALUES (@name, @companyData)"
                , connection);

            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = company.Name;
            command.Parameters.Add("@companyData", SqlDbType.Xml).Value = new SqlXml(company.Data.CreateReader());

            var transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                Console.WriteLine(e.ToString());
                
                throw;
            }
        }
    }
}
