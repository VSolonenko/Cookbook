using Cookbook.Business.Exceptions;
using Cookbook.Business.Models;
using Cookbook.Data;
using Cookbook.Data.Exceptions;
using Cookbook.Data.Gateways;
using System;
using System.Collections.Generic;

namespace Cookbook.Business
{
    internal sealed class RecipeManager : IRecipeManager
    {
        private readonly IRecipeDataService dataService;

        public RecipeManager(IRecipeDataService dataService)
        {
            this.dataService = dataService;
        }

        public Recipe FindRecipe(string name)
        {
            try
            {
                using (IRecipeDataGateway dataGateway = dataService.OpenDataGateway())
                {
                    return dataGateway.FindRecipe(name);
                }
            }
            catch (RecipeNotFoundDataException exception)
            {
                throw new RecipeNotFoundBusinessException(name, exception);
            }
            catch (Exception exception)
            {
                throw new DataSourceBusinessException(exception);
            }
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            try
            {
                using (IRecipeDataGateway dataGateway = dataService.OpenDataGateway())
                {
                    return dataGateway.GetRecipes();
                }
            }
            catch (Exception exception)
            {
                throw new DataSourceBusinessException(exception);
            }
        }
    }
}