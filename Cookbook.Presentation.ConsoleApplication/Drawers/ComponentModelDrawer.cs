using Cookbook.Business.Models;
using System;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal sealed class ComponentModelDrawer : IModelDrawer<Component>
    {
        public void Draw(Component model)
        {
            Console.Write("Component: ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(model.Ingredient.Name);
            Console.ResetColor();

            Console.Write($" - {model.Quantity} ");
            Console.WriteLine(model.Quantity <= 1.0 ? model.Unit.SingularName : model.Unit.PluralName);
        }
    }
}