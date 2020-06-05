using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Selenium.TestConfigs
{
    public class Browser
    {
        protected  IWebDriver Driver { get; set; }
        public WebDriverWait DefaultWait { get; }

        public Browser(IWebDriver driver)
        {
            Driver = driver;
            DefaultWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        
    }
}
