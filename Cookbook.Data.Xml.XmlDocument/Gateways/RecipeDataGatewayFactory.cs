using Cookbook.Data.Gateways;
using Cookbook.Data.Xml.XmlDocument.Gateways.Providers;

namespace Cookbook.Data.Xml.XmlDocument.Gateways
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