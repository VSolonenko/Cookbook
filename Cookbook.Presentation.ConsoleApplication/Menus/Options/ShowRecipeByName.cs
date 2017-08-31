using Cookbook.Business;
using Cookbook.Business.Exceptions;
using Cookbook.Business.Models;
using Cookbook.Presentation.ConsoleApplication.Drawers;
using Cookbook.Presentation.ConsoleApplication.Exceptions;
using Cookbook.Presentation.ConsoleApplication.Input;

namespace Cookbook.Presentation.ConsoleApplication.Menus.Options
{
    internal sealed class ShowRecipeByName : Option
    {
        private readonly IInputProvider inputProvider;
        private readonly IModelDrawer<Recipe> recipeDrawer;
        private readonly IRecipeManager recipeManager;

        public ShowRecipeByName(IRecipeManager recipeManager, IInputProvider inputProvider, IModelDrawer<Recipe> recipeDrawer) :
            base(title: "Show recipe by name")
        {
            this.inputProvider = inputProvider;
            this.recipeDrawer = recipeDrawer;
            this.recipeManager = recipeManager;
        }

        public override void Execute()
        {
            try
            {
                string recipeName = inputProvider.ReadInput("recipe name");

                Recipe recipe = recipeManager.FindRecipe(recipeName);

                recipeDrawer.Draw(recipe);
            }
            catch (RecipeNotFoundBusinessException exception)
            {
                throw new PresentationException($"Cannot find recipe '{exception.RecipeName}'.", exception);
            }
        }
    }
}