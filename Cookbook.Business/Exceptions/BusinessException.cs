using System;

namespace Cookbook.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(Exception innerException) :
            base(string.Empty, innerException)
        {
        }
    }
}