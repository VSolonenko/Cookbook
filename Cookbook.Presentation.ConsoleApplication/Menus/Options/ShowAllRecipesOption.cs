using Cookbook.Business;
using Cookbook.Business.Models;
using Cookbook.Presentation.ConsoleApplication.Drawers;

namespace Cookbook.Presentation.ConsoleApplication.Menus.Options
{
    internal sealed class ShowAllRecipesOption : Option
    {
        private readonly IModelDrawer<Recipe> recipeDrawer;
        private readonly IRecipeManager recipeManager;

        public ShowAllRecipesOption(IRecipeManager recipeManager, IModelDrawer<Recipe> recipeDrawer) :
            base(title: "Show all recipes")
        {
            this.recipeDrawer = recipeDrawer;
            this.recipeManager = recipeManager;
        }

        public override void Execute()
        {
            foreach (Recipe recipe in recipeManager.GetRecipes())
            {
                recipeDrawer.Draw(recipe);
            }
        }
    }
}