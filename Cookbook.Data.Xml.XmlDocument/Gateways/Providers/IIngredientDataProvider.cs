using Cookbook.Business.Models;

namespace Cookbook.Data.Xml.XmlDocument.Gateways.Providers
{
    using System.Xml;

    internal interface IIngredientDataProvider
    {
        Ingredient FindIngredientById(int ingredientId, XmlDocument document);
    }
}