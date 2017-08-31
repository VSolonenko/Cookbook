using System;

namespace Cookbook.Presentation.ConsoleApplication.Exceptions
{
    internal sealed class PresentationException : Exception
    {
        public PresentationException(string message) :
            base(message)
        {
        }

        public PresentationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}