using System;

namespace Cookbook.Business.Exceptions
{
    public sealed class DataSourceBusinessException : BusinessException
    {
        public DataSourceBusinessException()
        {
        }

        public DataSourceBusinessException(Exception innerException) :
            base(innerException)
        {
        }
    }
}