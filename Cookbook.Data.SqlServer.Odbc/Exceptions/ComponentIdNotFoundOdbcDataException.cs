using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal sealed class ComponentIdNotFoundOdbcDataException : OdbcDataException
    {
        private readonly int componentId;

        public ComponentIdNotFoundOdbcDataException(int componentId) :
            this(componentId, innerException: null)
        {
        }

        public ComponentIdNotFoundOdbcDataException(int componentId, Exception innerException) :
            base(innerException)
        {
            this.componentId = componentId;
        }

        public int ComponentId => componentId;
    }
}