using System.IO;
using System.Xml.Linq;

namespace hapi.company
{
    public class Company
    {
        public int id { get; set; }

        public string name { get; set; }

        public XDocument data { get; set; }

        public static readonly Company Null = new NullCompany();

        private class NullCompany : Company
        {
            public NullCompany() : base(-1, null, null) { }
        }

        public Company(int id, string name, XDocument data)
        {
            this.id = id;
            this.name = name;
            this.data = data;
        }

        public override string ToString()
        {
            return $"id: {id}\n" +
                   $"name: {name}\n" +
                   $"data:\n{data}";
        }
    }
}
