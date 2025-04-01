using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TutorialsNinjaProject.Drivers;

namespace TutorialsNinjaProject.Tests
{
    internal class SearchTests: BaseTest
    {

        [Test]
        public void VerifySearchingWithExistingProduct()
        {
            driver.FindElement(By.Name("search")).SendKeys("HP");
            driver.FindElement(By.CssSelector("button[class='btn btn-default btn-lg']")).Click();

            Assert.IsTrue(driver.FindElement(By.LinkText("HP LP3065")).Displayed);
        }

        [Test]
        public void VerifySearchingWithANonExistingProduct()
        {
            driver.FindElement(By.Name("search")).SendKeys("Honda");
            driver.FindElement(By.CssSelector("button[class='btn btn-default btn-lg']")).Click();

            string expectedMessage = "There is no product that matches the search criteria.";
            Assert.AreEqual(expectedMessage, driver.FindElement(By.XPath("//div[@id='content']/p[2]")).Text);
        }

        [Test]
        public void VerifySearchingWithoutEnteringAnyProduct()
        {
            driver.FindElement(By.CssSelector("button[class='btn btn-default btn-lg']")).Click();

            string expectedMessage = "There is no product that matches the search criteria.";
            Assert.AreEqual(expectedMessage, driver.FindElement(By.XPath("//div[@id='content']/p[2]")).Text);
        }
    }
}
