using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium.Models;
using Selenium.TestConfigs;

namespace Selenium.PageObject
{
    public class CreateAccountPage: HomePage
    {
        public CreateAccountPage(IWebDriver driver): base(driver)
        {
        }
        public IWebElement TitleMr => Driver.FindElement(By.XPath("//input[@id='id_gender1']"));
        public IWebElement FirstName => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        public IWebElement LastName => Driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        public IWebElement Password => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        public IWebElement DateOfBirthDay => Driver.FindElement(By.XPath("//select[@id='days']/option[@value=20]"));
        public IWebElement DateOfBirthMonth => Driver.FindElement(By.XPath("//select[@id='months']/option[@value=10]"));
        public IWebElement DateOfBirthYear => Driver.FindElement(By.XPath("//select[@id='years']/option[@value=1991]"));
        public IWebElement NewsLetterCheckBox => Driver.FindElement(By.XPath("//input[@id='newsletter']"));
        public IWebElement OptionsCheckBox => Driver.FindElement(By.XPath("//input[@id='optin']"));
        public IWebElement FirstNameForAddress => Driver.FindElement(By.XPath("//input[@id='firstname']"));
        public IWebElement LastNameForAddress => Driver.FindElement(By.XPath("//input[@id='lastname']"));
        public IWebElement Address1 => Driver.FindElement(By.XPath("//input[@id='address1']"));
        public IWebElement City => Driver.FindElement(By.XPath("//input[@id='city']"));
        public IWebElement State => Driver.FindElement(By.XPath("//select[@id='id_state']/option[@value=5]"));
        public IWebElement ZipCode => Driver.FindElement(By.XPath("//input[@id='postcode']"));
        public IWebElement Country => Driver.FindElement(By.XPath("//select[@id='id_country']/option[2]"));
        public IWebElement MobilePhone => Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
        public IWebElement Alias => Driver.FindElement(By.XPath("//input[@id='alias']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@id='submitAccount']"));


        public CreateAccountPage CreateAccount(RegisterForm registerForm)
        {
            TitleMr.Click();
            FirstName.SendKeys(registerForm.FirstName);
            LastName.SendKeys(registerForm.LastName);
            Password.SendKeys(registerForm.Password);
            DateOfBirthDay.Click();
            DateOfBirthMonth.Click();
            DateOfBirthYear.Click();
            NewsLetterCheckBox.Click();
            OptionsCheckBox.Click();
            FirstNameForAddress.SendKeys(registerForm.FirstNameForAddress);
            LastNameForAddress.SendKeys(registerForm.LastNameForAddress);
            Address1.SendKeys(registerForm.Address1);
            City.SendKeys(registerForm.City);
            State.Click();
            ZipCode.SendKeys(registerForm.ZipCode);
            Country.Click();
            MobilePhone.SendKeys(registerForm.MobilePhone);
            Alias.SendKeys(registerForm.Alias);
            return this;
        }

        public CreateAccountPage SubmitRegisterForm()
        {
            SubmitButton.Click();
            return this;
        }
    }
}
