namespace hapi.company
{
    class Company
    {
        private int id { get; set; }
        private string name { get; set; }

        public Company(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
