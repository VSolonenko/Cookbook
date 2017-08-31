using Cookbook.Business.Models;
using System.Data.Odbc;
using UnitDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Unit;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
{
    internal sealed class UnitDataProvider : IUnitDataProvider
    {
        public Unit FindUnitById(int unitId, OdbcConnection connection)
        {
            UnitDto unitDto;

            var commandText = $"SELECT [PluralName], [SingularName] FROM [Units] WHERE [Id] = '{unitId}';";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                reader.Read();

                unitDto = new UnitDto
                {
                    Id = unitId,
                    PluralName = reader.GetString(0),
                    SingularName = reader.GetString(1)
                };
            }

            return new Unit(
                id: unitDto.Id,
                singularName: unitDto.SingularName,
                pluralName: unitDto.PluralName
            );
        }
    }
}