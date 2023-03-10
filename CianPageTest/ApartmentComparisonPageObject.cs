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
    class ApartmentComparisonPageObject : OftenUsedFunctions
    {
        private readonly By _searchApartmentsButton = By.XPath("//span[@class='_5b10bb2305--text--rH6sj']");
        private readonly By _oneApartmentForm = By.XPath("(//span[@class='_93444fe79c--link-area--NQqFo'])[1]");
        private readonly By _twoApartmentForm = By.XPath("(//span[@class='_93444fe79c--link-area--NQqFo'])[2]");
        private readonly By _addOneApatmentButton = By.XPath("(//button[@data-mark='ComparisonControl'])[1]");
        private readonly By _addTwoApartmentButton = By.XPath("(//button[@data-mark='ComparisonControl'])[2]");
        private readonly By _numberApartmentText = By.XPath("//p[@class='_93444fe79c--color_white_100--YUO3d _93444fe79c--lineHeight_20px--tUURJ _93444fe79c--fontWeight_normal--P9Ylg _93444fe79c--fontSize_14px--TCfeJ _93444fe79c--display_block--pDAEx _93444fe79c--text--g9xAG _93444fe79c--text_letterSpacing__normal--xbqP6 _93444fe79c--text_whiteSpace__pre-line--rfFpL']");
        private readonly By _timeOneForm = By.XPath("(//div[@class='_93444fe79c--absolute--yut0v'])[1]");

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
            ClickElement(_searchApartmentsButton);
        }

        public void ClickAddApartment()
        {
            Actions builder = new Actions(driver);

            // добавлена к сравнению 1 квартира
            var oneApartment = driver.FindElement(_oneApartmentForm);
            builder.MoveToElement(oneApartment).Perform();
            WaitElementToBeClickable(_addOneApatmentButton);
            ClickElement(_addOneApatmentButton);

            // добавлена к сравнению 2 квартира
            var time = driver.FindElement(_timeOneForm);
            var twoApartment = driver.FindElement(_twoApartmentForm);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", time);
            builder.MoveToElement(twoApartment).Perform();
            ClickElement(_addTwoApartmentButton);
            WaitElementToBeVisible(_numberApartmentText);
            _numberApartmentActual = driver.FindElement(_numberApartmentText).Text;
        }
    }
}
