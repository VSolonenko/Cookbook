using Cookbook.Business.Models;
using Cookbook.Data.SqlServer.Odbc.DataProviders.Tables;
using Cookbook.Data.SqlServer.Odbc.Exceptions;
using System.Data.Odbc;
using IngredientDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Ingredient;

namespace Cookbook.Data.SqlServer.Odbc.DataProviders
{
    internal sealed class IngredientDataProvider : IIngredientDataProvider
    {
        public Ingredient FindIngredientById(int ingredientId, OdbcConnection connection)
        {
            IngredientDto ingredientDto;

            var commandText = $"SELECT {Ingredients.Name} FROM {Ingredients.TableName} WHERE {Ingredients.Id} = '{ingredientId}';";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    throw new IngredientIdNotFoundOdbcDataException(ingredientId);
                }

                ingredientDto = new IngredientDto
                {
                    Id = ingredientId,
                    Name = reader.GetString(0)
                };
            }

            return new Ingredient(
                id: ingredientDto.Id,
                name: ingredientDto.Name
            );
        }
    }
}