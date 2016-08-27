using System;

namespace PoGo.ApiClient.Exceptions
{
    public class ApiNonRecoverableException : Exception
    {
        public ApiNonRecoverableException(string reason) : base(reason)
        {
        }
    }
}