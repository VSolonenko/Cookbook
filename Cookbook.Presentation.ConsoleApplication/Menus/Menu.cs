using Cookbook.Presentation.ConsoleApplication.Drawers;
using Cookbook.Presentation.ConsoleApplication.Exceptions;
using Cookbook.Presentation.ConsoleApplication.Menus.Options;
using System;
using System.Collections.Generic;

namespace Cookbook.Presentation.ConsoleApplication.Menus
{
    internal sealed class Menu : IMenu
    {
        private readonly Lazy<IDictionary<ConsoleKey, Action>> commands;
        private readonly IErrorDrawer errorDrawer;
        private readonly IOptionDrawer optionDrawer;
        private readonly IList<IOption> options;

        private int selectedIndex = 0;

        public Menu(IList<IOption> options, IOptionDrawer optionDrawer, IErrorDrawer errorDrawer)
        {
            this.errorDrawer = errorDrawer;
            this.optionDrawer = optionDrawer;
            this.options = options;

            commands = new Lazy<IDictionary<ConsoleKey, Action>>(CreateCommands);
        }

        private IDictionary<ConsoleKey, Action> CreateCommands()
        {
            return new Dictionary<ConsoleKey, Action>
            {
                [ConsoleKey.DownArrow] = SelectNextOption,
                [ConsoleKey.Enter] = ExecuteSelectedOption,
                [ConsoleKey.UpArrow] = SelectPreviousOption
            };
        }

        private void ExecuteSelectedOption()
        {
            Console.Clear();

            try
            {
                options[selectedIndex].Execute();
            }
            catch (PresentationException exception)
            {
                errorDrawer.Draw(exception.Message);
            }

            Console.ReadKey(intercept: true);
        }

        private void SelectNextOption()
        {
            if (selectedIndex < options.Count - 1)
            {
                ++selectedIndex;
            }
        }

        private void SelectPreviousOption()
        {
            if (selectedIndex > 0)
            {
                --selectedIndex;
            }
        }

        public void Show()
        {
            Console.Clear();

            for (var index = 0; index < options.Count; ++index)
            {
                optionDrawer.Draw(
                    options[index],
                    isSelected: selectedIndex == index
                );
            }

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (commands.Value.TryGetValue(key.Key, out Action command))
            {
                command();
            }
        }
    }
}