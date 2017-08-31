using Cookbook.Business.Models;
using System.Collections.Generic;

namespace Cookbook.Data.Xml.XmlDocument.Gateways.Providers
{
    using System.Xml;

    internal interface IRecipeDataProvider
    {
        IEnumerable<Recipe> FindAllRecipes(XmlDocument document);
        Recipe FindRecipeByName(string recipeName, XmlDocument document);
        Recipe ReadRecipeFromNode(XmlNode recipeNode, XmlDocument document);
    }
}