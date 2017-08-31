using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal sealed class RecipeNameNotFoundOdbcDataException : OdbcDataException
    {
        private readonly string recipeName;

        public RecipeNameNotFoundOdbcDataException(string recipeName) :
            this(recipeName, innerException: null)
        {
        }

        public RecipeNameNotFoundOdbcDataException(string recipeName, Exception innerException) :
            base(innerException)
        {
            this.recipeName = recipeName;
        }

        public string RecipeName => recipeName;
    }
}