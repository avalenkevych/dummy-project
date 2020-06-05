using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Models;
using Selenium.PageObject;

namespace Selenium.Tests
{
    [TestFixture]
    public class Tests:TestBase
    {

        [Test]
        public void UserRegistrationTest()
        {
            var form = new RegisterForm()
            {
                FirstName = "Anton",
                LastName = "Test",
                City = "Chicago",
                FirstNameForAddress = "sad",
                LastNameForAddress = "asddsa",
                ZipCode = "10001",
                Password = "12345",
                Address1 = "Add",
                Alias="asdasd",
                MobilePhone = "123456789"
            };

                
           var homePage = new HomePage(_driver);
           homePage.SignUpClick();
           homePage.SetEmail("qwe123123@email.com");
           homePage.GoToCreateAccountPage()
               .CreateAccount(form)
               .SubmitRegisterForm()
               .UserNameElement.Should().Be("Anton Test");

        }

        [Test]
        public void UserLoginTest()
        {
            var loginForm = new LoginForm()
            {
                Email = "test12232@email.com",
                Password = "12345"
            };

            var homePage = new HomePage(_driver);
            homePage.SignUpClick();
            homePage.SubmitLoginForm(loginForm)
                .GoToUserAccountPage()
                .GetPageHeaderName().Should().Be("MY ACCOUNT");

            var user = new UserAccountPage(_driver);
            user.GetInfoAccount().Should().Be("Welcome to your account. Here you can manage all of your personal information and orders.");

        }

        [Test]
        public void HoverEffectTest()
        {
            var homePage = new HomePage(_driver);

            homePage.HoverEffect();
            homePage.IsTopsDisplay().Should().BeTrue();
            
        }

        [Test]
        public void IframeTest()
        {
            var homePage = new HomePage(_driver);
            homePage.HoverMouseToProduct();
            homePage.QuickViewClick();
            homePage.SwitchIframe();
            homePage.AddProductToTheCard();
            homePage.ProductText().Should().Be("Product successfully added to your shopping cart");

        }

        [Test]
        public void ShareProductTest()
        {
            var homePage = new HomePage(_driver);
            homePage.HoverMouseToProduct();
            homePage.QuickViewClick();
            homePage.SwitchIframe();
            homePage.ClickOnTwitter();
            homePage.SwitchBrowserWindow();
            _driver.Title.Should().Be("Post a Tweet on Twitter");
        }


        
    }
}