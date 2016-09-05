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

            var ptcLogin = new PtcAuthenticationProvider("testuser", "testpass");
            var loginData = await ptcLogin.GetLoginParameters().ConfigureAwait(false);
            Assert.IsNotNull(loginData);
            Assert.IsTrue(string.IsNullOrWhiteSpace(loginData.Lt));
            Assert.IsTrue(string.IsNullOrWhiteSpace(loginData.Execution));

            //loginData.Should().NotBeNull();
            //loginData.Lt.Should().NotBeNullOrWhiteSpace();
            //loginData.Execution.Should().NotBeNullOrWhiteSpace();

        }

    }

}