using System;
using System.Net;

namespace DocIt.Data.Exceptions
{
    internal class VerboseHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public VerboseHttpRequestException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}