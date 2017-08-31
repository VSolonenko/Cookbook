using System;

namespace Cookbook.Business.Exceptions
{
    public abstract class BusinessException : Exception
    {
        protected BusinessException()
        {
        }

        protected BusinessException(Exception innerException) :
            base(string.Empty, innerException)
        {
        }
    }
}