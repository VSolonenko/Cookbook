using System;

namespace Cookbook.Data.Xml.XmlDocument.Exceptions
{
    internal sealed class RecipeNameNotFoundXmlDataException : XmlDataException
    {
        private readonly string recipeName;

        public RecipeNameNotFoundXmlDataException(string recipeName) :
            this(recipeName, innerException: null)
        {
        }

        public RecipeNameNotFoundXmlDataException(string recipeName, Exception innerException) :
            base(innerException)
        {
            this.recipeName = recipeName;
        }

        public string RecipeName => recipeName;
    }
}