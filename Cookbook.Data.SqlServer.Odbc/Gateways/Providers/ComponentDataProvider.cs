using Cookbook.Business.Models;
using System.Collections.Generic;
using System.Data.Odbc;
using ComponentDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Component;
using RecipeComponentDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.RecipeComponent;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
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

            var commandText = $"SELECT [Quantity], [IngredientId], [UnitId] FROM [Components] WHERE [Id] = {componentId};";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                reader.Read();

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

            var commandText = $"SELECT [ComponentId] FROM [RecipesComponents] WHERE [RecipeId] = {recipeId};";
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