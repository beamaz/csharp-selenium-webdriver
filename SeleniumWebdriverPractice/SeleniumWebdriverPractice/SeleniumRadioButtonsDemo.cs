using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriverPractice
{
    class SeleniumRadioButtonsDemo
    {
        [TestFixture]
        public class SimpleFormDemoTests
        {
            private ChromeDriver _chromeDriver;
            private const string SimpleFormUrl = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";

            [OneTimeSetUp]
            public void SetUpFixture()
            {
                _chromeDriver = new ChromeDriver();
                SeleniumEasyWebpageUtils.NavigateToWebpageAndDismissModal(_chromeDriver, SimpleFormUrl);
            }

            [OneTimeTearDown]
            public void TearDown()
            {
                _chromeDriver.Close();
                _chromeDriver.Quit();
            }

            [Test]
            public void ShouldBeDisplayedFemale()
            {
                var buttonToSelect = _chromeDriver.FindElementByCssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > label:nth-child(3) > input[type=radio]");
                buttonToSelect.Click();

                var buttonToConfirm = _chromeDriver.FindElementByCssSelector("#buttoncheck");
                buttonToConfirm.Click();

                var messageElement = _chromeDriver.FindElementByCssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.radiobutton");
                var messageContent = messageElement.Text;
                Assert.AreEqual("Radio button 'Female' is checked", messageContent);
            }

            [Test]
            public void ShouldBeDisplayedMale()
            {
                var buttonToSelect = _chromeDriver.FindElementByCssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > label:nth-child(2) > input[type=radio]");
                buttonToSelect.Click();

                var buttonToConfirm = _chromeDriver.FindElementByCssSelector("#buttoncheck");
                buttonToConfirm.Click();

                var messageElement = _chromeDriver.FindElementByCssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.radiobutton");
                var messageContent = messageElement.Text;
                Assert.AreEqual("Radio button 'Male' is checked", messageContent);
            }
        }
    }
}
