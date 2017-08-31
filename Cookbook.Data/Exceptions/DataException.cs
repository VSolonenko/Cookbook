using System;

namespace Cookbook.Data.Exceptions
{
    public class DataException : Exception
    {
        public DataException()
        {
        }

        public DataException(Exception innerException) :
            base(string.Empty, innerException)
        {
        }
    }
}