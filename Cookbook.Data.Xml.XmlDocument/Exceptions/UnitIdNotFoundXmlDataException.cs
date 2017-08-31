using System;

namespace Cookbook.Data.Xml.XmlDocument.Exceptions
{
    internal sealed class UnitIdNotFoundXmlDataException : XmlDataException
    {
        private readonly int unitId;

        public UnitIdNotFoundXmlDataException(int unitId) :
            this(unitId, innerException: null)
        {
        }

        public UnitIdNotFoundXmlDataException(int unitId, Exception innerException) :
            base(innerException)
        {
            this.unitId = unitId;
        }

        public int UnitId => unitId;
    }
}