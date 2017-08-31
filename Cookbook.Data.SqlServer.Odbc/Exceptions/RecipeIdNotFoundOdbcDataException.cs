using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal sealed class RecipeIdNotFoundOdbcDataException : OdbcDataException
    {
        private readonly int recipeId;

        public RecipeIdNotFoundOdbcDataException(int recipeId) :
            this(recipeId, innerException: null)
        {
        }

        public RecipeIdNotFoundOdbcDataException(int recipeId, Exception innerException) :
            base(innerException)
        {
            this.recipeId = recipeId;
        }

        public int RecipeId => recipeId;
    }
}