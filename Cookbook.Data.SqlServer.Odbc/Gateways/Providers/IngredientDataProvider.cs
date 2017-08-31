using Cookbook.Business.Models;
using System.Data.Odbc;
using IngredientDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Ingredient;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
{
    internal sealed class IngredientDataProvider : IIngredientDataProvider
    {
        public Ingredient FindIngredientById(int ingredientId, OdbcConnection connection)
        {
            IngredientDto ingredientDto;

            var commandText = $"SELECT [Name] FROM [Ingredients] WHERE [Id] = '{ingredientId}';";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                reader.Read();

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