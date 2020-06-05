using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium.Models;
using Selenium.TestConfigs;

namespace Selenium.PageObject
{
    public class HomePage : Browser
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public  IWebElement SignIn => Driver.FindElement(By.XPath("//a[@class='login']"));
        public  IWebElement CreateAccountBtn => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));
        public  IWebElement Email => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        public string UserNameElement => Driver.FindElement(By.XPath("//a[@class='account']")).Text;
        
        //Login Form
        public IWebElement EmailField => Driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement PasswordField => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        public IWebElement SubmitLogin => Driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));

        //Navigation
        public IWebElement HoverElement => Driver.FindElement(By.XPath("//a[contains(@title,'Women')]"));
        public IWebElement Tops => Driver.FindElement(By.XPath("//a[contains(@title,'Tops')]"));

        //Products
        public IWebElement Product => Driver.FindElement(By.XPath("(//*[@class='product-image-container'])[3]"));
        public IWebElement QuickViewBtn => Driver.FindElement(By.XPath("(//a[@class='quick-view'])[3]"));
        public IWebElement AddProductToCard => Driver.FindElement(By.XPath("//*[@id='add_to_cart']/button"));
        public IWebElement ProductAddedText => Driver.FindElement(By.XPath("//*[contains(text()[2], 'Product' )]"));

        public IWebElement TwitterButton =>
            Driver.FindElement(By.XPath("//button[@class='btn btn-default btn-twitter']"));

        public void SignUpClick()
        {
            SignIn.Click();
        }

        public void SetEmail(string email)
        {
            Email.SendKeys(email);
        }

        public  CreateAccountPage GoToCreateAccountPage()
        {
            CreateAccountBtn.Click();
            return new CreateAccountPage(Driver);
        }

        public HomePage SubmitLoginForm(LoginForm loginForm)
        {
            EmailField.SendKeys(loginForm.Email);
            PasswordField.SendKeys(loginForm.Password);
            SubmitLogin.Click();
            return this;
        }

        public UserAccountPage GoToUserAccountPage()
        {
            return new UserAccountPage(Driver);
        }

        public void HoverEffect()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(HoverElement).Perform();
        }

        public bool IsTopsDisplay()
        {
            return Tops.Displayed;
        }

        public void HoverMouseToProduct()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(Product).Perform();

        }

        public void QuickViewClick()
        {
            QuickViewBtn.Click();
        }

        public void SwitchIframe()
        {
            
            Driver.SwitchTo().Frame(1);
            
        }

        public void AddProductToTheCard()
        {
            AddProductToCard.Click();
        }

        public string ProductText()
        {
           
            DefaultWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text()[2], 'Product' )]")));
            return ProductAddedText.Text;
        }

        public void ClickOnTwitter()
        {
            TwitterButton.Click();
        }

        public void SwitchBrowserWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

        }

    }
}