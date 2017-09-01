using Cookbook.Business.Models;
using Cookbook.Data.SqlServer.Odbc.DataProviders.Tables;
using Cookbook.Data.SqlServer.Odbc.Exceptions;
using System.Collections.Generic;
using System.Data.Odbc;
using ComponentDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Component;
using RecipeComponentDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.RecipeComponent;

namespace Cookbook.Data.SqlServer.Odbc.DataProviders
{
    internal sealed class ComponentDataProvider : IComponentDataProvider
    {
        private readonly IIngredientDataProvider ingredientDataProvider;
        private readonly IUnitDataProvider unitDataProvider;

        public ComponentDataProvider(IIngredientDataProvider ingredientDataProvider, IUnitDataProvider unitDataProvider)
        {
            this.ingredientDataProvider = ingredientDataProvider;
            this.unitDataProvider = unitDataProvider;
        }

        public Component FindComponentById(int componentId, OdbcConnection connection)
        {
            ComponentDto componentDto;

            var commandText = $"SELECT {Components.Quantity}, {Components.IngredientId}, {Components.UnitId} FROM {Components.TableName} WHERE {Components.Id} = {componentId};";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    throw new ComponentIdNotFoundOdbcDataException(componentId);
                }

                componentDto = new ComponentDto
                {
                    Id = componentId,
                    IngredientId = reader.GetInt32(1),
                    Quantity = reader.GetDouble(0),
                    UnitId = reader.GetInt32(2)
                };
            }

            Ingredient ingredient = ingredientDataProvider.FindIngredientById(componentDto.IngredientId, connection);
            Unit unit = unitDataProvider.FindUnitById(componentDto.UnitId, connection);

            return new Component(
                id: componentDto.Id,
                ingredient: ingredient,
                quantity: componentDto.Quantity,
                unit: unit
            );
        }

        public IEnumerable<Component> FindComponentsByRecipeId(int recipeId, OdbcConnection connection)
        {
            var recipeComponentDtos = new List<RecipeComponentDto>();

            var commandText = $"SELECT {RecipesComponents.ComponentId} FROM {RecipesComponents.TableName} WHERE {RecipesComponents.RecipeId} = {recipeId};";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var recipeComponentDto = new RecipeComponentDto
                    {
                        ComponentId = reader.GetInt32(0),
                        RecipeId = recipeId
                    };

                    recipeComponentDtos.Add(recipeComponentDto);
                }
            }

            var components = new List<Component>();

            foreach (RecipeComponentDto recipeComponentDto in recipeComponentDtos)
            {
                Component component = FindComponentById(recipeComponentDto.ComponentId, connection);
                components.Add(component);
            }

            return components;
        }
    }
}