using System;

namespace example.menu
{
    public abstract class MenuOption
    {
        protected const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        private readonly string _description;

        public readonly string _key;

        protected MenuOption(string key, string description)
        {
            _key = key;
            _description = description;
        }

        public void Show()
        {
            Console.WriteLine($"{_key}. {_description}");
        }

        public void TryRun(string key)
        {
            if (string.Equals(key, _key))
                Run();
        }

        public abstract void Run();

        protected string GetInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}