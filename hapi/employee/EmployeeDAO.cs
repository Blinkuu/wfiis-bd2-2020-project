using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using hapi.company;
using hapi.context;

namespace hapi.employee
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private readonly string _companyName;
        private readonly ConnectionContext _connectionContext;

        public EmployeeDAO(ConnectionContext connectionContext, string companyName)
        {
            _connectionContext = connectionContext;
            _companyName = companyName;
        }

        public Employee GetEmployeeById(int id)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./EmployeeID').value('.', 'int') = @id;", connection);
            
            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                    try
                    {
                        var document = XDocument.Parse(reader[0].ToString());

                        return new Employee(document);
                            
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            return Employee.Null;
        }

        public Employee GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            var result = new List<Employee>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName;", connection);

            command.Parameters.AddWithValue("@companyName", _companyName);

            try
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                    try
                    {
                        var document = XDocument.Parse(reader[0].ToString());
                        result.Add(new Employee(document));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            return result;
        }

        public void AddEmployee(Employee company)
        {
            throw new NotImplementedException();
        }
    }
}