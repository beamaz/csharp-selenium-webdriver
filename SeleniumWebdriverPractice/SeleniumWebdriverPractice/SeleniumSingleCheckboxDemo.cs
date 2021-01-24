using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriverPractice
{
    class SeleniumSingleCheckboxDemo
    {
        [TestFixture]
        public class SimpleFormDemoTests
        {
            private ChromeDriver _chromeDriver;
            private const string SimpleFormUrl = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

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
            public void ShouldDisplaySubmittedMessage()
            {
                _chromeDriver.Url = SimpleFormUrl;

                var checkBoxElement = _chromeDriver.FindElementByCssSelector("#isAgeSelected");
                checkBoxElement.Click();

                Assert.IsTrue(checkBoxElement.Selected);
                var messageElement = _chromeDriver.FindElementByCssSelector("#txtAge");
                var messageContent = messageElement.Text;

                Assert.AreEqual("Success - Check box is checked", messageContent);
            }

            [Test]
            public void ShouldBeAllSelected()
            {
                _chromeDriver.Url = SimpleFormUrl;

                string[] selectorsTable = new string[] { "#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label > input",
                                                          "#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(4) > label > input",
                                                          "#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(5) > label > input",
                                                          "#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(6) > label > input"};

                foreach (var selector in selectorsTable)
                {
                    var checkBoxElement = _chromeDriver.FindElementByCssSelector(selector);
                    Assert.IsFalse(checkBoxElement.Selected);
                }

                var buttonElement = _chromeDriver.FindElementByCssSelector("#check1");
                buttonElement.Click();

                foreach (var selector in selectorsTable)
                {
                    var checkBoxElement = _chromeDriver.FindElementByCssSelector(selector);
                    Assert.IsTrue(checkBoxElement.Selected);
                }
            }
        }
    }
}

