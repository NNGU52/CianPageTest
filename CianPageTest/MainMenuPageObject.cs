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
        private readonly By _peakButton = By.XPath("//a[@data-name='SpecialPromoDesktop']");
        private readonly By _objectComparisonButton = By.XPath("//a[@data-name='UtilityCompareContainer']");
        private readonly By _asseptCookiesButton = By.XPath("//div[@class='_25d45facb5--button--CaFmg']");
        private readonly By _allTheTopTabs = By.CssSelector("._25d45facb5--link--rqF9a");

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

        public void ClickLeaveFeedback()
        {
            var feedback = driver.FindElement(_feedbackButton);
            feedback.Click();
        }

        public void ClickElementPeak()
        {
            var peak = driver.FindElement(_peakButton);
            peak.Click();
        }

        public void ClickElementObjectComparison()
        {
            var objectComparison = driver.FindElement(_objectComparisonButton);
            objectComparison.Click();
        }

        public bool ClickElementAsseptCookies()
        {
            var asseptCookies = driver.FindElement(_asseptCookiesButton);
            asseptCookies.Click();

            return CheckElement(_asseptCookiesButton);
        }

        public List<string> AllTheTopTabs()
        {
            var list = driver.FindElements(_allTheTopTabs).Select(x => x.Text).ToList();
            return list;
        }

        public void WaitElement(By locator)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Not found: {locator}", ex);
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

        public bool CheckElement(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
