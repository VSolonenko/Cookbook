using Cookbook.Business.Models;
using System.Data.Odbc;

namespace Cookbook.Data.SqlServer.Odbc.DataProviders
{
    internal interface IUnitDataProvider
    {
        Unit FindUnitById(int unitId, OdbcConnection connection);
    }
}