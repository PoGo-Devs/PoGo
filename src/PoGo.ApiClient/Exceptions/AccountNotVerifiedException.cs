using System;

namespace PoGo.ApiClient.Exceptions
{
    public class AccountNotVerifiedException : Exception
    {
        public AccountNotVerifiedException(string message) : base(message)
        {
        }
    }
}