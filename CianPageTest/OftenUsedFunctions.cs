using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class OftenUsedFunctions
    {
        protected static IWebDriver driver;

        // ожидание видимости элемента
        protected void WaitElementToBeVisible(By locator)
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

        // ожидание заданного текста у элемента
        protected void WaitElementTextToBePresent(IWebElement element, string str)
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

        // ожидание возможности клика на элемент
        protected void WaitElementToBeClickable(By locator)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Unable to click: {locator}", ex);
            }
        }

        // ожидание перехода на указанный url
        protected void WaitElementUrlToBe(string url)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(url));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Not found: {url}", ex);
            }
        }

        // проверка на наличие элемента на странице
        protected bool CheckElementLocator(By locator)
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

        // проверка наличия элемента на странице
        protected bool CheckElementStr(string str)
        {
            try
            {
                driver.PageSource.Contains(str);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // клик на элемент
        protected void ClickElement(By locator)
        {
            var element = driver.FindElement(locator);
            element.Click();
        }
    }
}
