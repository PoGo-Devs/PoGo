using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoGo.ApiClient;
using PoGo.ApiClient.Authentication;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoGo.Tests.ApiClient
{

    [TestClass]
    public class PtcLoginTests
    {

        [TestMethod]
        public async Task PtcLogin_GetLoginParameters()
        {
            var httpHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                AllowAutoRedirect = false
            };
            using (var httpClient = new HttpClient(httpHandler))
            {
                // robertmclaws: Should we be setting every UserAgent property like the other requests?
                httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.LoginUserAgent);

                var ptcLogin = new PtcAuthenticationProvider("testuser", "testpass");
                var loginData = await ptcLogin.GetLoginParameters(httpClient).ConfigureAwait(false);
                Assert.IsNotNull(loginData);
                Assert.IsTrue(string.IsNullOrWhiteSpace(loginData.Lt));
                Assert.IsTrue(string.IsNullOrWhiteSpace(loginData.Execution));

                //loginData.Should().NotBeNull();
                //loginData.Lt.Should().NotBeNullOrWhiteSpace();
                //loginData.Execution.Should().NotBeNullOrWhiteSpace();
            }

        }

    }

}