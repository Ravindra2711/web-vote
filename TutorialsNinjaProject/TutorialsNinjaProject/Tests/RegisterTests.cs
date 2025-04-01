using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TutorialsNinjaProject.Tests
{
    internal class RegisterTests: BaseTest
    {
        [Test]

        public void VerifyRegisterWithValidCredentials()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Register")).Click();

        }
    
    }
}
