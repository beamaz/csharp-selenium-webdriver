using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriverPractice
{
    [TestFixture]
    public class SimpleFormDemoTests
    {
        private ChromeDriver _chromeDriver;
        private const string SimpleFormUrl = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

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
        public void ShouldDisplaySubmittedMessageInEasyFormScenario()
        {
            _chromeDriver.Url = SimpleFormUrl;

            var inputElement = _chromeDriver.FindElementByCssSelector(".form-group > #user-message");
            inputElement.SendKeys("Hello, Selenium!");

            var buttonElement = _chromeDriver.FindElementByCssSelector("#get-input > button");
            buttonElement.Click();

            var messageElement = _chromeDriver.FindElementByCssSelector("#display");
            var messageContent = messageElement.Text;

            Assert.AreEqual("Hello, Selenium!", messageContent);
        }

        [Test]
        public void ShouldDisplayNothingWhenSubmittedMessageIsEmptyInEasyFormScenario()
        {
            _chromeDriver.Url = SimpleFormUrl;

            var buttonElement = _chromeDriver.FindElementByCssSelector("#get-input > button");
            buttonElement.Click();

            var messageElement = _chromeDriver.FindElementByCssSelector("#display");
            var messageContent = messageElement.Text;

            Assert.AreEqual("", messageContent);
        }

        [Test]
        [TestCase("6", "12", ExpectedResult = "Total a + b = 18")]
        [TestCase("abc", "12", ExpectedResult = "Total a + b = NaN")]
        [TestCase("1000000000", "1000000000", ExpectedResult = "Total a + b = 2000000000")]

        public string ShouldAddedTwoNumbers(string firstNumber, string secondNumber)
        {
            _chromeDriver.Url = SimpleFormUrl;

            var inputAElement = _chromeDriver.FindElementByCssSelector("#sum1");
            inputAElement.SendKeys(firstNumber);

            var inputBelement = _chromeDriver.FindElementByCssSelector("#sum2");
            inputBelement.SendKeys(secondNumber);

            var buttonElement = _chromeDriver.FindElementByCssSelector("#gettotal > button");
            buttonElement.Click();

            var messageElement =
                _chromeDriver.FindElementByCssSelector(
                    "#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div");
            var messageContent = messageElement.Text;

            return messageContent;
        }
    }
}