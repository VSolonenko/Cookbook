using Cookbook.Presentation.ConsoleApplication.Menus;
using System;
using System.Text;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal sealed class Application : IApplication
    {
        private readonly IMenu menu;

        public Application(IMenu menu)
        {
            this.menu = menu;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                menu.Show();
            }
        }
    }
}