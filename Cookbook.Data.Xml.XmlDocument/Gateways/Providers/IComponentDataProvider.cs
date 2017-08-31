using Cookbook.Business.Models;

namespace Cookbook.Data.Xml.XmlDocument.Gateways.Providers
{
    using System.Xml;

    internal interface IComponentDataProvider
    {
        Component ReadComponentFromNode(XmlNode componentNode, XmlDocument document);
    }
}