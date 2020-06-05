using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DummyTests
{

    class Tests : TestBase
    {
        private int _invalidImageCount;

        private string _baseUrl = "https://the-internet.herokuapp.com";

        [Test]
        public void BrokenImagesTest()
        {

            _invalidImageCount = 0;
            _driver.Navigate().GoToUrl(_baseUrl + "/broken_images");

            var images = _driver.FindElements(By.XPath("//*[@class=\"example\"]//img"));

            foreach (var image in images)
            {
                VerifyImageActive(image);
            }

            _invalidImageCount.Should().BeGreaterOrEqualTo(2);
        }

        [Test]
        public void ContextMenu()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/context_menu");

            var contextMenu= _driver.FindElement(By.XPath("//*[@id=\"hot-spot\"]"));
            Actions actions = new Actions(_driver);
            actions.ContextClick(contextMenu).Perform();

            var alert = _driver.SwitchTo().Alert();
            alert.Text.Should().Be("You selected a context menu");

        }

        [Test]
        public void DisappearOfElements()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/disappearing_elements");

            var elements = _driver.FindElements(By.XPath("//div/ul/li"));

            _driver.Navigate().Refresh();

            var newElements = _driver.FindElements(By.XPath("//div/ul/li"));

            if (elements.Count == newElements.Count)
            {
                _driver.Navigate().Refresh();
            }

            elements.Count.Should().NotBe(newElements.Count);

           
        }

        [Test]
        public void DigestAuthentication()
        {
            _driver.Navigate().GoToUrl("https://" + "admin:"+"admin"+ "@" + "the-internet.herokuapp.com" + "/digest_auth");

            var displayed = _driver.FindElement(
                By.XPath("//p[contains(text(),'Congratulations! You must have the proper credentials.')]")).Displayed;
            displayed.Should().BeTrue();
        }

        [Test]
        public void DragAndDrop()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/drag_and_drop");
            var colunmA = _driver.FindElement(By.XPath("//*[@id=\"column-a\"]"));
            var colunmB = _driver.FindElement(By.XPath("//*[@id=\"column-b\"]"));

            var actions = new Actions(_driver);
            var dragAndDrop= actions.ClickAndHold(colunmA).MoveToElement(colunmB).Release(colunmA).Build();

            dragAndDrop.Perform();
            

            var text = _driver.FindElement(By.XPath("//*[@id=\"column-a\"]/header")).Text;

            text.Should().Be("B");


        }

    
        public void VerifyImageActive(IWebElement imgElement)
        {
            try
            {
                HttpClient client = new HttpClient();
                var request = client.GetAsync($"{imgElement.GetAttribute("src")}");

                if (request.Result.IsSuccessStatusCode != true)
                {
                    _invalidImageCount++;

                }
                
            }
            catch (Exception e)
            {
                var eMessage = e.Message;
            }
        }
    }
}

