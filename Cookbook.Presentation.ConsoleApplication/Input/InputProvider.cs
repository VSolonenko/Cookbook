using Cookbook.Presentation.ConsoleApplication.Drawers;
using System;

namespace Cookbook.Presentation.ConsoleApplication.Input
{
    internal sealed class InputProvider : IInputProvider
    {
        private readonly IInputDrawer inputDrawer;

        public InputProvider(IInputDrawer inputDrawer)
        {
            this.inputDrawer = inputDrawer;
        }

        public string ReadInput(string inputName)
        {
            inputDrawer.Draw(inputName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = true;

            string input = Console.ReadLine();

            Console.CursorVisible = false;
            Console.ResetColor();

            return input;
        }
    }
}