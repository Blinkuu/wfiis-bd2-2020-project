using System;

namespace example.menu.options
{
    internal class ExitMenuOption : MenuOption
    {
        public ExitMenuOption() : base("5", "Wyjdź")
        {
        }

        private void OptionHandler()
        {
            Environment.Exit(0);
        }

        public override void Run()
        {
            OptionHandler();
        }
    }
}