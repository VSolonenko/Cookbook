using Cookbook.Business.Models;
using Cookbook.Data.Exceptions;
using Cookbook.Data.Gateways;
using Cookbook.Data.SqlServer.Odbc.DataProviders;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Cookbook.Data.SqlServer.Odbc.Gateways
{
    internal sealed class RecipeDataGateway : DisposableObject, IRecipeDataGateway
    {
        private readonly Lazy<OdbcConnection> connection;
        private readonly IRecipeDataProvider recipeDataProvider;

        public RecipeDataGateway(IRecipeDataProvider recipeDataProvider)
        {
            this.recipeDataProvider = recipeDataProvider;

            connection = new Lazy<OdbcConnection>(CreateConnection);
        }

        private OdbcConnection CreateConnection()
        {
            var connectionStringBuilder = new OdbcConnectionStringBuilder
            {
                Driver = "SQL Server"
            };
            connectionStringBuilder.Add("Database", "Cookbook");
            connectionStringBuilder.Add("Server", "(local)");
            connectionStringBuilder.Add("Trusted_Connection", "Yes");

            var connection = new OdbcConnection(connectionStringBuilder.ConnectionString);

            try
            {
                connection.Open();

                return connection;
            }
            catch (Exception exception)
            {
                throw new GatewayNotOpenedDataException(exception);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (connection.IsValueCreated)
                {
                    connection.Value.Dispose();
                }
            }
        }

        public Recipe FindRecipe(string name)
        {
            try
            {
                return recipeDataProvider.FindRecipeByName(name, connection.Value);
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
                return recipeDataProvider.FindAllRecipes(connection.Value);
            }
            catch (Exception exception)
            {
                throw new DataException(exception);
            }
        }
    }
}