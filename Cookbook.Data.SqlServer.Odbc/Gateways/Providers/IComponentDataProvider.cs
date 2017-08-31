using Cookbook.Business.Models;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
{
    internal interface IComponentDataProvider
    {
        Component FindComponentById(int componentId, OdbcConnection connection);
        IEnumerable<Component> FindComponentsByRecipeId(int recipeId, OdbcConnection connection);
    }
}