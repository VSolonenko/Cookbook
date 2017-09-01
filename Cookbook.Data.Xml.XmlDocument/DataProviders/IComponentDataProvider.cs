using Cookbook.Business.Models;

namespace Cookbook.Data.Xml.XmlDocument.DataProviders
{
    using System.Xml;

    internal interface IComponentDataProvider
    {
        Component ReadComponentFromNode(XmlNode componentNode, XmlDocument document);
    }
}