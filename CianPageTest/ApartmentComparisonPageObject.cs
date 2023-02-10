using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class ApartmentComparisonPageObject
    {
        IWebDriver driver;

        private readonly By _searchApartmentsButton = By.XPath("//span[@class='_5b10bb2305--text--rH6sj']");
        private readonly By _oneApartmentForm = By.XPath("(//span[@class='_93444fe79c--link-area--NQqFo'])[1]");
        private readonly By _twoApartmentForm = By.XPath("(//span[@class='_93444fe79c--link-area--NQqFo'])[2]");
        private readonly By _addOneApatmentButton = By.XPath("(//button[@data-mark='ComparisonControl'])[1]");
        private readonly By _addTwoApartmentButton = By.XPath("(//button[@data-mark='ComparisonControl'])[2]");
        private readonly By _numberApartmentText = By.XPath("//p[@class='_93444fe79c--color_white_100--YUO3d _93444fe79c--lineHeight_20px--tUURJ _93444fe79c--fontWeight_normal--P9Ylg _93444fe79c--fontSize_14px--TCfeJ _93444fe79c--display_block--pDAEx _93444fe79c--text--g9xAG _93444fe79c--text_letterSpacing__normal--xbqP6 _93444fe79c--text_whiteSpace__pre-line--rfFpL']"); 

        public string _numberApartmentExpected = "Вы сравниваете 2 квартиры, можно добавить ещё 18";
        public string _numberApartmentActual = "";


        public ApartmentComparisonPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ClickElementSearchApartments()
        {
            //если всего будет две вкладки, то перейти на новую можно так:
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            var searchApartments = driver.FindElement(_searchApartmentsButton);
            searchApartments.Click();
        }

        public void ClickAddApartment()
        {
            Actions builder = new Actions(driver);

            // добавлена к сравнению 1 квартира
            var oneApartment = driver.FindElement(_oneApartmentForm);
            builder.MoveToElement(oneApartment).Perform();
            var addApartmentOneApatment = driver.FindElement(_addOneApatmentButton);
            addApartmentOneApatment.Click();

            // добавлена к сравнению 2 квартира
            var twoApartment = driver.FindElement(_twoApartmentForm);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", twoApartment);
            builder.MoveToElement(twoApartment).Perform();
            var addApartmentTwoApartment = driver.FindElement(_addTwoApartmentButton);
            addApartmentTwoApartment.Click();

            WaitElement(_numberApartmentText);
            _numberApartmentActual = driver.FindElement(_numberApartmentText).Text;
        }

        public void WaitElement(By locator)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Not found: {locator}", ex);
            }
        }

    }
}
