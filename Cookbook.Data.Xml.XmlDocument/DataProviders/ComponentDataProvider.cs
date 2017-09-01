using Cookbook.Business.Models;
using ComponentDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Component;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class ComponentDataProvider : IComponentDataProvider
    {
        private const string AttributeId = "Id";
        private const string AttributeIngredientId = "IngredientId";
        private const string AttributeQuantity = "Quantity";
        private const string AttributeUnitId = "UnitId";

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
                Id = int.Parse(componentNode.Attributes[AttributeId].Value),
                IngredientId = int.Parse(componentNode.Attributes[AttributeIngredientId].Value),
                Quantity = double.Parse(componentNode.Attributes[AttributeQuantity].Value),
                UnitId = int.Parse(componentNode.Attributes[AttributeUnitId].Value)
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