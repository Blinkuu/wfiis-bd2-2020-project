using System.Xml.Linq;

namespace hapi.company
{
    public class Company
    {
        public static readonly Company Null = new NullCompany();

        public Company(int id, string name, XDocument data)
        {
            this.Id = id;
            this.Name = name;
            this.Data = data;
        }

        public Company(string name, XDocument data)
        {
            this.Name = name;
            this.Data = data;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public XDocument Data { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                   $"name: {Name}\n" +
                   $"data:\n{Data}";
        }

        private class NullCompany : Company
        {
            public NullCompany() : base(null, null)
            {
            }
        }
    }
}