using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium.TestConfigs;

namespace Selenium.PageObject
{
    public class UserAccountPage:Browser
    {
        public UserAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement PageHeading => Driver.FindElement(By.XPath("//h1[@class='page-heading']"));
        public IWebElement InfoAccount => Driver.FindElement(By.XPath("//p[@class='info-account']"));

        public string GetPageHeaderName()
        {
           var text = PageHeading.Text;
           return text;
        }

        public string GetInfoAccount()
        {
            return InfoAccount.Text;
        }

    }
}
