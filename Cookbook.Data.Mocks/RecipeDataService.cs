using Cookbook.Data.Gateways;
using Cookbook.Data.Mocks.Gateways;

namespace Cookbook.Data.Mocks
{
    internal sealed class RecipeDataService : IRecipeDataService
    {
        public IRecipeDataGateway OpenDataGateway()
        {
            return new RecipeDataGateway();
        }
    }
}