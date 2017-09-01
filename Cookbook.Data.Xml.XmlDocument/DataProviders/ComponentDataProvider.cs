using Cookbook.Business.Models;
using ComponentDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Component;
using ComponentElement = Cookbook.Data.Xml.XmlDocument.DataProviders.Elements.Component;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class ComponentDataProvider : IComponentDataProvider
    {
        private readonly IIngredientDataProvider ingredientDataProvider;
        private readonly IUnitDataProvider unitDataProvider;

        public ComponentDataProvider(IIngredientDataProvider ingredientDataProvider, IUnitDataProvider unitDataProvider)
        {
            this.ingredientDataProvider = ingredientDataProvider;
            this.unitDataProvider = unitDataProvider;
        }

        public Component ReadComponentFromNode(XmlNode componentNode, XmlDocument document)
        {
            var componentDto = new ComponentDto
            {
                Id = int.Parse(componentNode.Attributes[ComponentElement.Id].Value),
                IngredientId = int.Parse(componentNode.Attributes[ComponentElement.IngredientId].Value),
                Quantity = double.Parse(componentNode.Attributes[ComponentElement.Quantity].Value),
                UnitId = int.Parse(componentNode.Attributes[ComponentElement.UnitId].Value)
            };

            Ingredient ingredient = ingredientDataProvider.FindIngredientById(componentDto.IngredientId, document);
            Unit unit = unitDataProvider.FindUnitById(componentDto.UnitId, document);

            return new Component(
                id: componentDto.Id,
                ingredient: ingredient,
                quantity: componentDto.Quantity,
                unit: unit
            );
        }
    }
}