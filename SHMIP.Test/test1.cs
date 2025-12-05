
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using SHMIP;

namespace SHMIP.Test
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void TestAdminAuthenticationSuccess()
        {
            
            var form = new AutorizationForm();
            string username = "o@outlook.com";
            string password = "2L6KZG";

            
            bool success = form.AuthenticateUser(username, password, out _, out _);

           
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(success);
        }
    }
}
