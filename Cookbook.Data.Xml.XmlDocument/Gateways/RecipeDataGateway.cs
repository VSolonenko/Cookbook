using Cookbook.Business.Models;
using Cookbook.Data.Exceptions;
using Cookbook.Data.Gateways;
using Cookbook.Data.Xml.XmlDocument.DataProviders;
using System;
using System.Collections.Generic;

namespace Cookbook.Data.Xml.XmlDocument.Gateways
{
    using System.Xml;

    internal sealed class RecipeDataGateway : IRecipeDataGateway
    {
        private readonly Lazy<XmlDocument> document;
        private readonly IRecipeDataProvider recipeDataProvider;

        public RecipeDataGateway(IRecipeDataProvider recipeDataProvider)
        {
            this.recipeDataProvider = recipeDataProvider;

            document = new Lazy<XmlDocument>(CreateDocument);
        }

        private XmlDocument CreateDocument()
        {
            try
            {
                var document = new XmlDocument();
                document.Load(@"..\..\..\DataSources\XmlDatabase.xml");

                return document;
            }
            catch (Exception exception)
            {
                throw new GatewayNotOpenedDataException(exception);
            }
        }

        public void Dispose()
        {
            // Do nothing.
        }

        public Recipe FindRecipe(string name)
        {
            try
            {
                return recipeDataProvider.FindRecipeByName(name, document.Value);
            }
            catch (Exception exception)
            {
                throw new RecipeNotFoundDataException(name, exception);
            }
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            try
            {
                return recipeDataProvider.FindAllRecipes(document.Value);
            }
            catch (Exception exception)
            {
                throw new DataException(exception);
            }
        }
    }
}