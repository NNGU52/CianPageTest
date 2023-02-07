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
        private readonly By _rentButton = By.XPath("//a[@class='_25d45facb5--link--rqF9a']");
        private readonly By _magazineButton = By.XPath("//span[@data-testid='dropdown_link_icon']");
        public readonly By _feedbackButton = By.XPath("//img[@class='uxs-17nl1ib uxs-2O1rU349bI']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ChangeLocation()
        {
            var nameBy = driver.FindElement(_locationButton);
            nameBy.Click();
        }

        public void LookingForAnElement()
        {
            var rentBy = driver.FindElement(_rentButton);
            Actions builder = new Actions(driver);
            builder.MoveToElement(rentBy).Perform();
            WaitElement(_magazineButton);
            var magazineBy = driver.FindElement(_magazineButton);
            magazineBy.Click();
        }

        public void LeaveFeedback()
        {
            var feedback = driver.FindElement(_feedbackButton);
            feedback.Click();
        }

        public void WaitElement(By locator)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Erroneous text: {locator}", ex);
            }
        }

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
