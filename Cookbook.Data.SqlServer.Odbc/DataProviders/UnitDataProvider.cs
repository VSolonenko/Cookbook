using Cookbook.Business.Models;
using Cookbook.Data.SqlServer.Odbc.Exceptions;
using System.Data.Odbc;
using UnitDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Unit;

namespace Cookbook.Data.SqlServer.Odbc.DataProviders
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
                if (!reader.Read())
                {
                    throw new UnitIdNotFoundOdbcDataException(unitId);
                }

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