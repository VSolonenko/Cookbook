using Cookbook.Business.Models;
using Cookbook.Data.Xml.XmlDocument.Exceptions;
using IngredientDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Ingredient;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class IngredientDataProvider : IIngredientDataProvider
    {
        private const string AttributeId = "Id";
        private const string AttributeName = "Name";
        private const string IngredientTag = "Ingredient";

        public Ingredient FindIngredientById(int ingredientId, XmlDocument document)
        {
            foreach (XmlNode ingredientNode in document.GetElementsByTagName(IngredientTag))
            {
                var ingredientDto = new IngredientDto
                {
                    Id = int.Parse(ingredientNode.Attributes[AttributeId].Value)
                };

                if (ingredientDto.Id.Equals(ingredientId))
                {
                    ingredientDto.Name = ingredientNode.Attributes[AttributeName].Value;

                    return new Ingredient(
                        id: ingredientDto.Id,
                        name: ingredientDto.Name
                    );
                }
            }

            throw new IngredientIdNotFoundXmlDataException(ingredientId);
        }
    }
}