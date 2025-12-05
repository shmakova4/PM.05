using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using SHMIP;

namespace SHMIP.Test
{
    [TestClass]
    public class test5
    {
        [Test]
        public void TestCaptchaFailureTriggersTimeout()
        {
          
            var form = new AutorizationForm();
            string incorrectCaptcha = "INCORRECT_CAPTCHA";

      
            form.button_captcha_Click(null, null); 

           
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(form.button_enter.Enabled); 
        }
    }
}
