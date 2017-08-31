using System;

namespace Cookbook.Business.Exceptions
{
    public sealed class RecipeNotFoundBusinessException : BusinessException
    {
        private readonly string recipeName;

        public RecipeNotFoundBusinessException(string recipeName) :
            this(recipeName, innerException: null)
        {
        }

        public RecipeNotFoundBusinessException(string recipeName, Exception innerException) :
            base(innerException)
        {
            this.recipeName = recipeName;
        }

        public string RecipeName => recipeName;
    }
}