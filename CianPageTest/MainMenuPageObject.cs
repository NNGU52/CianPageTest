using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class MainMenuPageObject
    {
        IWebDriver driver;

        public readonly By _locationButton = By.XPath("//span[@class='_025a50318d--text--SCFDt']");


        public MainMenuPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ChangeLocation()
        {
            var nameBy = driver.FindElement(_locationButton);
            nameBy.Click();
        }

        // явное ожидание 
        public void WaitElement(IWebElement element, string str)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, str));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Erroneous text: {element}", ex);
            }
        }

    }
}
