using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using SHMIP;

namespace SHMIP.Test
{
    [TestClass]
    public class test4
    {
        [Test]
        public void TestInvalidCredentials()
        {
       
            var form = new AutorizationForm();
            string invalidUsername = "fake@example.com";
            string invalidPassword = "invalidpass";

           
            bool success = form.AuthenticateUser(invalidUsername, invalidPassword, out _, out _);

    
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(success);

        }
    }
}
