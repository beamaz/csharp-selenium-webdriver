using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriverPractice
{
    public static class SeleniumEasyWebpageUtils
    {
        public static void NavigateToWebpageAndDismissModal(ChromeDriver chromeDriver, string url)
        {
            chromeDriver.Url = url;
            const string modalButtonSelector = "#at-cv-lightbox-button-holder > a.at-cv-button.at-cv-lightbox-yesno.at-cm-no-button";
            try
            {
                var modalButton = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5))
                    .Until(driver => driver.FindElement(By.CssSelector(modalButtonSelector)));
                if (modalButton != null)
                {
                    modalButton.Click();
                }
            }
            catch
            {
                // ignored
            }
        }

    }
}
