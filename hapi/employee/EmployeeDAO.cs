using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
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

        public Employee GetEmployeeById(string id)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar(max)') = @id;",
                connection);

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

        public List<Employee> GetEmployeesByFullName(string firstName, string lastName)
        {
            var result = new List<Employee>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName
                  AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = @firstName
                  AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = @lastName;",
                connection);

            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);


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

        public List<Employee> GetEmployeesByFirstName(string firstName)
        {
            var result = new List<Employee>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = @firstName;",
                connection);

            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@firstName", firstName);


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

        public List<Employee> GetEmployeesByLastName(string lastName)
        {
            var result = new List<Employee>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = @lastName;",
                connection);

            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@lastName", lastName);


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

        public Employee GetManagerByEmployeeId(string id)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"DECLARE @managerID int;
                  SELECT @managerID = helperTable.Employee.value('./ManagerID', 'varchar(max)')  
                  FROM [dbo].[Company]  
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar(max)') = @id
                  
                  SELECT helperTable.Employee.query('.')  
                  FROM [dbo].[Company]  
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar(max)') = CAST(@managerID AS varchar(max));",
                connection);

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

        public List<Employee> GetStaffByEmployeeId(string id)
        {
            var result = new List<Employee>();

            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = @companyName 
                  AND helperTable.Employee.value('ManagerID', 'varchar(max)') = @id;", connection);

            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@id", id);

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

        public void AddEmployee(Employee employee)
        {
            using var connection = new SqlConnection(_connectionContext.connectionString);
            connection.Open();

            var command = new SqlCommand(
                @"DECLARE @currentData xml;
                  SELECT @currentData = companyData FROM [Company] WHERE companyName = @companyName;
                  SELECT @currentData;

                  DECLARE @newData xml;
                  SET @newData = @xmlData;

                  DECLARE @final XML;
                  SET @final = CAST('<tmp>' + CAST(@newData AS VARCHAR(MAX)) + '</tmp>' + CAST(@currentData AS VARCHAR(MAX)) AS XML);
                  SET @final.modify('insert /tmp/* into (/Company)[1]');
                  SET @final.modify('delete /tmp');

                  SELECT @final;

                  UPDATE [Company] SET [companyData] = @final WHERE companyName = @companyName;"
                , connection);

            command.Parameters.AddWithValue("@companyName", _companyName);
            command.Parameters.AddWithValue("@xmlData", employee.ToXDocument().ToString());

            Console.WriteLine(employee.ToXDocument().ToString());

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