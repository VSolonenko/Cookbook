using Cookbook.Data.Gateways;

namespace Cookbook.Data
{
    public interface IRecipeDataService
    {
        IRecipeDataGateway OpenDataGateway();
    }
}