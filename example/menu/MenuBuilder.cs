using example.menu.options;

namespace example.menu
{
    internal interface IMenuBuilder
    {
        public void BuildAddEmployeeMenuOption();

        public void BuildRemoveEmployeeMenuOption();

        public Menu GetResult();
    }

    internal class ConcreteMenuBuilder : IMenuBuilder
    {
        private readonly Menu _menu = new Menu();

        public void BuildAddEmployeeMenuOption()
        {
            _menu.Add(new AddEmployeeMenuOption());
        }

        public void BuildRemoveEmployeeMenuOption()
        {
            _menu.Add(new RemoveEmployeeMenuOption());
        }


        public Menu GetResult()
        {
            return _menu;
        }

        public void BuildShowCompanyMenuOption()
        {
            _menu.Add(new ShowCompanyMenuOption());
        }

        public void BuildAddCompanyMenuOption()
        {
            _menu.Add(new AddCompanyMenuOption());
        }
    }
}