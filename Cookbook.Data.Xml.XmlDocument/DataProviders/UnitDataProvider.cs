using Cookbook.Business.Models;
using Cookbook.Data.Xml.XmlDocument.Exceptions;
using UnitDto = Cookbook.Data.Xml.XmlDocument.TransferObjects.Unit;
using UnitElement = Cookbook.Data.Xml.XmlDocument.DataProviders.Elements.Unit;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal sealed class UnitDataProvider : IUnitDataProvider
    {
        public Unit FindUnitById(int unitId, XmlDocument document)
        {
            foreach (XmlNode unitNode in document.GetElementsByTagName(UnitElement.TagName))
            {
                var unitDto = new UnitDto
                {
                    Id = int.Parse(unitNode.Attributes[UnitElement.Id].Value)
                };

                if (unitDto.Id.Equals(unitId))
                {
                    unitDto.PluralName = unitNode.Attributes[UnitElement.PluralName].Value;
                    unitDto.SingularName = unitNode.Attributes[UnitElement.SingularName].Value;

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