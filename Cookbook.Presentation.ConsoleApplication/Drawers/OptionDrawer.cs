using Cookbook.Presentation.ConsoleApplication.Menus.Options;
using System;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal sealed class OptionDrawer : IOptionDrawer
    {
        public void Draw(IOption option, bool isSelected)
        {
            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(option.Title);
            Console.ResetColor();
        }
    }
}