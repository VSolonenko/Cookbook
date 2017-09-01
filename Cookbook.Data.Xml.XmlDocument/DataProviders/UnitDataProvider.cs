using Cookbook.Business.Models;
using Cookbook.Data.Xml.XmlDocument.Exceptions;
using UnitDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Unit;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class UnitDataProvider : IUnitDataProvider
    {
        private const string AttributeId = "Id";
        private const string AttributePluralName = "PluralName";
        private const string AttributeSingularName = "SingularName";
        private const string UnitTag = "Unit";

        public Unit FindUnitById(int unitId, XmlDocument document)
        {
            foreach (XmlNode unitNode in document.GetElementsByTagName(UnitTag))
            {
                var unitDto = new UnitDto
                {
                    Id = int.Parse(unitNode.Attributes[AttributeId].Value)
                };

                if (unitDto.Id.Equals(unitId))
                {
                    unitDto.PluralName = unitNode.Attributes[AttributePluralName].Value;
                    unitDto.SingularName = unitNode.Attributes[AttributeSingularName].Value;

                    return new Unit(
                        id: unitDto.Id,
                        singularName: unitDto.SingularName,
                        pluralName: unitDto.PluralName
                    );
                }
            }

            throw new UnitIdNotFoundXmlDataException(unitId);
        }
    }
}