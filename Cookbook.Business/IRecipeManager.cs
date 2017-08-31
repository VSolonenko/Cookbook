using Cookbook.Business.Models;
using System.Collections.Generic;

namespace Cookbook.Business
{
    public interface IRecipeManager
    {
        Recipe FindRecipe(string name);
        IEnumerable<Recipe> GetRecipes();
    }
}