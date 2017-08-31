using Cookbook.Data.Gateways;

namespace Cookbook.Data.SqlServer.Odbc.Gateways
{
    internal interface IRecipeDataGatewayFactory
    {
        IRecipeDataGateway CreateDataGateway();
    }
}