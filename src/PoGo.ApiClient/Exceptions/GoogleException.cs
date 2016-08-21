using System;

namespace PoGo.ApiClient.Exceptions
{
    public class GoogleException : Exception
    {
        public GoogleException(string message) : base(message)
        {
        }
    }
}