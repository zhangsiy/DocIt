using System;

namespace DocIt.Data.Exceptions
{
    internal class NotFoundException : System.Exception
    {
        internal NotFoundException(string message) :
            base(message)
        {

        }

        internal NotFoundException(string message, Exception innerException) :
            base(message, innerException)
        {

        }
    }
}