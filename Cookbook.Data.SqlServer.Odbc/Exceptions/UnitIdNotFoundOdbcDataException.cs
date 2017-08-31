using System;

namespace Cookbook.Data.SqlServer.Odbc.Exceptions
{
    internal sealed class UnitIdNotFoundOdbcDataException : OdbcDataException
    {
        private readonly int unitId;

        public UnitIdNotFoundOdbcDataException(int unitId) :
            this(unitId, innerException: null)
        {
        }

        public UnitIdNotFoundOdbcDataException(int unitId, Exception innerException) :
            base(innerException)
        {
            this.unitId = unitId;
        }

        public int UnitId => unitId;
    }
}