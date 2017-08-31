using System;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal sealed class ErrorDrawer : IErrorDrawer
    {
        public void Draw(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(error);

            Console.ResetColor();
        }
    }
}