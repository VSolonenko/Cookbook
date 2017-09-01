using Cookbook.Business.Models;
using Cookbook.Data.SqlServer.Odbc.DataProviders.Tables;
using Cookbook.Data.SqlServer.Odbc.Exceptions;
using System.Collections.Generic;
using System.Data.Odbc;
using RecipeDto = Cookbook.Data.SqlServer.Odbc.TransferObjects.Recipe;

namespace Cookbook.Data.SqlServer.Odbc.DataProviders
{
    internal sealed class RecipeDataProvider : IRecipeDataProvider
    {
        private readonly IComponentDataProvider componentDataProvider;

        public RecipeDataProvider(IComponentDataProvider componentDataProvider)
        {
            this.componentDataProvider = componentDataProvider;
        }

        public IEnumerable<Recipe> FindAllRecipes(OdbcConnection connection)
        {
            var recipeDtos = new List<RecipeDto>();

            var commandText = $"SELECT {Recipes.Id} FROM {Recipes.TableName} ORDER BY {Recipes.Name};";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var recipeDto = new RecipeDto
                    {
                        Id = reader.GetInt32(0)
                    };

                    recipeDtos.Add(recipeDto);
                }
            }

            var recipes = new List<Recipe>();

            foreach (RecipeDto recipeDto in recipeDtos)
            {
                Recipe recipe = FindRecipeById(recipeDto.Id, connection);
                recipes.Add(recipe);
            }

            return recipes;
        }

        public Recipe FindRecipeById(int recipeId, OdbcConnection connection)
        {
            RecipeDto recipeDto;

            var commandText = $"SELECT {Recipes.Name} FROM {Recipes.TableName} WHERE {Recipes.Id} = {recipeId};";
            var command = new OdbcCommand(commandText, connection);

            using (OdbcDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    throw new RecipeIdNotFoundOdbcDataException(recipeId);
                }

                recipeDto = new RecipeDto
                {
                    Id = recipeId,
                    Name = reader.GetString(0)
                };
            }

            IEnumerable<Component> components = componentDataProvider.FindComponentsByRecipeId(recipeDto.Id, connection);

            return new Recipe(
                id: recipeDto.Id,
                name: recipeDto.Name,
                components: components
            );
        }

        public Recipe FindRecipeByName(string recipeName, OdbcConnection connection)
        {
            var commandText = $"SELECT {Recipes.Id} FROM {Recipes.TableName} WHERE {Recipes.Name} = '{recipeName}';";
            var command = new OdbcCommand(commandText, connection);

            var recipeId = (int)(command.ExecuteScalar() ?? throw new RecipeNameNotFoundOdbcDataException(recipeName));

            return FindRecipeById(recipeId, connection);
        }
    }
}