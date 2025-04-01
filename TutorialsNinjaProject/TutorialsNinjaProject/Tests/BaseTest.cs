using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TutorialsNinjaProject.Drivers;

namespace TutorialsNinjaProject.Tests
{
    internal class BaseTest
    {
        protected IWebDriver driver;
        private DriverManager driverManager;

        [SetUp]
        public void SetUp()
        {
            driverManager = new DriverManager();
            driver = driverManager.InitializeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driverManager.CloseBrowser();
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}
