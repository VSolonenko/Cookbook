using System;

namespace Cookbook.Data.Exceptions
{
    public sealed class RecipeNotFoundDataException : DataException
    {
        private readonly string recipeName;

        public RecipeNotFoundDataException(string recipeName) :
            this(recipeName, innerException: null)
        {
        }

        public RecipeNotFoundDataException(string recipeName, Exception innerException) :
            base(innerException)
        {
            this.recipeName = recipeName;
        }

        public string RecipeName => recipeName;
    }
}