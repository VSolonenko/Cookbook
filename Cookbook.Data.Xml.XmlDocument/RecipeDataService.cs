using Cookbook.Data.Gateways;
using Cookbook.Data.Xml.XmlDocument.Gateways;

namespace Cookbook.Data.Xml.XmlDocument
{
    internal sealed class RecipeDataService : IRecipeDataService
    {
        private readonly IRecipeDataGatewayFactory dataGatewayFactory;

        public RecipeDataService(IRecipeDataGatewayFactory dataGatewayFactory)
        {
            this.dataGatewayFactory = dataGatewayFactory;
        }

        public IRecipeDataGateway OpenDataGateway()
        {
            return dataGatewayFactory.CreateDataGateway();
        }
    }
}