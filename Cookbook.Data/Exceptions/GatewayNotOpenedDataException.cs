using System;

namespace Cookbook.Data.Exceptions
{
    public sealed class GatewayNotOpenedDataException : DataException
    {
        public GatewayNotOpenedDataException()
        {
        }

        public GatewayNotOpenedDataException(Exception innerException) :
            base(innerException)
        {
        }
    }
}