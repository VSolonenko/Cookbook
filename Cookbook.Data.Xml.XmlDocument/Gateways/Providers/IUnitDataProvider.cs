using Cookbook.Business.Models;

namespace Cookbook.Data.Xml.XmlDocument.Gateways.Providers
{
    using System.Xml;

    internal interface IUnitDataProvider
    {
        Unit FindUnitById(int unitId, XmlDocument document);
    }
}