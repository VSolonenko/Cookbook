using Cookbook.Data.Gateways;
using Cookbook.Data.SqlServer.Odbc.DataProviders;

namespace Cookbook.Data.SqlServer.Odbc.Gateways
{
    internal sealed class RecipeDataGatewayFactory : IRecipeDataGatewayFactory
    {
        private readonly IRecipeDataProvider recipeDataProvider;

        public RecipeDataGatewayFactory(IRecipeDataProvider recipeDataProvider)
        {
            this.recipeDataProvider = recipeDataProvider;
        }

        public IRecipeDataGateway CreateDataGateway()
        {
            return new RecipeDataGateway(recipeDataProvider);
        }
    }
}