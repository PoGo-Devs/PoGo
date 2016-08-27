using System;


namespace PoGo.ApiClient.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException() : base("Your account has been locked/banned.")
        {
        }
    }
}
