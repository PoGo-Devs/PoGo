using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
        {
        }

        public LoginFailedException(HttpResponseMessage loginResponse)
        {
            LoginResponse = loginResponse;
        }

        public HttpResponseMessage LoginResponse { get; }

        public async Task<string> GetLoginResponseContentAsString()
        {
            return await LoginResponse.Content.ReadAsStringAsync();
        }
    }
}