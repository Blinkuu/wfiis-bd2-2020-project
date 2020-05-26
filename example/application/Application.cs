using example.menu;

namespace example.application
{
    internal class Application
    {
        public void Run()
        {
            var menuBuilder = new ConcreteMenuBuilder();
            var director = new MenuDirector();
            director.ConstructMenu(menuBuilder);

            var menu = menuBuilder.GetResult();

            while (true)
            {
                menu.Show();
                menu.GetInput();
            }
        }
    }
}