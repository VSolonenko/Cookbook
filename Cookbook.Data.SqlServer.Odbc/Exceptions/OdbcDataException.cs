using Cookbook.Data.Exceptions;
using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal abstract class OdbcDataException : DataException
    {
        public OdbcDataException()
        {
        }

        public OdbcDataException(Exception innerException) :
            base(innerException)
        {
        }
    }
}