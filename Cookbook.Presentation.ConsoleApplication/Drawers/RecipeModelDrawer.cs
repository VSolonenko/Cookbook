using Cookbook.Business.Models;
using System;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal sealed class RecipeModelDrawer : IModelDrawer<Recipe>
    {
        private readonly IModelDrawer<Component> componentDrawer;

        public RecipeModelDrawer(IModelDrawer<Component> componentDrawer)
        {
            this.componentDrawer = componentDrawer;
        }

        public void Draw(Recipe model)
        {
            Console.Write("Recipe: ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(model.Name);
            Console.ResetColor();

            foreach (Component component in model.Components)
            {
                Console.Write('\t');
                componentDrawer.Draw(component);
            }
        }
    }
}