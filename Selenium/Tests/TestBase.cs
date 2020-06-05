using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.PageObject;
using Selenium.TestConfigs;

namespace Selenium.Tests
{
   
    public class TestBase
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [OneTimeTearDown]
        public void TestCleanup()
        {
            _driver.Quit();
        }

    }
}
