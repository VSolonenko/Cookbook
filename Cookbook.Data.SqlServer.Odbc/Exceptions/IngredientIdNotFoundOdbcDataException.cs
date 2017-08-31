using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal sealed class IngredientIdNotFoundOdbcDataException : OdbcDataException
    {
        private readonly int ingredientId;

        public IngredientIdNotFoundOdbcDataException(int ingredientId) :
            this(ingredientId, innerException: null)
        {
        }

        public IngredientIdNotFoundOdbcDataException(int ingredientId, Exception innerException) :
            base(innerException)
        {
            this.ingredientId = ingredientId;
        }

        public int IngredientId => ingredientId;
    }
}