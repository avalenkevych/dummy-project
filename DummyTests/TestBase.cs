using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DummyTests
{
    public class TestBase
    {
        protected IWebDriver _driver;
        

        [SetUp]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [TearDown]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}