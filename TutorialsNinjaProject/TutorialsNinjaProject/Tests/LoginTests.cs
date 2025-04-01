using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TutorialsNinjaProject.Tests
{
    internal class LoginTests : BaseTest
    {
        [Test]
        public void VerifyLoginWithValidCredentials()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("amotooricap6@gmail.com");
            driver.FindElement(By.Id("input-password")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            Assert.IsTrue(driver.FindElement(By.LinkText("Logout")).Displayed);
        }

        [Test]
        public void VerifyLoginWithInvalidCredentials()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Login")).Click();

            driver.FindElement(By.Id("input-email")).SendKeys(GenerateEmail());
            driver.FindElement(By.Id("input-password")).SendKeys("67890");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            string expectedWarningMessage = "Warning: No match for E-Mail Address and/or Password.";
            Assert.AreEqual(expectedWarningMessage, driver.FindElement(By.CssSelector("div[class='alert alert-danger alert-dismissible']")).Text);
        }

        [Test]
        public void VerifyLoginWithInvalidEmailAndValidPassword()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Login")).Click();

            driver.FindElement(By.Id("input-email")).SendKeys(GenerateEmail());
            driver.FindElement(By.Id("input-password")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            string expectedWarningMessage = "Warning: No match for E-Mail Address and/or Password.";
            Assert.AreEqual(expectedWarningMessage, driver.FindElement(By.CssSelector("div[class='alert alert-danger alert-dismissible']")).Text);
        }

        [Test]
        public void VerifyLoginWithValidEmailAndInvalidPassword()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Login")).Click();

            driver.FindElement(By.Id("input-email")).SendKeys("amotooricap6@gmail.com");
            driver.FindElement(By.Id("input-password")).SendKeys("67890");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            string expectedWarningMessage = "Warning: No match for E-Mail Address and/or Password.";
            Assert.AreEqual(expectedWarningMessage, driver.FindElement(By.CssSelector("div[class='alert alert-danger alert-dismissible']")).Text);
        }

        [Test]
        public void VerifyLoginWithoutEnteringAnyCredentials()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            string expectedWarningMessage = "Warning: No match for E-Mail Address and/or Password.";
            Assert.AreEqual(expectedWarningMessage, driver.FindElement(By.CssSelector("div[class='alert alert-danger alert-dismissible']")).Text);
        }

        public string GenerateEmail()
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            string domain = "example.com";
            return $"user{timestamp}@{domain}";
        }
    }
}
