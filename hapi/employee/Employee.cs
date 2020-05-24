using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace hapi.employee
{
    public class Address
    {
        public Address(string city, string state, string zip)
        {
            City = city;
            State = state;
            Zip = zip;
        }

        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"Zip: {Zip}\n";
        }

        private class NullAddress : Address
        {
            public NullAddress() : base(null, null, null)
            {
            }
        }
    }

    public class Employee
    {
        public static readonly Employee Null = new NullEmployee();

        public Employee(XDocument document)
        {
            Id = document.Root.Element("EmployeeID").Value;
            ManagerId = document.Root.Element("ManagerID").IsEmpty
                ? "0"
                : document.Root.Element("ManagerID").Value;
            FirstName = Regex.Replace(document.Root.Element("FirstName").Value, @"\s+", "");
            LastName = Regex.Replace(document.Root.Element("LastName").Value, @"\s+", "");
            ContactNo = Regex.Replace(document.Root.Element("ContactNo").Value, @"\s+", "");
            Email = Regex.Replace(document.Root.Element("Email").Value, @"\s+", "");
            Address = new Address(
                Regex.Replace(document.Root.Element("Address").Element("City").Value, @"\s+", ""),
                Regex.Replace(document.Root.Element("Address").Element("State").Value, @"\s+", ""),
                Regex.Replace(document.Root.Element("Address").Element("Zip").Value, @"\s+", "")
            );
        }

        public Employee(string managerId, string firstName, string lastName, string contactNo, string email,
            Address address)
        {
            Id = System.Guid.NewGuid().ToString();
            ManagerId = managerId;
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
            Email = email;
            Address = address;
        }

        public Employee(string id, string managerId, string firstName, string lastName, string contactNo, string email,
            Address address)
        {
            Id = id;
            ManagerId = managerId;
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
            Email = email;
            Address = address;
        }

        public string Id { get; set; }
        public string ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public XDocument ToXDocument()
        {
            return new XDocument(
                new XElement("Employee",
                    new XElement("EmployeeID", Id.ToString()),
                    new XElement("ManagerID", ManagerId.ToString()),
                    new XElement("FirstName", FirstName),
                    new XElement("LastName", LastName),
                    new XElement("ContactNo", ContactNo),
                    new XElement("Email", Email),
                    new XElement("Address",
                        new XElement("City", Address.City),
                        new XElement("State", Address.State),
                        new XElement("Zip", Address.Zip)
                    ))
            );
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"ManagerId: {ManagerId}\n" +
                   $"FirstName: {FirstName}\n" +
                   $"LastName: {LastName}\n" +
                   $"ContactNo: {ContactNo}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n";
        }

        private class NullEmployee : Employee
        {
            public NullEmployee() : base("0", "0", null, null, null, null, null)
            {
            }
        }
    }
}