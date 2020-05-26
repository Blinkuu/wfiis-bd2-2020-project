using example.menu;

namespace example.application
{
    internal class Application
    {
        private readonly bool _isRunning = true;

        public void Run()
        {
            var menuBuilder = new ConcreteMenuBuilder();
            menuBuilder.BuildShowCompanyMenuOption();
            menuBuilder.BuildAddCompanyMenuOption();
            menuBuilder.BuildAddEmployeeMenuOption();
            menuBuilder.BuildRemoveEmployeeMenuOption();

            var menu = menuBuilder.GetResult();

            while (_isRunning)
            {
                menu.Show();
                menu.GetInput();
            }
        }
    }
}