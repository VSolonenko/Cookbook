using Cookbook.Business.Models;
using Cookbook.Data.Xml.XmlDocument.Exceptions;
using IngredientDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Ingredient;
using IngredientElement = Cookbook.Data.Xml.XmlDocument.DataProviders.Elements.Ingredient;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class IngredientDataProvider : IIngredientDataProvider
    {
        public Ingredient FindIngredientById(int ingredientId, XmlDocument document)
        {
            foreach (XmlNode ingredientNode in document.GetElementsByTagName(IngredientElement.TagName))
            {
                var ingredientDto = new IngredientDto
                {
                    Id = int.Parse(ingredientNode.Attributes[IngredientElement.Id].Value)
                };

                if (ingredientDto.Id.Equals(ingredientId))
                {
                    ingredientDto.Name = ingredientNode.Attributes[IngredientElement.Name].Value;

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