using System;

namespace Cookbook.Data.Xml.XmlDocument.Exceptions
{
    internal sealed class IngredientIdNotFoundXmlDataException : XmlDataException
    {
        private readonly int ingredientId;

        public IngredientIdNotFoundXmlDataException(int ingredientId) :
            this(ingredientId, innerException: null)
        {
        }

        public IngredientIdNotFoundXmlDataException(int ingredientId, Exception innerException) :
            base(innerException)
        {
            this.ingredientId = ingredientId;
        }

        public int IngredientId => ingredientId;
    }
}