using System.Xml.Linq;

namespace hapi.company
{
    public class Company
    {
        public static readonly Company Null = new NullCompany();

        public Company(int id, string name, XDocument data)
        {
            Id = id;
            Name = name;
            Data = data;
        }

        public Company(string name, XDocument data)
        {
            Name = name;
            Data = data;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public XDocument Data { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Data:\n{Data}\n";
        }

        private class NullCompany : Company
        {
            public NullCompany() : base(null, null)
            {
            }
        }
    }
}