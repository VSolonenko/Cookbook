using Cookbook.Data.Exceptions;
using System;

namespace Cookbook.Data.Xml.XmlDocument.Exceptions
{
    internal abstract class XmlDataException : DataException
    {
        protected XmlDataException()
        {
        }

        protected XmlDataException(Exception innerException) :
            base(innerException)
        {
        }
    }
}