using System;
using System.Collections.Generic;

namespace example.menu
{
    public class Menu
    {
        private readonly List<MenuOption> _menuOptions = new List<MenuOption>();

        public void Add(MenuOption menuOption)
        {
            _menuOptions.Add(menuOption);
        }

        public void Show()
        {
            foreach (var option in _menuOptions) option.Show();
        }

        public void GetInput()
        {
            string userInput = Console.ReadLine();

            foreach (var option in _menuOptions)
            {
                option.TryRun(userInput);
            }
        }
    }
}