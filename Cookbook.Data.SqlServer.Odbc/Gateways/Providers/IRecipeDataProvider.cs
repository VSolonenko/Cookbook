using Cookbook.Business.Models;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
{
    internal interface IRecipeDataProvider
    {
        IEnumerable<Recipe> FindAllRecipes(OdbcConnection connection);
        Recipe FindRecipeById(int recipeId, OdbcConnection connection);
        Recipe FindRecipeByName(string recipeName, OdbcConnection connection);
    }
}