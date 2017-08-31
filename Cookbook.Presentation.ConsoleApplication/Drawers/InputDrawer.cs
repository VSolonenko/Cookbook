using System;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal sealed class InputDrawer : IInputDrawer
    {
        public void Draw(string inputName)
        {
            Console.Write($"Enter {inputName}: ");
        }
    }
}