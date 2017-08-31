using Cookbook.Data.Gateways;

namespace Cookbook.Data.Xml.XmlDocument.Gateways
{
    internal interface IRecipeDataGatewayFactory
    {
        IRecipeDataGateway CreateDataGateway();
    }
}