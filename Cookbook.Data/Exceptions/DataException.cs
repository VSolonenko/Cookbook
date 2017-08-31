using System;

namespace Cookbook.Data.Exceptions
{
    public abstract class DataException : Exception
    {
        protected DataException()
        {
        }

        protected DataException(Exception innerException) :
            base(string.Empty, innerException)
        {
        }
    }
}