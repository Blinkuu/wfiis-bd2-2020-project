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

        public Employee(int id, int managerId, string firstName, string lastName, string contactNo, Address address)
        {
            Id = id;
            ManagerId = managerId;
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
            Address = address;
        }

        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"ManagerId: {ManagerId}\n" +
                   $"ManagerId: {ManagerId}\n" +
                   $"FirstName: {FirstName}\n" +
                   $"LastName: {LastName}\n" +
                   $"ContactNo: {ContactNo}\n" +
                   $"Address: {Address}\n";
        }

        private class NullEmployee : Employee
        {
            public NullEmployee() : base(0, 0, null, null, null, null)
            {
            }
        }
    }
}